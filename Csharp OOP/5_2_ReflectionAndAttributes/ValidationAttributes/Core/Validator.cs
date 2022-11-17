namespace ValidationAttributes.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using ValidationAttributes.Models;

    public class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] propertyData = objType.GetProperties();
            foreach (var _ in from item in propertyData
                              let myAttributes = item.GetCustomAttributes<MyValidationAttribute>().ToList()
                              let property = item.GetValue(obj)
                              from _ in
                                  from myValidatedAttr in myAttributes
                                  let isValid = myValidatedAttr.IsValid(property)
                                  where !isValid
                                  select new { }
                              select new { })
            {
                return false;
            }

            return true;
        }
    }
}
