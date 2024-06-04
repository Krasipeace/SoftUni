namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string AnalyzedAccessModifiers(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();

            foreach (var item in classFields)
            {
                sb.AppendLine($"{item.Name} must be private!");
            }
            foreach (var item in classNonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} have to be public!");
            }
            foreach (var item in classPublicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();
            var classInstance = Activator.CreateInstance(classType, Array.Empty<object>());

            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (var item in classFields.Where(x => requestedFields.Contains(x.Name)))
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }
    }
}