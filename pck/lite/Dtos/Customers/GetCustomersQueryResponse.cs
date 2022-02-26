﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Dtos.Customers
{
	public class GetCustomersQueryResponse
	{
		public List<GetCustomersRecordResponse> Records { get; set; }
	}

	public class GetCustomersRecordResponse
	{
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
