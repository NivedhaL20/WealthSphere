using AutoMapper;
using WealthSphere.Model;
using WealthSphere.Repository.DataAccess;

namespace WealthSphere.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {            
            CreateMap<Income, IncomeModel>();  
            CreateMap<Registration, RegistrationModel>();  
        }
    }
}
