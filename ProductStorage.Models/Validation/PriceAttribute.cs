namespace ProductStorage.Models.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public class PriceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var price = Convert.ToDouble(value, CultureInfo.InvariantCulture);

            if (price < 0.0)
            {
                return false;
            }

            return true;
        }
    }
}
