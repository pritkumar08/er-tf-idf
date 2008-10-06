using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Model
{
    [Serializable]
    public class WordsBag
    {
        public string Name;
        public List<BagWord> Bag;
        public WordsBag()
        {
            this.Bag = new List<BagWord>();
            this.Name = "";
        }
    }
}
