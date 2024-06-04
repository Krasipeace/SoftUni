namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
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
