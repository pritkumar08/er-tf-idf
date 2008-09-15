using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
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
