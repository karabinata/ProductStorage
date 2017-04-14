using Microsoft.AspNet.Identity.EntityFramework;
using ProductStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStorage.Data
{
    public class ProductStorageContext : IdentityDbContext<ApplicationUser>
    {
        public ProductStorageContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ProductStorageContext Create()
        {
            return new ProductStorageContext();
        }
    }
}
