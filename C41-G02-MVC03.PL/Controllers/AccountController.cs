using C41_G02_MVC03.DAL.Models;
using C41_G02_MVC03.PL.Services.EmailSender;
using C41_G02_MVC03.PL.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace C41_G02_MVC03.PL.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IEmailSender _emailSender;
		private readonly IConfiguration _configuration;

		public AccountController(UserManager<ApplicationUser> userManager, 
									SignInManager<ApplicationUser> signInManager,
									IEmailSender emailSender, IConfiguration configuration)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_emailSender = emailSender;
			_configuration = configuration;
		}

		#region SignUp
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(model.UserName);
				if (user == null)
				{
					user = new ApplicationUser()
					{
						FName = model.FirstName,
						LName = model.LastName,
						UserName = model.UserName,
						Email = model.Email,
						IsAgree = model.IsAgree,

					};
					var result = await _userManager.CreateAsync(user, model.Password);
					if (result.Succeeded)
					{
						return RedirectToAction(nameof(SignIn));
					}
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
				else
				{
					ModelState.AddModelError(string.Empty, "this User Name is already in use for another account");
					return View(model);
				}
			}
			return View(model);
		}
		#endregion

		#region SignIn
		public IActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(SignInViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);

				if (user is not  null)
				{
					var flag = await _userManager.CheckPasswordAsync(user, model.Password);
					if (flag)
					{
						var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

						if (result.IsLockedOut)
							ModelState.AddModelError(string.Empty, "Your Account is Locked !!");

						if (result.Succeeded)
							return RedirectToAction(nameof(HomeController.Index), "Home");

						if (result.IsNotAllowed)
							ModelState.AddModelError(string.Empty, "Your Account is Not Confirmed Yet !!");


					}				
				}

				ModelState.AddModelError(string.Empty, "Invalid Login ");
			}

			return View(model);
		}
		#endregion

		#region SignOut

		public async new Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(SignIn));
		}
        #endregion

        #region ForgetPassword
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendResetPasswordEmail(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
				
				var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user); //Unique Token for this User

				if (user is not null)
				{
					var passwordUrl = Url.Action("ResetPassword", "Account", new { email = user.Email, token = resetPasswordToken });
					//send email
					await _emailSender.SendAsync(
						from: _configuration["EmailSettings:SenderEmail"],
						recipients: model.Email,
						subject: "Reset Your Password",
						body: passwordUrl
						);
					return Redirect(nameof(CheckYourInbox));
				}
				ModelState.AddModelError(string.Empty, "There is no account with this email");
            }
            return View(model);
        }
		public IActionResult CheckYourInbox()
		{
			return View();
		}

		#endregion

		#region Reset Password
		[HttpGet]
		public IActionResult ResetPassword(string email, string token)
		{
			// For Email and Token
			TempData["Email"] = email;
			TempData["token"] = token;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var email = TempData["Email"] as string;
				var token = TempData["token"] as string;
				var user = await _userManager.FindByNameAsync(email);
				if (user is not null)
				{
					await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
					return RedirectToAction(nameof(SignIn));
				}
				ModelState.AddModelError(string.Empty, "Url is Not Valid");
			}
			return View(model);
		}
		#endregion
	}																						   
}







