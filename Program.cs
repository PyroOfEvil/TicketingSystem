using System;
using System.IO;

namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.txt";
            string choice;
            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // read data from file
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // convert string to array
                            string[] arr = line.Split(',');
                            // display array data
                            Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}",  
                                arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                        }
                        sr.Close();
                        
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    // create file from data
                    StreamWriter sw = new StreamWriter(file);
                    for (int i = 0; i < 7; i++)
                    {
                        // ask a question
                        Console.WriteLine("Enter a Ticket (Y/N)?");
                        // input the response
                        string resp = Console.ReadLine().ToUpper();
                        // if the response is anything other than "Y", stop asking
                        if (resp != "Y") { break; }
                        // prompt for TicketID
                        Console.WriteLine("Enter the TicketID.");
                        // save the TicketID
                        string Id = Console.ReadLine();
                        // prompt for Summary
                        Console.WriteLine("Write a summary of the ticket.");
                        // save the Summary
                        string Summary = Console.ReadLine();
                        //Prompt for Status
                        Console.WriteLine("What is the status of the ticket?");
                        //Save the Status
                        String status = Console.ReadLine();
                        //Prompt for priority
                        Console.WriteLine("What is the priority of the ticket?");
                        //save the priority
                        String Priority = Console.ReadLine();
                        //Prompt for submitter
                        Console.WriteLine("Who is the submitter?");
                        //Save the Submitter
                        String Submitter = Console.ReadLine();
                        //Prompt for Assigned
                        Console.WriteLine("Who assigned the ticket?");
                        //Save the Assigned
                        String Assigned = Console.ReadLine();
                        //Prompt for Watching
                        Console.WriteLine("Whose watching the ticket?");
                        //Save the watching
                        String Watching = Console.ReadLine();
                        bool Watchers = true;
                        while (Watchers == true)
                        {
                            Console.WriteLine("Are there more watchers? Y/N");
                            String Temp = Console.ReadLine();
                            if (Temp == "Y")
                            {
                                Console.WriteLine("Who is watching?");
                                Temp = Console.ReadLine();
                                Watching = Watching + '|' + Temp;
                            }
                            else if (Temp == "N")
                            {
                                Watchers = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid entry");
                            }                                
                        }

                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", Id, Summary, status, Priority, Submitter, Assigned, Watching);
                    }
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}