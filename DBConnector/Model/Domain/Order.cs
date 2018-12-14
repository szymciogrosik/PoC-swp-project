using System;

namespace DBConnector.Model
{
    // TODO uzupełnić o pozostałe wymagane pola
    public class Order
    {
        public String CarType { get; set; }
        public String addressStreet { get; set; }

        public Order(String CarType, String addressStreet)
        {
            this.CarType = CarType;
            this.addressStreet = addressStreet;
        }
    }
}