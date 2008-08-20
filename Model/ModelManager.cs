using System;
using System.Collections.Generic;
using System.Text;
using Stemming;

namespace Model
{
    public class ModelManager
    {
        #region ModelManager: Members & Consts

        private IPersistentModel persistent_model;
        private StemmerInterface si;

        #endregion

        #region ModelManager : Initialization

        public ModelManager()
        {
            persistent_model = PersistentModel.getInstance();
            si = new PorterStemmer();
        }

        #endregion

        #region ModelManager : Methods

            #region ModelManager : Public Methods
                public void InsertDocument(string path)
                    {            
                        ModelDocument d = XMLTranslator.ReadFromXML(path);
                        foreach(ModelParagraph p in d.Paragraphs)
                        {
                            foreach(Word word in p.getWords())
                            {
                                string norm_word = normalize(word.Text);
                                if(!string.IsNullOrEmpty(norm_word)) 
                                    persistent_model.InsertWord(norm_word, path, 
                                        word.LocationID, word.Weight);
                            }                
                        }            
                    }

                    public List<Word> GetInversionList()
                    {
                        return persistent_model.GetInversionList();
                        //table_Type1 X table_Type2
                    }

                    public double tf_idf(string word, string path)
                    {
                        // --- Calculating tf(word,path)
                        double n_word_in_path = persistent_model.GetTotalWeight(word, path);
                        //n(word,path) = 
                        //SELECT SUM(weight) FROM ?? WHERE word=word,file_path=path 
                        //GROUP BY word,file_path

                        double n_all_in_path = persistent_model.GetTotalWeights(path);
                        //n(all,path) = 
                        //SELECT SUM(weight) FROM ?? GROUP BY word,file_path

                        double tf_word = n_word_in_path / n_all_in_path;
                        //tf(word,path) = n(word,path)/n(all,path)

                        // --- Calculating idf(word)
                        int x = persistent_model.CountFilesContains(word);
                        //int x = SELECT COUNT(file_path) FROM ?? WHERE word=word,file_path=path,weight>0 
                        //GROUP BY file_path
                        int m = persistent_model.FilesCount();
                        //int m = SELECT COUNT(file_path) FROM ?? 
                        //GROUP BY file_path
                        double idf_word = Math.Log((double)m / x);
                        //idf(word) = log(m/x)

                        return tf_word * idf_word;
                    }

            #endregion

            #region ModelManager : Private Methods

            // if !StopList.contains(word) returns a normalized form of word 
            // else returns empty string
            private string normalize(string word)
            {
                if (ServiceRanking.StopWordsHandler.IsStopword(word))
                    return String.Empty;
                return si.stemTerm(word);
            }


            public ModelDocument OpenDocument(string path)
            {
                return XMLTranslator.ReadFromXML(path);
            }

            public void SaveDocument(string path, ModelDocument document)
            {
                XMLTranslator.WriteToXML(path, document);
            }

            public ModelDocument ImportDocument(string url)
            {
                string html = HTMLTranslator.GetHTMLFromSite(url);
                html = HTMLTranslator.StripHTML(html);
                return TranslateStripHTMLToDocument(html);
            }

            private ModelDocument TranslateStripHTMLToDocument(string html)
            {
                ModelDocument doc = new ModelDocument();
                int hIndex = -1;
                while ((hIndex = html.IndexOf("<h")) != -1)
                {
                    if ((html[hIndex + 2] < '0') || (html[hIndex + 2] > '9'))
                    {   
                        html = html.Remove(hIndex, html.IndexOf("</") - hIndex);
                        html = html.Remove(hIndex, html.IndexOf(">") - hIndex);
                        continue;
                    }
                    string body = html.Substring(0,hIndex-1);
                    ModelParagraph par = new ModelParagraph(body, 0, 1);
                    int titleWeight = int.Parse(html[hIndex + 2].ToString());
                    int hEndIndex = html.IndexOf("</h");
                    body = html.Substring(hIndex + 4, hEndIndex - hIndex - 4);
                    ModelHeader head = new ModelHeader(body, titleWeight);
                    par.AddNewElementToParagraph(head);
                    html = html.Remove(0, hEndIndex + 5);
                    doc.AddParagraph(par);
                }
                return doc;
            }

            #endregion

        #endregion

        }
    }
