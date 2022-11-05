namespace MilitaryElite.Models
{
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using MilitaryElite.Models.Enums;

     public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, Dictionary<int, IPrivate> privates) 
            : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }
        public Dictionary<int, IPrivate> Privates { get; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var item in Privates)
            {
                sb.AppendLine($"  {item.Value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
