// TODO VC - is this necessary, not shown in docs
// namespace AspNetWebApiRest.Models
// Both are OK. It depends on how many records will be in a table. Int allows only 2*10^9 records per table.
// localhost..//Products (capitalized??)

// Models\Customer.cs(3,1): error CS8652: The feature 'top-level statements' is currently in Preview and *unsupported*.
// To use Preview features, use the 'preview' language version. [C:\Users\Jeca\Documents\GitHub\atomiv\atomiv-dotnet\pck\lite\Atomiv.Template.Lite\Atomiv.Template.Lite.csproj]
namespace Atomiv.Template.Lite.Models
{
    public class Customer
    {
        // TODO VC olong or int
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // TODO VC
        // online... public int Id { get; set; }
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