using ConsoleTableExt;
using Flashcards.rthring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.rthring
{
    public class UserHandler(DatabaseController database)
    {
        private readonly DatabaseController _database = database;

        public bool GetUserInput()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Manage Stacks");
            Console.WriteLine("2 - Manage Flashcards");
            Console.WriteLine("3 - Study");
            Console.WriteLine("4 - View Study Session Data");
            Console.WriteLine("-----------------------------");

            string? command = Console.ReadLine();

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
            var stacks = _database.GetStacks();
            List<List<object>> tableData = [];
            foreach (var stack in stacks)
            {
                tableData.Add(
                [
                    stack.Id,
                    stack.Name
                ]);
            }
            ConsoleTableBuilder.From(tableData)
                .WithTitle("Stacks").WithColumn("Id", "Name")
                .ExportAndWriteLine();

            // TODO: output all stacks
            Console.WriteLine("-----------------------------");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Create a new Stack");
            Console.WriteLine("2 - Edit a Stack");
            Console.WriteLine("3 - Delete a Stack");
            Console.WriteLine("-----------------------------");

            string? command = Console.ReadLine();

            switch (command)
            {
                case "0":
                    break;
                case "1":
                    Console.WriteLine("\nEnter a name for the new Stack\n");
                    var name = Console.ReadLine();
                    if (name == null || name == string.Empty)
                    {
                        Console.WriteLine("\nInvalid Stack name.\n");
                        return;
                    }
                    Stack stack = new()
                    {
                        Name = name
                    };
                    _database.InsertStack(stack);
                    Console.WriteLine("\nStack Created\n");
                    break;
                case "2":

                    break;
                case "3":
                    bool deleted = false;

                    while (!deleted)
                    {
                        Console.WriteLine("\n\nPlease type the Id of the stack you want to delete or type 0 to return to main menu.");
                        int recordId = GetNumberInput();

                        if (recordId == 0) return;
                        deleted = _database.DeleteStack(recordId);
                        if (!deleted) Console.WriteLine($"\n\nStack with Id {recordId} doesn't exist.");
                    }
                    break;
                case "4":

                    break;
                default:
                    Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                    break;
            }
        }

        private static int GetNumberInput()
        {
            string? numberInput = Console.ReadLine();

            while (!int.TryParse(numberInput, out _) || Convert.ToInt32(numberInput) < 0)
            {
                Console.WriteLine("\n\nInvalid number. Try again.\n\n");
                numberInput = Console.ReadLine();
            }

            return Convert.ToInt32(numberInput);
        }
    }
}
