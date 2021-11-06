using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSCC.CW1.PharmacyUI._7461.Models
{
	public class Medicine
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime ProductionDate { get; set; }
		public DateTime ExpirationDate { get; set; }
		public int Quantity { get; set; }
		public Pharmacy Pharmacy { get; set; }
	}
}