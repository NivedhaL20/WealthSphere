using System.ComponentModel.DataAnnotations;

namespace WealthSphere.Repository.DataAccess
{
    public class Registration
    {
        [Key]
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
    }
}
