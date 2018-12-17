using System;

namespace DBConnector.Model
{
    // TODO uzupełnić o pozostałe wymagane pola
    public class Order
    {
        public CarType CarType { get; set; }
        public Address Address { get; set; }

        public Order()
        {
            this.CarType = new CarType();
            this.Address = new Address();
        }
    }
}