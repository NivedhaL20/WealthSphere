using WealthSphere.Repository.DataAccess;

namespace WealthSphere.Repository.Interface
{
    public interface IAuthRepository
    {
        bool UserRegistration(Registration registration);
        Registration? GetUser(string emailId);
    }
}
