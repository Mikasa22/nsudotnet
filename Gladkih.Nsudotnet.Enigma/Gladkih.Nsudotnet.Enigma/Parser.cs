using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Gladkih.Nsudotnet.Enigma
{
    class Parser
    {
        public static JobTypes Parse(string[] args, out SymmetricAlgorithm algorithm, out string inFileName, out string outFileName, out string keyFileName)
        {
            if (4 != args.Length && 5 != args.Length)
            {
                throw new Exception("Incorrect number of parameters");
            }

            JobTypes result;
            if ("encrypt".Equals(args[0].ToLower()))
            {
                if (4 != args.Length)
                {
                    throw new Exception("Incorrect number of parameters");
                }
                result = JobTypes.Encrypt;
            }
            else if ("decrypt".Equals(args[0].ToLower()))
            {
                if (5 != args.Length)
                {
                    throw new Exception("Incorrect number of parameters");
                }
                result = JobTypes.Decrypt;
            }
            else
            {
                throw new Exception("The first parameter must be encrypt or decrypt");
            }

            if (!File.Exists(args[1]))
            {
                throw new Exception(String.Format("The file {0} does not exists", args[1]));
            }

            inFileName = args[1];
            algorithm = CryptographicAlgorithmFactory.Instance.GetAlgorithmByName(args[2]);
            if (JobTypes.Encrypt == result)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(Path.GetFileNameWithoutExtension(inFileName));
                builder.Append(".key");
                builder.Append(Path.GetExtension(inFileName));
                keyFileName = builder.ToString();
                outFileName = args[3];
            }
            else
            {
                keyFileName = args[3];
                outFileName = args[4];
            }

            return result;
        }
    }
}
