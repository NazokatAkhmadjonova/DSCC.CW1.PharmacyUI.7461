using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DSCC.CW1.PharmacyUI._7461.Data
{
    public class DSCCCW1PharmacyUI_7461Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DSCCCW1PharmacyUI_7461Context() : base("name=DSCCCW1PharmacyUI_7461Context")
        {
        }

		public System.Data.Entity.DbSet<DSCC.CW1.PharmacyUI._7461.Models.Pharmacy> Pharmacies { get; set; }
	}
}
