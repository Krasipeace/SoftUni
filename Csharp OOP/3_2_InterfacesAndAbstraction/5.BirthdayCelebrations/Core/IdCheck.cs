namespace BorderControl.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Interfaces;
    using BorderControl.Models;
    using BorderControl.Models.Interfaces;

    public class IdCheck : IEngine
    {
        public List<IIdentify> identifications;
        public void RunEngine() 
        {
            identifications = new List<IIdentify>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] dataInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = dataInfo[0];

                if (dataInfo.Length > 2)
                {
                    identifications.Add(new Citizen(name, int.Parse(dataInfo[1]), dataInfo[2], dataInfo[3]));
                }
                else
                {
                    identifications.Add(new Robot(name, dataInfo[1]));
                }
            }

            string detainedId = Console.ReadLine();

            foreach (var item in identifications.Select(x => x.Id).Where(y => y.EndsWith(detainedId)))
            {
                Console.WriteLine(item);
            }
        }              
    }
}
