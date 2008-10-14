using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    [Serializable]
    public class WordsBags : ISerializable
    {
        private List<WordsBag> m_Bags = new List<WordsBag>();

        public List<WordsBag> Bags
        {
            get { return m_Bags; }
            set { m_Bags = value; }
        }

        public WordsBags(List<WordsBag> bags)
        {
            m_Bags = bags;
        }

        public WordsBags(SerializationInfo info, StreamingContext ctxt)
        {
            Bags = (List<WordsBag>)info.GetValue("Bags", typeof(List<WordsBag>));
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Bags", Bags);
        }

        #endregion
    }
}
