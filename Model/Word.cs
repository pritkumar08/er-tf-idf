using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Word
    {
        public Word(string text, int loc, double w)
        {
            Text = text;
            LocationID = loc;
            Weight = w;
        }
        public string Text{ get; set; }
        public int LocationID{ get; set; }
        public double Weight { get; set; }
    }
}
