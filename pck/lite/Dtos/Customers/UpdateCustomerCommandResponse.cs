using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Dtos.Customers
{
	public class UpdateCustomerCommandResponse
	{
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
