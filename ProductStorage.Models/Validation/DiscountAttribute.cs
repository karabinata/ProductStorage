namespace ProductStorage.Models.Validation
{
    using System.ComponentModel.DataAnnotations;
    public class DiscountAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var discount = int.Parse(value.ToString());

            if (discount < 0)
            {
                return false;
            }

            return true;
        }
    }
}
