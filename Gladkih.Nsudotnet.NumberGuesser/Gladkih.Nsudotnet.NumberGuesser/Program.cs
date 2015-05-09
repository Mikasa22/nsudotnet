using System;
using System.Collections.Generic;

namespace Gladkih.Nsudotnet.NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write your name:");
            string name = Console.ReadLine();

            Random rand = new Random();
            int number = rand.Next(100);

            string[] phrases = { "There's no way to guess that number, dear {0}!", 
                                 "{0} is a loser. {0} won't succeed.", 
                                 "Don't even try, it's too complicated for you, {0}.", 
                                 "You can't guess even a simple number, what you're actually capable of?" };

            List<string> attemptsList = new List<string>();

            DateTime start = DateTime.Now;
            while (true)
            {
                Console.WriteLine("Try to guess a number from 0 to 100:");
                string line = Console.ReadLine();
                if (null == line|| line.Contains("q"))
                {
                    Console.WriteLine("Oh, are you leaving already? Goodbye, {0}", name);
                    return;
                }

                int attempt;
                try
                {
                    attempt = int.Parse(line);
                }
                catch (Exception)
                {
                    Console.WriteLine("Write a number!");
                    continue;
                }

                
                if (attempt == number)
                {
                    TimeSpan spentTime = DateTime.Now - start;
                    Console.WriteLine("Number of tryes: {0}", attemptsList.Count);
                    foreach (string s in attemptsList)
                    {
                        Console.WriteLine(s);
                    }
                    Console.WriteLine("Spent time: {0}", spentTime);
                    return;
                }

                if (attempt < number)
                {
                    Console.WriteLine("{0} < guess number", attempt);
                    attemptsList.Add(String.Format(" {0} < {1}", attempt, number));
                }
                else
                {
                    Console.WriteLine("{0} > guess number", attempt);
                    attemptsList.Add(String.Format(" {0} > {1}", attempt, number));
                }

                if (0 == attemptsList.Count%4)
                {
                    Console.WriteLine(phrases[rand.Next(phrases.Length)], name);
                }
            }
        }
    }
}
