using System.ComponentModel.DataAnnotations;

namespace Optivem.Platform.Web.AspNetCore.Rest.Fake.Models
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
