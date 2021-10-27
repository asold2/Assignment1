using System.Threading.Tasks;
using AssignmentWebAPI.Model;

namespace AssignmentWebAPI.Data
{
    public interface IUserService
    {
        Task<LoginUser> ValidateUser(string username, string password);
    }
}