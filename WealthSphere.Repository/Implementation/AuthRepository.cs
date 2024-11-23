using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthSphere.Repository.DataAccess;
using WealthSphere.Repository.Interface;

namespace WealthSphere.Repository.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        public readonly WealthSphereDbContext _dbContext;
        public AuthRepository(WealthSphereDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public bool UserRegistration(Registration registration)
        {
            _dbContext.Registration.Add(registration);
            _dbContext.SaveChanges();
            return true;
        }

        public Registration? GetUser(string emailId)
        {
            var result = _dbContext.Registration.Where(x => x.EmailId == emailId).FirstOrDefault();
            return result;            
        }


    }
}
