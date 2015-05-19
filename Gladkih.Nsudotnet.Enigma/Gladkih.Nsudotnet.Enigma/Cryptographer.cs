using System.IO;
using System.Security.Cryptography;

namespace Gladkih.Nsudotnet.Enigma
{
    class Cryptographer
    {
        public static void Encrypt( SymmetricAlgorithm algorithm, string inFileName, string outFileName, string keyFileName)
        {
            using (Stream inputStream = new FileStream(inFileName, FileMode.Open, FileAccess.Read))
            {
                using (Stream outputStream = new FileStream(outFileName, FileMode.Create, FileAccess.Write))
                {
                    algorithm.GenerateIV();
                    algorithm.GenerateKey();

                    ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);
                    using (CryptoStream cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                    {
                        inputStream.CopyTo(cryptoStream);
                    }

                    Setting.SaveSettings(keyFileName, new Setting(algorithm.Key, algorithm.IV));
                }
            }
        }
        public static void Decrypt( SymmetricAlgorithm algorithm, string inFileName, string outFileName, string keyFileName)
        {
            using (Stream inputStream = new FileStream(inFileName, FileMode.Open, FileAccess.Read))
            {
                using (Stream outputStream = new FileStream(outFileName, FileMode.Create, FileAccess.Write))
                {
                    Setting setting = Setting.LoadSettings(keyFileName);

                    ICryptoTransform decryptor = algorithm.CreateDecryptor(setting.Key, setting.IV);

                    using (CryptoStream cryptoStream = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read))
                    {
                        cryptoStream.CopyTo(outputStream);
                    }
                }
            }
        }
    }
}
