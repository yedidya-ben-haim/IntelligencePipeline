using System;

namespace IntelligencePipeline
{
    // Application entry point and user interface.
    class Program
    {
        static void PrintMenu()
        {
            string menu = """
                Please select one of the following options:
                1. Add Report
                10. Exit System\n
                """;

            Console.WriteLine(menu);
        }

        static void PrintReportsTypeMenu()
        {
            string reportsTypeMenu = """
                Please select a Report type:
                1. Drone
                2. Soldier
                3. Radar
                4. Signal
                """;

            Console.WriteLine(reportsTypeMenu);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("===Welcome to the Intelligence Pipeline System===");

            bool toExit = false;

            while (!toExit)
            {
                PrintMenu();
                Console.Write("Your choice: ");
                string userChoice = Console.ReadLine();

                if (int.TryParse(userChoice, out int intChoice))
                {
                    switch (intChoice)
                    {
                        case 1:
                            PrintReportsTypeMenu();
                            string userReportTypeChoice = Console.ReadLine();
                            break; 

                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                            Console.WriteLine("Exiting the system. Goodbye!");
                            toExit = true;
                            break; 

                        default:
                            Console.WriteLine("Please enter a valid option from the menu.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
            }
        }
    }
}