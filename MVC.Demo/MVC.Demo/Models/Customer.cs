using System.ComponentModel.DataAnnotations;
using MVC.Demo.App_GlobalResources;

namespace MVC.Demo.Models
{
    public class Customer
    {
        [ScaffoldColumn(false)]
        public int CustomerId { get; set; }

        [Required, StringLength(64), Display(ResourceType = typeof(ModelResources), Name = "FirstName")]
        public string FirstName { get; set; }

        [Required, StringLength(64), Display(ResourceType = typeof(ModelResources), Name = "LastName")]
        public string LastName { get; set; }

        [Required, EmailAddress, StringLength(256)]
        public string Email { get; set; }

        [Range(0, 199), Display(Name = "Age", ResourceType = typeof(ModelResources))]
        public int? Age { get; set; }

        public int RequiredIntField { get; set; }
    }
}