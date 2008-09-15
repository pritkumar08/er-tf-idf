using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Stemming;
using System.Text.RegularExpressions;
using System.IO;

namespace Model
{
    public class ModelManager
    {
        private static FileStream fs = new FileStream("output", FileMode.Append);
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

        /// <summary>
        /// a method to strictly read an XML file and construct 
        /// from it a ModelDocument object
        /// </summary>
        /// <param name="path">an XML file to read</param>
        /// <returns>a ModelDocument object represents the xml file</returns>
        public ModelDocument OpenDocument(string path)
        {
            return XMLTranslator.ReadFromXML(path);
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">path of XML file for writing</param>
        /// <param name="document">a ModelDocument object to read</param>
        public void SaveDocument(string path, ModelDocument document)
        {
            XMLTranslator.WriteToXML(path, document);
        }
        
        /// <summary>
        /// a method to convert an HTML file into ModelDocument object,
        /// trying to force the ModelDocument structure in the HTML file
        /// </summary>
        /// <param name="url"> for the HTML file to read</param>
        /// <returns>ModelDocument representing the HTML file cotnent</returns>
        public ModelDocument ImportDocument(string url)
        {
            throw new NotImplementedException();
            /*
            string html = HTMLTranslator.GetHTMLFromSite(url);
            html = HTMLTranslator.StripHTML(html);
            return TranslateStripHTMLToDocument(html);
             */
        }

        /// <summary>
        /// a method to insert an XML file content into the Database
        /// this method inserts the XML content after normalizing its content
        /// (the words - using stop list and word normalization)
        /// </summary>
        /// <param name="path"> XML file to read</param>
        public void InsertDocument(string path)
        {
            ModelDocument d = XMLTranslator.ReadFromXML(path);
            List<RawWord> words = d.getWords();
            List<RawWord> filtered = new List<RawWord>();
            foreach (RawWord w in words)
            {
                if (!(string.IsNullOrEmpty(normalize(w.Text))))
                {
                    w.Text = normalize(w.Text);
                    filtered.Add(w);
                }
            }
            /*
            IEnumerable<RawWord> words = from w in d.getWords()
                                         where
                                             (!((w.Text = normalize(w.Text)).Equals("")))
                                         select w;
             */
            double total_weights = filtered.Sum(w => w.weight);
            int counter = 0;            
            foreach (RawWord word in filtered)
            {
                /*
                byte[] str = System.Text.UnicodeEncoding.ASCII.GetBytes(
                    ("%progress:" + (double)counter / filtered.Count +
                    "  inserting word: " + word.text + "\n").ToCharArray());
                fs.Write(str, 0, str.Length);*/
                persistent_model.InsertWord(
                    word.Text, path, word.LocationID, word.Weight);
                counter++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> a list of word object - 
        /// each word contains (in addition to the word itself) its location,
        /// and the word's weight in that location</returns>
        public List<ProcessedWord> GetInversionList()
        {
            List<ProcessedWord> words = new List<ProcessedWord>();
            List<string> _ = persistent_model.getWords();
            double files_count = persistent_model.FilesCount();
            if (files_count > 0)
                foreach (string w in _)
                {
                    int wfc = persistent_model.CountFilesContains(w);
                    double idf = wfc > 0 ? Math.Log(files_count / wfc) : 0;
                    words.Add(new ProcessedWord() { 
                        word = w, 
                        locations = persistent_model.getWordLocations(w) ,
                        idf = idf
                    });                
                }
            return words;
        }

        /// <summary>
        /// direct calculating of the tf_idf funcion for a word in a file
        /// existing in the database
        /// </summary>
        /// <param name="word"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public double tf_idf(string word, string path)
        {
            // --- Calculating tf(word,path)                        
            //tf(word,path) = n(word,path)/n(all,path)
            double tf_word =
                persistent_model.GetTotalWeight(word, path) /
                persistent_model.GetTotalWeights(path);
            // --- Calculating idf(word)                        
            //idf(word) = log(m/x)
            double idf_word = Math.Log(
                (double)persistent_model.FilesCount() /
                persistent_model.CountFilesContains(word));
            return tf_word * idf_word;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">an already exist file that its content has been
        /// processed to the database</param>
        /// <returns>if file exists in the database - a new bag representing the file 
        /// content,otherwise an empty list</returns>
        public WordsBag getWordsBag(string path)
        {
            List<RawWord> words = persistent_model.getFileWords(path);
            WordsBag b = new WordsBag() { Name = path };
            if (words.Count > 0)
                b.Bag = createBag(words);
            return b;
        }       

        /// <summary>
        /// 
        /// </summary>
        /// <returns> a list of words bag - a bag for each file in the database
        /// empty files have an empty words bag</returns>
        public List<WordsBag> getWordsBag()
        {
            List<WordsBag> bags = new List<WordsBag>();
            List<string> files = persistent_model.getFiles();
            foreach (string path in files)
            {
                bags.Add(getWordsBag(path));
            }            
            return bags;
        }
        
        /// <summary>
        /// comparing a new well-formed xml file (according to the system's DTD)
        /// to all other files in the database.        
        /// </summary>
        /// <param name="path"></param>
        /// <param name="f">an inner product function pointer to evaluate the 
        /// similarity between two bags of words</param>
        /// <returns>a vector with all non-zero similarities between the new file 
        /// and the rest of the database</returns>
        public List<Record<string, double>> tagNewFile(string path, 
            Func<WordsBag,WordsBag, double> f)
        {
            List<Record<string, double>> result = new List<Record<string, double>>();
            WordsBag new_bag = createWordsBag(path);            
            foreach (WordsBag bag in this.getWordsBag())
            {
                double res = f(new_bag, bag);
                if (res > 0) result.Add(new Record<string, double> { 
                                            first = bag.Name, second = res });
            }
            return result;
        }

       

        #endregion // Public Mehtods

        #region ModelManager : Private Methods

        /// <summary>
        /// if !StopList.contains(word) returns a normalized form of word 
        /// else returns empty string
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private string normalize(string word)
        {
            if (ServiceRanking.StopWordsHandler.stopWordsList.Contains(word))
                return String.Empty;
            string w = si.stemTerm(word);
            //w = Regex.Escape(w);// Replace(w, @"\W", "'&'");
            w = Regex.Replace(w, @"\W", "");
            return w;
        }

        /// <summary>
        /// translating a stripped HTML document into a ModelDocument object,
        /// trying to force the ModelDocument structure over the HTML doc
        /// </summary>
        /// <param name="html">a string representing the stripped HTML document content</param>
        /// <returns></returns>
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
                string body = html.Substring(0, hIndex - 1);
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

        /// <summary>
        /// creating a new words bag for a file not included in the database.
        /// all the idf values are taken according the current information in the database.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>a list of bagWord representing all non-stop-words upper-cased
        /// <paramref name="path"/> and in normalized form</returns>
        private WordsBag createWordsBag(string path)
        {
            List<RawWord> filtered = new List<RawWord>();
            foreach (RawWord w in XMLTranslator.ReadFromXML(path).getWords())
            {
                if (!(string.IsNullOrEmpty(normalize(w.Text))))
                {
                    w.Text = normalize(w.Text).ToUpper();
                    filtered.Add(w);
                }
            }
            WordsBag b = new WordsBag() { Name = path };
            if (filtered.Count > 0) b.Bag = createBag(filtered);
            return b;
        }

        /// <summary>
        /// creates a new bag,each word in the bag has it tf-idf value
        /// according the database
        /// </summary>
        /// <param name="words"></param>
        /// <returns>a bag for a given list of raw words</returns>
        private List<BagWord> createBag(List<RawWord> words)
        {
            List<BagWord> bag = new List<BagWord>();
            double total_weight = words.Sum(w => w.Weight);
            double files_count = (double)persistent_model.FilesCount();
            var wordGroups = from x in
                                 (from w in words
                                  group w by w.Text into g
                                  select new { Text = g.Key, Locations = g })
                             select new { Text = x.Text, Weight = x.Locations.Sum(w => w.Weight) };

            foreach (var g in wordGroups)
            {
                double tf = g.Weight / total_weight;
                double idf = 0;
                int c = persistent_model.CountFilesContains(g.Text);
                if (c > 0)
                    idf = Math.Log((double)files_count / c);
                bag.Add(new BagWord { word = g.Text, tf_idf = tf * idf });
            }
            return bag;
        }

        #endregion // Private Mehtods

        #endregion // Methods

    }
}
