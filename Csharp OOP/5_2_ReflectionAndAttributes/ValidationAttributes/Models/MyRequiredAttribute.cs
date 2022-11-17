namespace ValidationAttributes.Models
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object property)
        {
            return property != null;
        }
    }
}
