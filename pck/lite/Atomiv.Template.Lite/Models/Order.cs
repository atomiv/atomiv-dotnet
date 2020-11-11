// TODO can this eb put somewheer higher up
using System;
using System.Collections.Generic;

namespace Atomiv.Template.Lite.Models
{
    public class Order
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneartedoption.Identity)]
        // [Display(Name ="Student Id")]
        // public int StudentId { get; set; }
        public int Id { get; set; }
        // time created... call it CreatedAt TODO VC
        // or.. System.DateTime
        public DateTime OrderDate { get; set; }
        // public DateTime? LogInTime { get; set; }
        public int CustomerId { get; set; }
        // public List<OrderItem> OrderItems { get; set; }
        // public virtual ICollection<OrderItem> OrderItems { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

   
}

/*
[
  {
     "id": 100,
     "name": "Fruits and Vegetables",
     "products": []
  },
  {
     "id": 101,
     "name": "Dairy",
     "products": []
  }
]
*/


/*
TODO VC
Try adding

"Systems.Collections": "version here"
to your project.json

Your framework field may look like this:

"frameworks": {
    "dnx451": { },
    "dnxcore50": {
       "dependencies": {
           "Microsoft.CSharp": "4.0.1-beta-23516",
           "System.Collections": "4.0.11-beta-23516",
           "System.Console": "4.0.0-beta-23516",
           "System.Linq": "4.0.1-beta-23516",
           "System.Threading": "4.0.11-beta-23516"
       }
   }
}

in your dependencies inside your project.json.
*/

/*
Entity Framework would use ICollection<T> because it needs to support Add operations, which are not part of the IEnumerable<T> interface.

Also note that you were using ICollection<T>, you were merely exposing it as the List<T> implementation. List<T> brings along with it IList<T>, ICollection<T>, and IEnumerable<T>.
*/

/*
public class OrderItemDetailsViewModel
{
    public Order order { get; set; }
    public ItemDetails[] itemDetails { get; set; }
}
Step 7: Change the Post action method as shown in the following code:

public IHttpActionResult Post(OrderItemDetailsViewModel orderInfo)
{
    Order ord = orderInfo.order;
    var ordDetails = orderInfo.itemDetails;
    return Ok();
}
*/


/*
No type was specified for the decimal column 'ProductPrice' on entity type 'OrderItem'. This will cause derItem'. This will cause values to be silently truncated if they do not fit in the e. Explicitly specify the 
default precision and scale. Explicitly specify the SQL server column type that can 
accommodate all the values using 'HasColumnType()'.
warn: Microsoft.EntityFrameworkCore.Model.Validation[30000]                          This will cause values to
      No type was specified for the decimal column 'Price' on entity type 'Product'.itly specify the SQL serve This will cause values to be silently truncated if they do not fit in the default precision and scale. Explicitly specify the SQL server column type that can accommodate all the values using 'HasColumnType()'.
Done.
*/
