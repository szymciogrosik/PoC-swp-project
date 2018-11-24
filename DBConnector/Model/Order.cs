using System;

namespace DBConnector.Model
{
    public class Order
    {
        public String carType { get; set; }
        public String addressStreet { get; set; }
        public int addressNumber { get; set; }
        public int timeHour { get; set; }
        public int timeMinute { get; set; }

        public Order(string carType, string addressStreet, int addressNumber, int timeHour, int timeMinute)
        {
            this.carType = carType;
            this.addressStreet = addressStreet;
            this.addressNumber = addressNumber;
            this.timeHour = timeHour;
            this.timeMinute = timeMinute;
        }
    }
}