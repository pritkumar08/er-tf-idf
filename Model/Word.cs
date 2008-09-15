using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class RawWord
    {

        #region RawWord : Members & Consts

        public static char[] DELIMS = { ' ',',','.',';','/','\\','\t','\n','!',
                                        '|','@','#','(',')','<','>','`','\'','&'};
        public string text = "";
        public int locationID = 0;
        public double weight = 0.0;

        #endregion

        #region RawWord : Initialization

        public RawWord()
        {
        }

        public RawWord(string text, int loc, double w)
        {
            this.text = text;
            this.locationID = loc;
            this.weight = w;
        }

        #endregion

        #region RawWord : Properties
        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
            }
        }

        public int LocationID
        {
            get
            {
                return this.locationID;
            }
            set
            {
                this.locationID = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }
        #endregion

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            RawWord w = obj as RawWord;
            return text.Equals(w.Text) && locationID.Equals(w.LocationID) && weight.Equals(w.Weight);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return text.GetHashCode();
        }
        public override string ToString()
        {
            return text + "," + locationID + "," + weight;
        }
    }

    public class Location
    {
        public string fileName;
        public int locationID;
        public double weight;
        public override string ToString()
        {
            return fileName + "," + locationID + "," + weight;
        }
    }

    public class ProcessedWord
    {
        public string word;
        public double idf;
        public List<Location> locations;
        public override string ToString()
        {
            return word + "," + idf;
        }
    }

    public class BagWord
    {
        public string word;
        public double tf_idf;
        public override string ToString()
        {
            return word + "," + tf_idf;
        }
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return this.word.Equals((obj as BagWord).word);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.word.GetHashCode();
        }
    }
}
