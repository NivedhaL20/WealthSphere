using WealthSphere.Model;

namespace WealthSphere.Services.Interface
{
    public interface IAuthService
    {
        bool Login(string username, string password);
        bool Register(RegistrationModel registration);
        RegistrationModel GetUser(string emailId);
    }
}
