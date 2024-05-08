using System.Threading.Tasks;

namespace C41_G02_MVC03.PL.Services.EmailSender
{
	public interface IEmailSender
	{
		public Task SendAsync(string from, string recipients, string subject, string body)
		{
			throw new System.NotImplementedException();
		}
	}
}
