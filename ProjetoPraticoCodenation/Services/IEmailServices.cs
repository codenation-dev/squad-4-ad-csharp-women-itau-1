using ProjetoPraticoCodenation.Models;
using System.Threading.Tasks;

namespace ProjetoPraticoCodenation.Services
{
    public interface IEmailServices
    {
        Task<EmailResponse> SendEmailBySendGridAsync(string email, string assunto, string mensagem);
    }
}