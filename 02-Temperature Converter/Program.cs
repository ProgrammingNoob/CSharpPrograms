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
            Console.Title = "Temperature Converter. 4CHAN /g/";

            Temp[] SupportedTemps = new Temp[] 
            {
                new Celsius(),
                new Fahrenheit(),
                new Rankine(),
                new Delisle(),
                new Newton(),
                new Réaumur(),
                new Rømer(),
                new Kelvin()
            };

            Console.WriteLine
                ("Please enter temperature with suffix appended.\n" +
                "Suffixes accepted:");

            foreach (Temp temp in SupportedTemps)
            {
                Console.WriteLine("\t {0}{1} - {2} (Key: {3})", temp.IsRelative ? "°" : "", temp.Suffix, temp.Name, temp.Key.ToString());
            }

            //in kelvin
            double input_temp = 0.0;
            bool a = true;
            while (a)
            {
                try
                {
                    string input = Console.ReadLine().ToLower();

                    foreach (Temp temp in SupportedTemps)
                    {
                        if (input.EndsWith(temp.Suffix.ToLower()))
                        {
                            input_temp = temp.ToKelvin(Convert.ToDouble(input.Replace(temp.Suffix.ToLower(), "")));
                            a = false;
                            break;
                        }
                    }

                    if (a) { Console.WriteLine("Invalid temperature suffix, please try again"); }

                }
                catch (Exception)
                {
                    Console.WriteLine("Possible non numeric or a very large number entered, please try again");
                }
            }

            Console.WriteLine("Please enter the key of the target temp");

            double output_temp = 0.0;

            bool b = true;

            ConsoleKey key = ConsoleKey.OemPeriod;
            Temp target_temp = null;

            while (b)
            {
                key = Console.ReadKey().Key;

                foreach (Temp temp in SupportedTemps)
                {
                    if (temp.Key == key)
                    {
                        output_temp = temp.FromKelvin(input_temp);
                        target_temp = temp;
                        b = false;
                        break;
                    }
                }

                if (b) { Console.WriteLine("Invalid temperature suffix, please try again"); }

            }

            Console.WriteLine("\nYour converted temperature is {0}{1}{2}", output_temp, target_temp.IsRelative ? "°" : "", target_temp.Suffix);
            Console.ReadKey();
        }


        public interface Temp
        {
            string Name { get; }

            ConsoleKey Key { get; }

            string Suffix { get; }

            bool IsRelative { get; }

            double ToKelvin(double kelvin);

            double FromKelvin(double kelvin);
        }

        public class Kelvin : Temp
        {

            public string Name { get { return "Kelvin"; } }
            public ConsoleKey Key { get { return ConsoleKey.K; } }
            public string Suffix { get { return "K"; } }
            public bool IsRelative { get { return false; } }

            public double ToKelvin(double t)
            {
                return t;
            }

            public double FromKelvin(double t)
            {
                return t;
            }
        }

        public class Celsius : Temp
        {

            public string Name { get { return "Celsius"; } }
            public ConsoleKey Key { get { return ConsoleKey.C; } }
            public string Suffix { get { return "C"; } }
            public bool IsRelative { get { return true; } }

            public double ToKelvin(double t)
            {
                return t + 273.15;
            }

            public double FromKelvin(double t)
            {
                return t - 273.15;
            }
        }

        public class Fahrenheit : Temp
        {

            public string Name { get { return "Fahrenheit"; } }
            public ConsoleKey Key { get { return ConsoleKey.F; } }
            public string Suffix { get { return "F"; } }
            public bool IsRelative { get { return true; } }

            public double ToKelvin(double t)
            {
                return ((t - 32) / 1.8) + 273.15;
            }

            public double FromKelvin(double t)
            {
                return ((t - 273.15) * 1.8) + 32.0;
            }
        }

        public class Rankine : Temp
        {

            public string Name { get { return "Rankine"; } }
            public ConsoleKey Key { get { return ConsoleKey.R; } }
            public string Suffix { get { return "R"; } }
            public bool IsRelative { get { return true; } }

            public double ToKelvin(double t)
            {
                return ((t - 491.67) / 1.8) + 273.15;
            }

            public double FromKelvin(double t)
            {
                return ((t - 273.15) * 1.8) + 491.67;
            }
        }

        public class Delisle : Temp
        {

            public string Name { get { return "Delisle"; } }
            public ConsoleKey Key { get { return ConsoleKey.D; } }
            public string Suffix { get { return "De"; } }
            public bool IsRelative { get { return true; } }

            public double ToKelvin(double t)
            {
                return (373.15 - (t * (2 / 3)));
            }

            public double FromKelvin(double t)
            {
                return (373.15 - t) * 1.5;
            }
        }

        public class Newton : Temp
        {

            public string Name { get { return "Newton"; } }
            public ConsoleKey Key { get { return ConsoleKey.N; } }
            public string Suffix { get { return "N"; } }
            public bool IsRelative { get { return true; } }

            public double ToKelvin(double t)
            {
                return (t * (100 / 33)) + 273.15;
            }

            public double FromKelvin(double t)
            {
                return (t - 273.15) * (33 / 100);
            }
        }

        public class Réaumur : Temp
        {
            public string Name { get { return "Réaumur"; } }
            public ConsoleKey Key { get { return ConsoleKey.O; } }
            public string Suffix { get { return "Re"; } }
            public bool IsRelative { get { return true; } }

            public double ToKelvin(double t)
            {
                return (t / 0.8) + 273.15;
            }

            public double FromKelvin(double t)
            {
                return (t - 273.15) * 0.8;
            }
        }

        public class Rømer : Temp
        {
            public string Name { get { return "Rømer "; } }
            public ConsoleKey Key { get { return ConsoleKey.E; } }
            public string Suffix { get { return "Ro"; } }
            public bool IsRelative { get { return true; } }

            public double ToKelvin(double ro)
            {
                return (ro - 7.5) * 40 / 21 + 273.15;
            }

            public double FromKelvin(double k)
            {
                return (k - 273.15) * 21 / 40 + 7.5;
            }
        }

    }
}
