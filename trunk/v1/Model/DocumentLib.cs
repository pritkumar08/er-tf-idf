using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Model
{
    internal static class DocumentLib
    {
        /*
         * return the parIDs from d which include word 
         */
        public static Collection<int> findParagraph(Document d, string word)
        {
            List<int> pars = new List<int>();
            foreach (Paragraph p in d.Paragraphs)
                if (p.Contains(word))
                    pars.Add(p.pID);            
            return pars;
        }
    }
}
