namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {
        private const decimal PRICE_PER_PERSON = 2.50m;
        public InsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, PRICE_PER_PERSON)
        {
        }
    }
}
