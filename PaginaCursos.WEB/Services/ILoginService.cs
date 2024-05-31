using PaginaCursos.WEB.AuthenticationProviders;
using System.Threading.Tasks;
namespace PaginaCursos.WEB.Services
{
    public interface ILoginService
    {
        Task LoginAsync(string token);
        Task LogoutAsync();
    }
}
