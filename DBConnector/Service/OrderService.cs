using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBConnector.Model;

namespace DBConnector.Service
{
    public class OrderService
    {
        private string ConnetionString = @"Server = localhost; Database = Project; Integrated Security = SSPI;";

        public void SaveOrder(Order order)
        {
            using (var connection = new SqlConnection(ConnetionString))
            {
                String query = "insert into db.UberOrder (CarType, Goal, AddressNumber, OrderDate, CreatedDate) " +
                               "values ('" 
                               + order.carType + "', '" 
                               + order.address + "', '" 
                               + order.addressNumber + "', '" 
                               + order.date.ToString("yyyy-MM-dd H:mm:ss") + "', '" 
                               + DateTime.Today.ToString("yyyy-MM-dd H:mm:ss") + "')";
                connection.Open();
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}