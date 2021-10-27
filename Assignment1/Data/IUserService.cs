using System.Threading.Tasks;
using Assignment1.Model;

namespace Assignment1.Data
{
    public interface IUserService
    {
        Task<LoginUser> ValidateUserAsync(string username, string password);
    }
}