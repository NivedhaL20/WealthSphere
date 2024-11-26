using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthSphere.Repository.DataAccess
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public string? VisuallyAppealing { get; set; }
        public string? EasyToAccess { get; set; }
        public string? AnyChangesRequired { get; set; }
        public string? MostLikedFeature { get; set; }
        public string? Rating { get; set; }
        public Guid? UserId { get; set; }
    }
}
