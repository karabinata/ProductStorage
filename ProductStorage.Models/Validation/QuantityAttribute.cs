namespace ProductStorage.Models.Validation
{
    using System.ComponentModel.DataAnnotations;
    public class QuantityAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var quantity = int.Parse(value.ToString());

            if (quantity < 0)
            {
                return false;
            }

            return true;
        }
    }
}
