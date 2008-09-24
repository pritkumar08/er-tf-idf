using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace Model
{
    public class RawWord
    {

        #region RawWord : Members & Consts

        public static char[] DELIMS = { ' ',',','.',';','/','\\','\t','\n','!',
                                        '|','@','#','(',')','<','>','`','\'','&'};
        private string m_Text = "";
        private int m_LocationID = 0;
        private double m_Weight = 0.0;

        #endregion

        #region RawWord : Initialization

        public RawWord()
        {
        }

        public RawWord(string text, int loc, double w)
        {
            this.m_Text = text;
            this.m_LocationID = loc;
            this.m_Weight = w;
        }

        #endregion

        #region RawWord : Properties
        public string Text
        {
            get{ return this.m_Text; }
            set{ this.m_Text = value; }
        }

        public int LocationID
        {
            get{ return this.m_LocationID; }
            set{ this.m_LocationID = value; }
        }

        public double Weight
        {
            get{ return this.m_Weight; }
            set{ this.m_Weight = value; }
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
            return m_Text.Equals(w.Text) && m_LocationID.Equals(w.LocationID) && m_Weight.Equals(w.Weight);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return m_Text.GetHashCode();
        }
        public override string ToString()
        {
            return m_Text + "," + m_LocationID + "," + m_Weight;
        }
    }

    public class Location
    {
        private string m_FileName;
        private int m_LocationID;
        private double m_Weight;

        public string FileName
        {
            get { return m_FileName; }
            set { m_FileName = value; }
        }

        public int LocationID
        {
            get { return m_LocationID; }
            set { m_LocationID = value; }
        }

        public double Weight
        {
            get { return m_Weight; }
            set { m_Weight = value; }
        }

        public override string ToString()
        {
            return m_FileName + "," + m_LocationID + "," + m_Weight;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Location other = obj as Location;
            return m_FileName.Equals(other.m_FileName) && m_LocationID.Equals(other.m_LocationID)
                && m_Weight.Equals(other.m_Weight);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return m_FileName.GetHashCode() + m_LocationID.GetHashCode() + m_Weight.GetHashCode();
        }
    }

    public class ProcessedWord
    {
        private string m_Word;
        private double m_Idf;
        private List<Location> m_Locations;

        public string Word
        {
            get { return m_Word; }
            set { m_Word = value; }
        }

        public double Idf
        {
            get { return m_Idf; }
            set { m_Idf = value; }
        }

        public List<Location> Locations
        {
            get { return m_Locations; }
            set { m_Locations = value; }
        }
        
        public override string ToString()
        {
            return m_Word + "," + m_Idf;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            ProcessedWord other = obj as ProcessedWord;
            return m_Word.Equals(other.m_Word) && m_Idf.Equals(other.m_Idf) &&
                Enumerable.Except(m_Locations, other.m_Locations).Count() == 0 &&
                Enumerable.Except(other.m_Locations, m_Locations).Count() == 0;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return m_Word.GetHashCode() + m_Idf.GetHashCode() + m_Locations.GetHashCode();
        }
    }

    public class BagWord
    {
        private string m_Word;
        private double m_TfIdf;

        public string Word
        {
            get { return m_Word; }
            set { m_Word = value; }
        }

        public double TfIdf
        {
            get { return m_TfIdf; }
            set { m_TfIdf = value; }
        }

        public override string ToString()
        {
            return m_Word + "," + m_TfIdf;
        }
        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return this.m_Word.Equals((obj as BagWord).m_Word);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.m_Word.GetHashCode();
        }
    }
}
