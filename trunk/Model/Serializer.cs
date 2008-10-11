using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Model
{
    public static class Serializer
    {
        /// <summary>
        /// 
        /// </summary>
        private const string file_name = "info.ser";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bags"></param>
        public static void Serialize(WordsBags bags)
        {
            Stream stream = File.Open(file_name, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, bags);
            stream.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static WordsBags Deserialize()
        {
            try
            {
                WordsBags bags = null;
                Stream stream = File.Open(file_name, FileMode.Open);
                BinaryFormatter bformatter = new BinaryFormatter();
                bags = (WordsBags)bformatter.Deserialize(stream);
                stream.Close();
                return bags;
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
