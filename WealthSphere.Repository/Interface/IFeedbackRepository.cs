using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WealthSphere.Repository.DataAccess;

namespace WealthSphere.Repository.Interface
{
    public interface IFeedbackRepository
    {
        Task<bool> AddAsync(Feedback feedback);
    }
}
