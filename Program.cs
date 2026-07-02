using System;
using IntelligencePipeline.Models.Reports;
using IntelligencePipeline.Pipeline;

namespace IntelligencePipeline
{
    // Application entry point and user interface.
    class Program
    {
        private static ReportPipeline reportPipeline;

        static void Main(string[] args)
        {
            reportPipeline = new ReportPipeline();

            Console.WriteLine("=== Welcome to the Intelligence Pipeline System ===\n");

            bool toExit = false;

            while (!toExit)
            {
                PrintMenu();
                Console.Write("Your choice: ");
                string userChoice = Console.ReadLine();

                if (int.TryParse(userChoice, out int intUserChoice))
                {
                    switch (intUserChoice)
                    {
                        case 1:
                            HandleAddReport();
                            break;
                        case 2:
                            Console.WriteLine("Displaying Validated Reports"); 
                            break;
                        case 3:
                            Console.WriteLine("Search Reports"); 
                            break;
                        case 4:
                            Console.WriteLine("Filter Reports"); 
                            break;
                        case 5:
                            Console.WriteLine("Sort Reports"); 
                            break;
                        case 6:
                            Console.WriteLine("Update Report Status"); 
                            break;
                        case 7:
                            Console.WriteLine("Show Report Details"); 
                            break;
                        case 8:
                            Console.WriteLine("Displaying Rejected Reports"); 
                            break;
                        case 9:
                            Console.WriteLine("Show Statistics"); 
                            break;
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
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void PrintMenu()
        {
            string menu = """
                Please select one of the options:
                1. Add Report
                2. Show Validated Reports
                3. Search Reports
                4. Filter Reports
                5. Sort Reports
                6. Update Report Status
                7. Show Report Details
                8. Show Rejected Reports
                9. Show Statistics
                10. Exit System
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

        
        static void HandleAddReport()
        {
            PrintReportsTypeMenu();
            Console.Write("Your choice: ");
            string userReportTypeChoice = Console.ReadLine();

            if (int.TryParse(userReportTypeChoice, out int intUserReportTypeChoice))
            {
                switch (intUserReportTypeChoice)
                {
                    case 1:
                        Console.WriteLine("Please enter Drone input in the format: [Timestamp, Latitude, Longitude, Description, Altitude, ImageQuality]");
                        string droneInput = Console.ReadLine();
                      

                        break;

                    case 2:
                        Console.WriteLine("Please enter Soldier input...");
                        
                        break;

                    case 3:
                        Console.WriteLine("Please enter Radar input...");
                        
                        break;

                    case 4:
                        Console.WriteLine("Please enter Signal input...");
                        
                        break;

                    default:
                        Console.WriteLine("Invalid report type selected.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}