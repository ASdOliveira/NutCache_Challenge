using PeopleManagement.Client.Communication;
using PeopleManagement.Client.UI;
using System;

namespace PeopleManagement.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MainScreen screen = new MainScreen();

            screen.Start();

            //var client = new EmployeeCommunication();
            //var result = client.Get("https://localhost:5001/employee");
        }
    }
}
