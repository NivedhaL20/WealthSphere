using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WealthSphere.Model;
using WealthSphere.Repository.DataAccess;
using WealthSphere.Repository.Implementation;
using WealthSphere.Repository.Interface;
using WealthSphere.Services.Interface;

namespace WealthSphere.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private static readonly Dictionary<string, string> _usersDb = new Dictionary<string, string>
        {
            { "Nivedha", "aed6d433740e415b78077f93b5445061b4704bc17ccb4427bb026ca60737e8e8" } //password: @spKJ8segvt@
        };

        public readonly IAuthRepository _authRepository;

        //Dependency injection
        public AuthService(IAuthRepository authRepository) 
        {
            _authRepository = authRepository;
        }

        public bool Login(string username, string password)
        {
            bool isAuthenticated = false;

            var user = _authRepository.GetUser(username);
            var passwordHash = GetPasswordHash(password);

            if (passwordHash == user.Password)
            {
                isAuthenticated = true;
            }
            return isAuthenticated;
        }

        public bool Register(RegistrationModel registration)
        {
            var request = new Registration
            {
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                EmailId = registration.EmailId,
                PhoneNumber = registration.PhoneNumber,
                Password = GetPasswordHash(registration.Password)
            };            
            var result = _authRepository.UserRegistration(request);
            return result;
        }

        public RegistrationModel GetUser(string emailId)
        {           
            var result = _authRepository.GetUser(emailId);
            var response = new RegistrationModel
            {
                FirstName = result.FirstName,
                LastName = result.LastName,
                EmailId = result.EmailId,
                PhoneNumber = result.PhoneNumber
            };
            return response;
        }

        private static string GetPasswordHash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedPassword = string.Join("", sha256
                    .ComputeHash(Encoding.UTF8.GetBytes(password))
                    .Select(b => b.ToString("x2")));
                return hashedPassword;
            }
        }


    }
}
