namespace OnlineShop.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Controller : IController
    {
        public Controller()
        {
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            throw new NotImplementedException();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            throw new NotImplementedException();
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            throw new NotImplementedException();
        }

        public string BuyBest(decimal budget)
        {
            throw new NotImplementedException();
        }

        public string BuyComputer(int id)
        {
            throw new NotImplementedException();
        }

        public string GetComputerData(int id)
        {
            throw new NotImplementedException();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            throw new NotImplementedException();
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            throw new NotImplementedException();
        }
    }
}
