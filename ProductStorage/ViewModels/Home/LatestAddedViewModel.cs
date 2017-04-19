namespace ProductStorage.ViewModels.Home
{
    using System.Collections.Generic;
    using Models;

    public class LatestAddedViewModel
    {
        public virtual ICollection<Storage> Storages { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }


    }
}