using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Gladkih.Nsudotnet.Enigma
{
    class CryptographicAlgorithmFactory
    {
        private CryptographicAlgorithmFactory()
        {
            RegisterAlgorithm("aes", new AesCreator());
            RegisterAlgorithm("des", new DesCreator());
            RegisterAlgorithm("rc2", new Rc2Creator());
            RegisterAlgorithm("rijndael", new RijndaelCreator());
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

        private readonly Dictionary<string, ICreator> _algorithms = new Dictionary<string, ICreator>();
        public void RegisterAlgorithm(string algorithmName, ICreator creator)
        {
            _algorithms.Add(algorithmName, creator);
        }
        public SymmetricAlgorithm GetAlgorithmByName(string algorithmName)
        {
            algorithmName = algorithmName.ToLower();
            ICreator creator;

            if (!_algorithms.TryGetValue(algorithmName, out creator))
            {
                throw new Exception(String.Format("The algorithm {0} is not registered", algorithmName));
            }

            return creator.CreateCryptographicAlgorithm();
        }
    }
}
