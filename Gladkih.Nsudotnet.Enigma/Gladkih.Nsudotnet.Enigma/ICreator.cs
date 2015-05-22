using System.Security.Cryptography;

namespace Gladkih.Nsudotnet.Enigma
{
    interface ICreator
    {
        SymmetricAlgorithm CreateCryptographicAlgorithm();
    }

    class AesCreator : ICreator
    {
        public SymmetricAlgorithm CreateCryptographicAlgorithm()
        {
            return new AesCryptoServiceProvider();
        }
    }

    class DesCreator : ICreator
    {
        public SymmetricAlgorithm CreateCryptographicAlgorithm()
        {
            return new DESCryptoServiceProvider();
        }
    }

    class Rc2Creator : ICreator
    {
        public SymmetricAlgorithm CreateCryptographicAlgorithm()
        {
            return new RC2CryptoServiceProvider();
        }
    }

    class RijndaelCreator : ICreator
    {
        public SymmetricAlgorithm CreateCryptographicAlgorithm()
        {
            return new RijndaelManaged();
        }
    }
}
