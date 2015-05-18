using System;

namespace Gladkih.Nsudotnet.Perlin
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 1024;
            string fileName = "image.png";

            if (2 != args.Length)
            {
                Console.WriteLine("You did not specify the parameters.");
                Console.WriteLine("The result will be written to the {0} and the size of the image will be {1}", fileName, size);
            }
            else if (!Int32.TryParse(args[1], out size))
            {
                Console.WriteLine("You chose the wrong picture size, so the size of the image will be {0}", size);
            }
            else fileName = args[0];

            PerlinNoiseCreator creator = new PerlinNoiseCreator(size);
            creator.GetBitmap().Save(fileName);
        }
    }
}
