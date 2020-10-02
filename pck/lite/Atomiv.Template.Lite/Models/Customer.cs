// TODO VC - is this necessary, not shown in docs
// namespace AspNetWebApiRest.Models
// Both are OK. It depends on how many records will be in a table. Int allows only 2*10^9 records per table.
// localhost..//Products (capitalized??)

// Models\Customer.cs(3,1): error CS8652: The feature 'top-level statements' is currently in Preview and *unsupported*.
// To use Preview features, use the 'preview' language version. [C:\Users\Jeca\Documents\GitHub\atomiv\atomiv-dotnet\pck\lite\Atomiv.Template.Lite\Atomiv.Template.Lite.csproj]
using System.ComponentModel.DataAnnotations;

namespace Atomiv.Template.Lite.Models
{
    public class Customer
    {
        public long Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="please fill this in")]
        // to change the error message displayed in postman
        public string FirstName { get; set; }
        [Required(ErrorMessage = "this is required")]
        [MaxLength(50, ErrorMessage = "surname cannot exceed 50 characters")]
        // MinimumLength property is optional below
        // [StringLength(20, MinimumLength = 4, ErrorMessage = "Must be at least 4 characters long.")]
        // more relievant if MVC
        // [Display(Name = "Your Surname")]
        public string LastName { get; set; }
        /*
        [Required]
        [Display(Name = "Email")]
        // [DataType(DataType.EmailAddress)]
        [EmailAddress]
        // [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        // [RegularExpression("some regex", ErrorMessage = "Invalid Password")]
        // [Required]
        // public string Password { get; set; }
        */

        // public Dept Department { get; set; }
    }
}

/*
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
*

// We can see the effect of these annotations when we try to post an invalid record from Postman as below:
// "FirstName": "", -- in oOstman

/*
public int Id { get; set; }
 
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
 
        public int UserId { get; set; }
        public virtual User User { get; set; }
 
        public bool IsDeleted { get; set; }
        */


/*
 * [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [ClassicMovie(1960)]
    [DataType(DataType.Date)]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    [Required]
    [StringLength(1000)]
    public string Description { get; set; }

    [Range(0, 999.99)]
    public decimal Price { get; set; }


        [Range(0, 5)]
        public string Experience { get; set; }
 
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the Terms")]
        public bool TermsAccepted { get; set; }




    public Genre Genre { get; set; }

    public bool Preorder { get; set; }

*/