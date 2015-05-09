using System;
using System.IO;

namespace Gladkih.Nsudotnet.LinesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int result;

            switch (args.Length)
            {
                case 1:
                    result = LinesCounter.GetNumberOfLinesInDirectory(
                        Directory.GetCurrentDirectory(), 
                        args[0],
                        new CommentsTemplate());
                    break;
                case 4:
                    result = LinesCounter.GetNumberOfLinesInDirectory(
                        Directory.GetCurrentDirectory(),
                        args[0],
                        new CommentsTemplate(args[1], args[2], args[3]));
                    break;
                default:
                    Console.WriteLine("Wrong number of parameters!");
                    return;
            }

            Console.WriteLine("Number of lines == {0}", result);
        }

    }
}
