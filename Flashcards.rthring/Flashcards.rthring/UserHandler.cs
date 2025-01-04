using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.rthring
{
    public class UserHandler
    {
        DatabaseController database;
        public UserHandler(DatabaseController database)
        {
            this.database = database;
        }

        public bool GetUserInput()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Manage Stacks");
            Console.WriteLine("2 - Manage Flashcards");
            Console.WriteLine("3 - Study");
            Console.WriteLine("4 - View Study Session Data");
            Console.WriteLine("-----------------------------");

            string command = Console.ReadLine();

            switch (command)
            {
                case "0":
                    Console.WriteLine("\nGoodbye!\n");
                    return true;
                case "1":
                    ManageStacks();
                    break;
                case "2":
                    
                    break;
                case "3":
                    
                    break;
                case "4":
                    
                    break;
                default:
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                    break;
            }
            return false;
        }

        private void ManageStacks()
        {
            // TODO: output all stacks
            Console.WriteLine("-----------------------------");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("{Stack Id} - Manage Stack");
            Console.WriteLine("ADD - Create a new Stack");
            Console.WriteLine("-----------------------------");
        }
    }
}
