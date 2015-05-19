using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gladkih.Nsudotnet.Enigma
{
    [Serializable]
    class Setting
    {
        public byte[] Key { get; private set; }
        public byte[] IV { get; private set; }
        public Setting(byte[] key, byte[] IV)
        {
            Key = key;
            this.IV = IV;
        }
        
        public static Setting LoadSettings(string fileName)
        {
            Setting settings;

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                settings = (Setting)formatter.Deserialize(fs);
            }
            
            return settings;
        }
        public static void SaveSettings(string fileName, Setting settings)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, settings);
            }
        }
    }
}
