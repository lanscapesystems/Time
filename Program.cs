using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.IO;

namespace Time
{
    
    class Program
    {
        static string filePath = @"/home/andy/Desktop/time.txt";
        static int times;
        static float WeekTime;

      
        static void Main(string[] args)
        {
            
            
            for (var i = 1; i > 0; i ++)
            {
                string input;
                Console.Write("Time_V0.1: ");
                input = Console.ReadLine();
                switch(input.ToLower())
                {
                    case "addtime":
                    {
                        AddTime();
                        break;
                    }
                    case "readtime":
                    {
                        ShowTime();
                        break;
                    }
                    case "write":
                    {
                        WriteTimeToTxt();
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Options are \"addtime\", \"readtime\", or \"write\"");
                        break;
                    }

                }
            }
        }              

        static private void ShowTime()
        {
            Console.WriteLine(WeekTime+" Hours");
        }

        static private void AddTime()
        {   
            if(times <7)
            {
                Console.Write("Time to add in hours: ");
                float t = float.Parse(Console.ReadLine());
                WeekTime += t;
                times += 1;
                Console.Write("Add more time? (y/n): ");
                string input2 = Console.ReadLine();
                if(input2 == "y")
                {
                    AddTime();
                }
            }
            else
            {
                Console.Write("Write week's time to text file? (y/n): ");
                string consoleInput;
                consoleInput = Console.ReadLine();
                if(consoleInput.ToLower() == "y")
                {
                    WriteTimeToTxt();
                }
                
            }
        }
        
        static private void WriteTimeToTxt()
        {

 
             DateTime date = DateTime.Today;

            // lastMonday is always the Monday before nextSunday.
            // When date is a Sunday, lastMonday will be tomorrow.     
            int offset = date.DayOfWeek - DayOfWeek.Monday;     
            DateTime lastMonday = date.AddDays(-offset);
            string dateOfLastMonday = lastMonday.ToString("d");

            using (StreamWriter outputFile = new StreamWriter(filePath, true))
            {
                outputFile.WriteLine("Week of Monday, "+dateOfLastMonday+": "+WeekTime+" Hours");
                
            }
            Console.WriteLine("Hours written to "+filePath);
            WeekTime = 0;
            times = 0;
        }

    }
}
