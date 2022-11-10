using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleManagement.Client.UI
{
    public class MainScreen
    {
        public enum States
        {
            INIT,
            GET,
            PUT,
            POST,
            DELETE,
            END
        }

        private States ApplicationState { get; set; }

        public void Start()
        {
            ApplicationState = States.INIT;

            while(ApplicationState != States.END)
            {
                switch (ApplicationState)
                {
                    case States.INIT:
                        InitialMessage();
                        break;
                    case States.GET:
                        GetScreen.Show();
                        setState(States.END);
                        break;
                    case States.PUT:
                        break;
                    case States.POST:
                        break;
                    case States.DELETE:
                        break;
                    case States.END:
                        break;
                    default:
                        break;
                }
            }
        }

        private void setState(States nextState)
        {
            ApplicationState = nextState;
        }

        private void InitialMessage()
        {
            int convertedValue;
            
            Console.WriteLine("Select one option:");
            Console.WriteLine("1 - Get all employees registered [GET]");
            Console.WriteLine("2 - Edit one specific employee data [PUT]");
            Console.WriteLine("3 - Add a employee at the DB [POST]");
            Console.WriteLine("4 - Delete an employee [DELETE]");
            Console.WriteLine("5 - Close the application");

            var readValue = Console.ReadLine();

            if (!Int32.TryParse(readValue, out convertedValue))
            {
                Console.WriteLine("Please enter a valid option\n");
                Console.WriteLine("-------------------------------------\n");

                return;
            }

            switch(convertedValue)
            {
                case 1:
                    ApplicationState = States.GET;
                    break;
                case 2:
                    ApplicationState = States.PUT;
                    break;
                case 3:
                    ApplicationState = States.POST;
                    break;
                case 4:
                    ApplicationState = States.DELETE;
                    break;
                case 5:
                    ApplicationState = States.END;
                    break;
            }

        }
    }
}
