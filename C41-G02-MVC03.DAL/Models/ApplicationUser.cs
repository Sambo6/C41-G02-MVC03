using Microsoft.AspNetCore.Identity;

namespace C41_G02_MVC03.DAL.Models
{
	public class ApplicationUser: IdentityUser
	{
        public string FName { get; set; }
		public string LName { get; set; }
        public bool IsAgree { get; set; }

    }
}
