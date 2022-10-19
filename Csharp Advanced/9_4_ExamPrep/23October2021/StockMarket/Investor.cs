using System;
using System.Collections.Generic;
using System.Linq;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public List<Stock> Portfolio { get; set; }
        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            const decimal COMPANY_VALUE = 10000;
            if (stock.MarketCapitalization > COMPANY_VALUE && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock company = Portfolio.Where(x => x.CompanyName == companyName).FirstOrDefault();
            if (company == null)
            {
                return $"{companyName} does not exist.";
            }
            if (Portfolio.First(x => x.CompanyName == companyName).PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }
            Portfolio.Remove(Portfolio.First(x => x.CompanyName == companyName));
            MoneyToInvest += sellPrice;

            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return Portfolio.Where(x => x.CompanyName == companyName).FirstOrDefault();
        }

        public Stock FindBiggestCompany()
        {
            return Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
            => $"The Investor: {FullName} with a broker {BrokerName} has stocks:" +
             Environment.NewLine +
             string.Join(Environment.NewLine, Portfolio);
    }
}
