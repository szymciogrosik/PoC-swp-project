using System;
using System.Collections.Generic;

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

        public Boolean IsReady()
        {
            if (!this.CarType.IsValueSet()) return false;
            if (!this.Address.IsValueSet()) return false;
            if (!this.AddressNumber.IsValueSet()) return false;
            if (!this.Hour.IsValueSet()) return false;
            if (!this.Minute.IsValueSet()) return false;

            return true;
        }
    }
}