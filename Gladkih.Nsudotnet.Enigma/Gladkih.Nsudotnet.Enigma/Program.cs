using System.Security.Cryptography;

namespace Gladkih.Nsudotnet.Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            SymmetricAlgorithm algorithm;
            string inFileName;
            string outFileName;
            string keyFileName;

            if (JobTypes.Encrypt == Parser.Parse(args, out algorithm, out inFileName, out outFileName, out keyFileName))
            {
                Cryptographer.Encrypt(algorithm, inFileName, outFileName, keyFileName);
            }
            else
            {
                Cryptographer.Decrypt(algorithm, inFileName, outFileName, keyFileName);
            }
        }
    }
}
