using System.ComponentModel.DataAnnotations.Schema;

namespace OrderTrackerDemo
{
    class Order
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        [NotMapped]
        public string Name { get; set; }
        [NotMapped]
        public double Price { get; set; }
        [NotMapped]
        public double SumPrice => Quantity * Price;

        public Order()
        {

        }
    }
}
