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

            string argJobType = args[0];
            string argInFileName = args[1];
            string argAlgorithmName = args[2];
            string argKeyFileName = null;
            string argOutFileName;

            JobTypes result;
            if ("encrypt".Equals(argJobType.ToLower()))
            {
                if (4 != args.Length)
                {
                    throw new Exception("Incorrect number of parameters");
                }
                result = JobTypes.Encrypt;
                argOutFileName = args[3];
            }
            else if ("decrypt".Equals(argJobType.ToLower()))
            {
                if (5 != args.Length)
                {
                    throw new Exception("Incorrect number of parameters");
                }
                result = JobTypes.Decrypt;
                argKeyFileName = args[3];
                argOutFileName = args[4];
            }
            else
            {
                throw new Exception("The first parameter must be encrypt or decrypt");
            }

            if (!File.Exists(argInFileName))
            {
                throw new Exception(String.Format("The file {0} does not exists", argInFileName));
            }

            inFileName = argInFileName;
            algorithm = CryptographicAlgorithmFactory.Instance.GetAlgorithmByName(argAlgorithmName);
            if (JobTypes.Encrypt == result)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(Path.GetFileNameWithoutExtension(argInFileName));
                builder.Append(".key");
                builder.Append(Path.GetExtension(argInFileName));
                keyFileName = builder.ToString();
                outFileName = argOutFileName;
            }
            else
            {
                keyFileName = argKeyFileName;
                outFileName = argOutFileName;
            }

            return result;
        }
    }
}
