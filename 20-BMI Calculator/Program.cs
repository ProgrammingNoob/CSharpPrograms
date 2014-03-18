using System;

namespace ProgrammingNoob
{
    class Program
    {
        static void Main()
        {
            Console.Title = "BMI Calculator. 4CHAN /g/";

            double mass = 1;
            double height = 1;

            Console.WriteLine("Enter your mass (suffix accepted are (lb) pound and (kg) kilogram):");
            while (true)
            {
                string c = Console.ReadLine().ToLower();

                try
                {
                    if (c.EndsWith("kg"))
                    {
                        mass = Convert.ToDouble(c.Replace("kg", ""));

                        if (mass > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Mass cannot be less or equal to 0");
                        }
                    }
                    else if (c.EndsWith("lb"))
                    {
                        mass = Convert.ToDouble(c.Replace("lb", "")) / 2.2046;

                        if (mass > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Mass cannot be less or equal to 0");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid mass suffix, please try again");
                    }


                }
                catch (Exception)
                {
                    Console.WriteLine("Possible non numeric or very large number entered. Please try again");
                }
            }

            Console.WriteLine("Enter your height (suffix accepted are (m)eter and (in)ches):");
            while (true)
            {
                string c = Console.ReadLine().ToLower();

                try
                {
                    if (c.EndsWith("m"))
                    {
                        height = Convert.ToDouble(c.Replace("m", ""));

                        if (height > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Height cannot be less or equal to 0");
                        }
                    }
                    else if (c.EndsWith("in"))
                    {
                        height = Convert.ToDouble(c.Replace("in", "")) / 39.370;

                        if (height > 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Height cannot be less or equal to 0");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid height suffix, please try again");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Possible non numeric or very large number entered. Please try again");
                }
            }

            Console.WriteLine("Your BMI is: {0}", Math.Round(mass / Math.Pow(height, 2), 2));

            Console.ReadKey();
        }
    }
}
