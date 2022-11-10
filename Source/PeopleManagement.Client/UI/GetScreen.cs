using Newtonsoft.Json;
using PeopleManagement.Client.Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleManagement.Client.UI
{
    public class GetScreen
    {
        public static void Show()
        {
            Console.WriteLine("\n\n-------------------------------------\n\n");
            Console.WriteLine("Retrieving data from server");
            Console.WriteLine("Data received:");

            string receivedData = get();


            Console.WriteLine(JsonConvert.SerializeObject(receivedData, Formatting.Indented));
            Console.WriteLine("\n\n-------------------------------------\n\n");
        }

        private static string get()
        {
            var client = new EmployeeCommunication();
            var result = client.Get("https://localhost:5001/employee");

            return result.Response;
        }
    }
}
