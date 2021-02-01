using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TaskListCapstone
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task1> tasks = new List<Task1>();

            {
                Task1 a = new Task1("Clean stapler", "not started", "12/1/22", "Robert");
                tasks.Add(a);
                tasks.Add(new Task1("Dust holepunch", "not started", "12/2/22", "Robert"));
                tasks.Add(new Task1("Scan one piece of paper", "not started", "12/14/22", "Matt"));
                tasks.Add(new Task1("Straighten paperclips", "not started", "11/1/22", "Kim"));
                tasks.Add(new Task1("Clean Mt. Dew out of the fridge", "not started", "12/19/22", "Nancy"));
                tasks.Add(new Task1("Take a coffee break", "not started", "12/29/22", "Tierra"));
                tasks.Add(new Task1("Schedule meeting for Feb 30", "not started", "10/11/22", "Mark"));
                tasks.Add(new Task1("Wash dishcloths", "not started", "1/27/22", "Kiana"));
                tasks.Add(new Task1("Seal all the envelopes", "not started", "9/18/22", "Michel"));
                tasks.Add(new Task1("Vaccuum whole office", "not started", "10/1/22", "Robert"));
                List<string> statusCheck = new List<string>();

                while (true)
                {
                    Console.WriteLine("Welcome to the task manager! Please enter the number of your selection:");
                    TaskMenu();
                    int choice = CheckNum(Console.ReadLine(), 0, 5);
                    if (choice == 1)
                    {
                        int i = 1;
                        Console.WriteLine();
                        foreach (Task1 t in tasks)
                        {
                            {
                                Console.WriteLine($"     {i++}) {t.TaskName} --- {t.Status} --- {t.Date} --- {t.TeamMember}");
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press enter to return to the main menu.");
                    }
                    if (choice == 2)
                    {                       
                        Console.WriteLine("Please enter the name of the new task.");
                        string newnewTask = (Console.ReadLine());
                        Console.WriteLine("Please enter the team member's name.");
                        string newMember = (Console.ReadLine());
                        Console.WriteLine("Please enter the due date in the format mm/dd/yyyy");
                        string newDate = (Console.ReadLine());
                        if (ValidateEntry(newnewTask, newMember, newDate))
                        {
                            Console.WriteLine("Valid entry. Task created!");
                            tasks.Add(new Task1(newnewTask, "not started", newDate, newMember));
                        }
                        else
                        {
                            Console.WriteLine("Invalid entry; please try again.");
                            return;
                        }
                        int i = 1;
                        foreach (Task1 t in tasks)
                        {
                            Console.WriteLine($"     {i++}) {t.TaskName}");
                        }
                    }
                    if (choice == 3)
                    {   
                        Console.WriteLine("What number task would you like to delete?");
                        string num = Console.ReadLine();
                        int number;
                        bool success = int.TryParse(num, out number);
                        Console.WriteLine(number);
                        if (success && number >= 1 && number <= tasks.Count)
                        {
                            Console.WriteLine($"Are you sure you would like to delete task number {num}? Y/N");
                            {
                                if ((Console.ReadLine() == "y") || (Console.ReadLine() == "Y"))
                                {
                                    Console.WriteLine($"Task number {num} deleted.");

                                   tasks.RemoveAt(number - 1);
                                    int i = 1;
                                    foreach (Task1 t in tasks)
                                    {
                                        Console.WriteLine($"     {i++}) {t.TaskName}");
                                    }                                   
                                }
                                else
                                {
                                    TaskMenu();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("incorrect format! Please enter a number.");
                            TaskMenu();
                        }
                    }
                    else if (choice == 4)
                    {   
                        Console.WriteLine("Please enter the number of the task you would like to mark complete.");
                        string entry = Console.ReadLine();
                        int numValid;
                        bool validNumber = int.TryParse(entry, out numValid);
                        if (validNumber && numValid >= 0 && numValid <= tasks.Count)
                        {
                            Console.WriteLine($"Are you sure you would like to mark task number {entry} complete? Y/N");
                            string answer = Console.ReadLine();
                            if (answer == "y" || answer == "Y")
                            {
                                tasks[numValid-1].Status = "completed";
                                int i = 1;
                                Console.WriteLine($"Task number {entry} marked complete!");
                       
                            }
                            else
                            {
                                TaskMenu();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid response.");
                        }  
                    }
                    if (Console.ReadLine().ToLower() == "n")
                    {
                        break;
                    }

                }
            }
        }
        public static void TaskMenu()
        {
            Console.WriteLine(("1) List tasks"));
            Console.WriteLine("2) Add task");
            Console.WriteLine("3) Delete task");
            Console.WriteLine("4) Mark task complete");
            Console.WriteLine("5) Quit");
        }
        static int CheckNum(string input, int min, int max)
        {
            int integer;
            while (true)
            {
                if (Int32.TryParse(input, out integer))
                {
                    if (integer >= min && integer <= max)
                    {
                        return integer;
                    }
                    else
                    {
                        Console.WriteLine($"Please select a number 1 through {max}");
                        input = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number.\n");
                    input = Console.ReadLine();
                }
            }
        }
        private static bool ValidateEntry(string newnewTask, string newMember, string newDate)
        {
            Task1 newTask = new Task1();
            if (newnewTask == null || newnewTask == String.Empty)
            {
                return false;
            }
            if (newMember == null || newMember == String.Empty)
            {
                return false;
            }
            else if (newDate == null || newDate == String.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}    

    




    
    

 

  
     

