using System.ComponentModel.DataAnnotations;

namespace Optivem.Web.AspNetCore.Fake.Models
{
    public class CustomerPostRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
