using System;
using System.Collections.Generic;
using DBConnector.Model.Domain;

namespace DBConnector.Model
{
    public class Order
    {
        public String carType { get; set; }
        public String address { get; set; }
        public String addressNumber { get; set; }
        public DateTime date { get; set; }

        public static Order Create(OrderElements orderElements)
        {
            Order order = new Order();
            order.carType = orderElements.Find(WrapperType.CAR_TYPE).Value;
            order.address = orderElements.Find(WrapperType.ADDRESS).Value;
            order.addressNumber = orderElements.Find(WrapperType.ADDERSS_NUMBER).Value;
            DateTime currentDate = DateTime.Today;
            order.date = new DateTime(
                currentDate.Year, 
                currentDate.Month, 
                currentDate.Day, 
                int.Parse(orderElements.Find(WrapperType.HOUR).Value), 
                int.Parse(orderElements.Find(WrapperType.MINUTES).Value), 
                0
            );
            return order;
        }
    }
}