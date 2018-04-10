namespace ImmutableListDemo
{
    public class OrderLine
    {
        public OrderLine(int quantity, decimal unitPrice, float discount)
        {
            Quantity = quantity;
            UnitPrice = unitPrice;
            Discount = discount;
        }

        public int Quantity { get; }

        public decimal UnitPrice { get; }

        public float Discount { get; }

        public decimal Total => Quantity * UnitPrice * (decimal) (1.0f - Discount);


        public OrderLine WithQuantity(int value)
        {
            return value == Quantity
                ? this
                : new OrderLine(value, UnitPrice, Discount);
        }

        public OrderLine WithUnitPrice(decimal value)
        {
            return value == UnitPrice
                ? this
                : new OrderLine(Quantity, value, Discount);
        }

        public OrderLine WithDiscount(float value)
        {
            return value == Discount
                ? this
                : new OrderLine(Quantity, UnitPrice, value);
        }
    }
}