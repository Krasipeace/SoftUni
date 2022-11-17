namespace ValidationAttributes.Models
{
    using System;

    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object property)
        {
            int numObj = Convert.ToInt32(property);

            return numObj >= minValue && numObj <= maxValue;
        }
    }
}
