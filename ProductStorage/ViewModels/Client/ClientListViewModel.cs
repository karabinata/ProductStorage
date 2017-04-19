namespace ProductStorage.ViewModels.Client
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ClientListViewModel
    {
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(100), DisplayName("Client name")]
        public string Name { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Is VAT registered")]
        public bool IsVatRegisterd { get; set; }
    }
}