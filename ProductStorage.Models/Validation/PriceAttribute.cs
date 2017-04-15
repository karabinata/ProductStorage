namespace ProductStorage.Models.Validation
{
    using System.ComponentModel.DataAnnotations;
    public class PriceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var price = decimal.Parse(value.ToString());

            if (price < 0.0m)
            {
                return false;
            }

            return true;
        }
    }
}
