using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Gladkih.Nsudotnet.Enigma
{
    class CryptographicAlgorithmFactory
    {
        private CryptographicAlgorithmFactory()
        {
            RegisterAlgorithm("aes", new AesCryptoServiceProvider());
            RegisterAlgorithm("des", new DESCryptoServiceProvider());
            RegisterAlgorithm("rc2", new RC2CryptoServiceProvider());
            RegisterAlgorithm("rijndael", new RijndaelManaged());
        }
        private static readonly object Locker = new object();
        private static volatile CryptographicAlgorithmFactory _instance;
        public static CryptographicAlgorithmFactory Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (Locker)
                    {
                        if (null == _instance)
                        {
                            _instance = new CryptographicAlgorithmFactory();
                        }
                    }
                }
                return _instance;
            }
        }

        private readonly Dictionary<string, SymmetricAlgorithm> _algorithms = new Dictionary<string, SymmetricAlgorithm>();
        public void RegisterAlgorithm(string algorithmName, SymmetricAlgorithm algorithm)
        {
            _algorithms.Add(algorithmName, algorithm);
        }
        public SymmetricAlgorithm GetAlgorithmByName(string algorithmName)
        {
            algorithmName = algorithmName.ToLower();
            SymmetricAlgorithm algorithm;

            if (!_algorithms.TryGetValue(algorithmName, out algorithm))
            {
                throw new Exception(String.Format("The algorithm {0} is not registered", algorithmName));
            }

            return algorithm;
        }

    }
}
