using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ModelManager
    {
        private IPersistentModel persistent_model;

        public ModelManager()
        {
            persistent_model = new PersistentModel();
        }

        public void InsertDocument(string path)
        {
            Document d = XMLTranslator.ReadFromXML(path);
            foreach(Paragraph p in d.Paragraphs.Values)
            {
                foreach(Word word in p.getWords())
                {
                    persistent_model.InsertWord(normalize(word.Text), path, 
                        word.LocationID, word.Weight);
                }                
            }
        }

        private string normalize(string p)
        {
            return p;
        }

        public double tf_idf(string word,string path)
        {
            return 0;
            // --- Calculating tf(word,path)
            //n(word,path) = 
            //SELECT SUM(weight) FROM ?? WHERE word=word,file_path=path 
            //GROUP BY word,file_path
            //n(all,path) = 
            //SELECT SUM(weight) FROM ?? GROUP BY word,file_path
            //tf(word,path) = n(word,path)/n(all,path)

            // --- Calculating idf(word)
            //int x = SELECT COUNT(file_path) FROM ?? WHERE word=word,file_path=path,weight>0 
            //GROUP BY file_path
            //int m = SELECT COUNT(file_path) FROM ?? 
            //GROUP BY file_path
            //idf(word) = log(m/x)

            // return tf(word,path)*idf(word)
        }

    }
}
