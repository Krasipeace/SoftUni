namespace ValidationAttributes.Models
{
    using System;

    [AttributeUsage(AttributeTargets.Property)] 
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object property);
    }
}
