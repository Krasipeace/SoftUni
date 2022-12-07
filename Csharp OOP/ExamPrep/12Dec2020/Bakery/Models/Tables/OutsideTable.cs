namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
    private const decimal PRICE_PER_PERSON = 3.50m;
        public OutsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, PRICE_PER_PERSON)
        {
        }
    }
}
