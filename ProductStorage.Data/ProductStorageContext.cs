﻿namespace ProductStorage.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class ProductStorageContext : IdentityDbContext<ApplicationUser>
    {
        public ProductStorageContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ProductStorageContext>());
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<Offer> Offers { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Storage> Storages { get; set; }

        public static ProductStorageContext Create()
        {
            return new ProductStorageContext();
        }
    }
}
