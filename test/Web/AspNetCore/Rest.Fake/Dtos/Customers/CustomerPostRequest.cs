using System.ComponentModel.DataAnnotations;

namespace Optivem.Framework.Web.AspNetCore.Rest.Fake.Models
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
