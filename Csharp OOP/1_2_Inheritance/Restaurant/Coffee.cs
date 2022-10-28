namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILILLITERS = 50;
        private const decimal COFFEE_PRICE = 3.5m;
        public Coffee(string name, double caffeine) : base(name, COFFEE_PRICE, COFFEE_MILILLITERS)
        {
            Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
    }
}
