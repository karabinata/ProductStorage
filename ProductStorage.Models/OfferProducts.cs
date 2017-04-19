namespace ProductStorage.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OfferProducts
    {
        [Key, Column(Order = 0)]
        public int OfferId { get; set; }

        public virtual Offer Offer { get; set; }

        [Key, Column(Order = 1)]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int ProductQuantityInOffer { get; set; }
    }
}
