using System;

namespace DBConnector.Model
{
    // TODO uzupełnić o pozostałe wymagane pola
    public class Order
    {
        public CarType CarType { get; set; }
        public Address Address { get; set; }
        public AddressNumber AddressNumber { get; set; }
        public Hour Hour { get; set; }
        public Minute Minute { get; set; }

        public Order()
        {
            this.CarType = new CarType();
            this.Address = new Address();
            this.AddressNumber = new AddressNumber();
            this.Hour = new Hour();
            this.Minute = new Minute();
        }
    }
}