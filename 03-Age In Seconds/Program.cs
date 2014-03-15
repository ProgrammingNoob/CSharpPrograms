using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingNoob
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Age calculator in seconds. 4CHAN /g/";

            Console.WriteLine("Please enter your birth date in this format: yyyy/mm/dd");
            while (true)
            {
                string d = Console.ReadLine();

                try
                {
                    DateTime t = DateTime.ParseExact(d, "yyyy/mm/dd", null);
                    TimeSpan ts = DateTime.Now - t;

                    Console.WriteLine("Your approximate age in seconds: {0}", ts.TotalSeconds);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid date entered, please try again");
                }
            }
        }
    }
}