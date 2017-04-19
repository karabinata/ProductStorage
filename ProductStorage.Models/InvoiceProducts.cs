namespace ProductStorage.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class InvoiceProducts
    {
        [Key, Column(Order = 0)]
        public int InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }

        [Key, Column(Order = 1)]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int ProductQuantityInInvoice { get; set; }
    }
}
