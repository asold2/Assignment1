using Assignment1.Model;

namespace Assignment1.Data
{
    public interface IUserService
    {
        LoginUser ValidateUser(string username, string password);
    }
}