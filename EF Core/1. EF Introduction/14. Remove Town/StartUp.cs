using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            string result = RemoveTown(dbContext);

            Console.WriteLine(result);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            Town townToDelete = context.Towns
                .Where(t => t.Name == "Seattle")
                .FirstOrDefault()!;

            Address[] addressToDelete = context.Addresses
                .Where(a => a.TownId == townToDelete.TownId)
                .ToArray();

            Employee[] employeesToRemove = context.Employees
                .Where(e => addressToDelete
                    .Contains(e.Address))
                .ToArray();

            foreach (var e in employeesToRemove)
            {
                e.AddressId = null;
            }

            context.Addresses.RemoveRange(addressToDelete);
            context.Towns.Remove(townToDelete);
            context.SaveChanges();

            return $"{addressToDelete.Count()} addresses in Seattle were deleted";
        }
    }
}