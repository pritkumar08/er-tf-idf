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
        #region ModelManager: Members & Consts

        private IPersistentModel persistent_model;
        private StemmerInterface si;
        private Double total_square_sum = -1;
        private WordsBags m_WordsBags = null;

        public WordsBags WordsBags
        {
            get { return m_WordsBags; }
            set { m_WordsBags = value; }
        }

        #endregion

        #region ModelManager : Initialization

        public ModelManager()
        {           
            persistent_model = DataSetPersistentModel.getInstance();
            m_WordsBags = Serializer.Deserialize();
            si = new PorterStemmer();
        }

        #endregion

        #region ModelManager : Enum

            public enum SimilarityType
            {
                None = 0, 
                L2_Norm = 1,
                Min_Value = 2
            }

            public enum SearchEngine
            {
                None = 0, 
                Google = 1
            }

            public enum SortingMethod
            {
                None = 0,
                Maximum = 1,
                Summary = 2
            };

        #endregion

        #region ModelManager : Methods

        #region ModelManager : Public Methods

        /// <summary>
        /// a method to insert an XML file content into the Database.
        /// this method inserts the XML content after normalizing its content
        /// (the words - using stop list and word normalization), i.e the
        /// database holds information only on the normalized form of each word
        /// </summary>
        /// <param name="path"> XML file to read</param>
        public void InsertDocument(string path)
        {
            ModelDocument d = XMLTranslator.ReadFromXML(path);
            InsertDocument_aux(path, d);
        }

        /// <summary>
        /// almost the same functionality as InsertDocument,except that 
        /// the XML file hasn't been created yet 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="doc"></param>
        public void InsertNewDocumentToDatabase(string fileName, ModelDocument doc)
        {
            SaveDocument(fileName, doc);
            InsertDocument_aux(fileName, doc);
        }

        /// <summary>
        /// Stores a ModelDocument object as an XML file
        /// </summary>
        /// <param name="path">path of XML file for writing</param>
        /// <param name="document">a ModelDocument object to read</param>
        public void SaveDocument(string path, ModelDocument document)
        {
            XMLTranslator.WriteToXML(path, document);
        }

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
        /// generates a ModelDocument object from content of the given url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ModelDocument ImportDocument(string url)
        {
            string html = HTMLTranslator.GetHTMLFromSite(url);
            //html = HTMLTranslator.StripHTML(html);
            //return TranslateStripHTMLToDocument(html);
            if (html != null)
                return TranslateHTMLToDocument(html);
            return null; 
        }

        public LinkedList<ModelGoogleSearchResult> SearchWeb(string label)
        {
            return GoogleSearch.PerformGoogleSearch(label);
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
                        Word = w, 
                        Locations = persistent_model.getWordLocations(w) ,
                        Idf = idf
                    });                
                }
            return words;
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
        /// <returns>a vector with all non-zero similarities values between the new file 
        /// and the rest of the database</returns>
        public List<Record<string, double>> evaluateSimilarity(string path, 
            Func<WordsBag,WordsBag, double> f)
        {
            WordsBag new_bag = createWordsBag(path);
            return evaluateSimilarity_aux(new_bag, f);
        }

        /// <summary>
        /// comparing a new well-formed xml file (according to the system's DTD)
        /// to all other files in the database.        
        /// </summary>
        /// <param name="path"></param>
        /// <param name="f">an inner product function pointer to evaluate the 
        /// similarity between two bags of words</param>
        /// <returns>a vector with all non-zero similarities values between the new file 
        /// and the rest of the database</returns>
        public List<Record<string, double>> evaluateSimilarity(ModelDocument doc,
            Func<WordsBag, WordsBag, double> f)
        {            
            WordsBag new_bag = createWordsBag(doc);
            return evaluateSimilarity_aux(new_bag, f);
        }

        private List<Record<string, double>> evaluateSimilarity_aux(WordsBag new_bag, Func<WordsBag, WordsBag, double> f)
        {
            if (new_bag == null || m_WordsBags == null)
                return null;
            List<Record<string, double>> result = new List<Record<string, double>>();
            foreach (WordsBag bag in m_WordsBags.Bags)
            {
                double res = f(new_bag, bag);
                if (res > 0) result.Add(new Record<string, double>
                {
                    first = bag.Name,
                    second = res
                });
            }
            return result;
        }

        /// <summary>
        /// creating a new words bag for a file not included in the database.
        /// all the idf values are taken according the current information in the database.
        /// </summary>
        /// <param name="path">an existing XML file name</param>
        /// <returns>a list of bagWord representing all non-stop-words upper-cased
        /// <paramref name="path"/> and in normalized form</returns>
        private WordsBag createWordsBag(string path)
        {
            return createWordsBag(XMLTranslator.ReadFromXML(path));
        }

        /// <summary>
        /// same as <code>createWordsBag(string)</code> but gets directly 
        /// the <code>ModelDocument</code> object as a paramenter
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private WordsBag createWordsBag(ModelDocument doc)
        {
            if (doc == null)
                return null;
            List<RawWord> filtered = new List<RawWord>();
            foreach (RawWord w in doc.getWords())
            {
                if (!(string.IsNullOrEmpty(normalize(w.Text))))
                {
                    w.Text = normalize(w.Text).ToUpper();
                    filtered.Add(w);
                }
            }
            WordsBag b = new WordsBag() { Name = doc.Title };
            if (filtered.Count > 0) b.Bag = createBag(filtered);
            return b;

        }

        /// <summary>
        /// computing the similarity vector using the L2 norm as the similarity
        /// function between two bag of words,i.e:
        /// f(b1,b2) = sigma(b1i.tf_idf*b2i.tf_idf)/sum_of_all_squares
        /// </summary>
        /// <param name="path">an existing XML file name</param>
        /// <returns></returns>
        public List<Record<string, double>> L2NormSimilarity(string path)
        {
            double squares_sum = this.getTotalSquaresSum();
            return evaluateSimilarity(path, generateSimilarityFunction(
                (x, y) => x*y / squares_sum));
        }

        /// <summary>
        /// same as <code>L2NormSimilarity(string path)</code> but gets directly the 
        /// <code>ModelDocument</code> object as parameter
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public List<Record<string, double>> L2NormSimilarity(ModelDocument doc)
        {
            double squares_sum = this.getTotalSquaresSum();
            return evaluateSimilarity(doc, generateSimilarityFunction(
                (x, y) => x * y / squares_sum));
        }

        /// <summary>
        /// computing the similarity vector using the min value as the similarity
        /// function between two bag of words,i.e:
        /// f(b1,b2) = sigma(min(b1i.tf_idf,b2i.tf_idf))/sum_of_all_squares
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<Record<string, double>> minValSimilarity(string path)
        {
            double squares_sum = this.getTotalSquaresSum();
            return evaluateSimilarity(path, generateSimilarityFunction(
                (x, y) => Math.Min(x, y) / squares_sum));
        }

        /// <summary>
        /// same as <code>minValSimilarity(string path)</code> but gets directly the 
        /// <code>ModelDocument</code> object as parameter
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public List<Record<string, double>> minValSimilarity(ModelDocument doc)
        {
            double squares_sum = this.getTotalSquaresSum();
            return evaluateSimilarity(doc, generateSimilarityFunction(
                (x, y) => Math.Min(x, y) / squares_sum));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> ImportCacheData()
        {
            return CacheSearch.CacheWebAddresses();
        }

        /// <summary>
        /// retrieves all the words in the system's DB
        /// </summary>
        /// <returns></returns>
        public List<string> getWords()
        {
            return persistent_model.getWords();
        }
        /// <summary>
        /// 
        /// </summary>
        public void CreateCacheDatabase()
        {
            Dictionary<string, string> cacheLinks = CacheSearch.CacheWebAddresses();
            foreach (string link in cacheLinks.Keys)
            {
                ModelDocument doc = ImportDocument(link);
                if (doc != null)
                {
                    doc.Title = cacheLinks[link];
                    InsertDocument_aux(link, doc);
                }
            }
            m_WordsBags = new WordsBags(getWordsBag());
            Serializer.Serialize(m_WordsBags);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="engine"></param>
        /// <param name="pagesNumber"></param>
        /// <returns></returns>
        public LinkedList<ModelGoogleSearchResult> CheckSimilarity(string searchLabel, SimilarityType type, SearchEngine engine, int pagesNumber, SortingMethod method)
        {
            switch (engine)
            {
                case SearchEngine.Google:
                    return new LinkedList<ModelGoogleSearchResult>(
                        CheckGoogleSimilarity(searchLabel, type, pagesNumber, method));
                default:
                    return null;
            }
        }


        /// <summary>
        /// Deletes all DB content
        /// </summary>
        public void CleanDB()
        {
            persistent_model.CleanDB();
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

        public bool IsDBEmpty()
        {
            return m_WordsBags == null;
        }

        #endregion // Public Mehtods

        #region ModelManager : Private Methods

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
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private ModelDocument TranslateHTMLToDocument(string html)
        {
            ModelDocument doc = new ModelDocument();
            bool header = false, addPar = false;
            int parId = 1;
            try
            {
                ModelParagraph par = null;
                for (int i = 0; i < html.Length; i++)
                {
                    if ((html[i] == '<') && (html[i + 1] == 'h') && (html[i + 2] >= '0') && (html[i + 2] <= '9'))
                    {
                        par = new ModelParagraph("", parId, 1);
                        header = true;
                        int j = i + 4;
                        string body = GetHeaderTextTillTagStarts(html, ref j);
                        int titleWeight = int.Parse(html[i + 2].ToString());
                        ModelHeader head = new ModelHeader(body, titleWeight);
                        par.AddNewElementToParagraph(head);
                        i = j;
                        addPar = true;
                    }
                    if ((html[i] == '>'))
                    {
                        int j = i + 1;
                        if (isPlainText(j, html))
                        {
                            string body = GetTextTillTagStarts(html, ref j);
                            if (header)
                            {
                                ModelParagraph par2 = new ModelParagraph(body, parId, 1);
                                par.AddNewElementToParagraph(par2);
                                header = false;
                            }
                            else
                            {
                                par = new ModelParagraph(body, parId, 1);
                            }
                            i = j - 1;
                            addPar = true;
                        }

                    }
                    if (addPar)
                    {
                        doc.AddParagraph(par);
                        parId++;
                        addPar = false;
                    }
                }
                return doc;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private string GetTextTillTagStarts(string html, ref int j)
        {
            j--;
            string str = "";
            try
            {

                for (; j < html.Length; j++)
                {
                    if ((html[j] == '<') && (html[j + 1] == 'h') && (html[j + 2] >= '0') && (html[j + 2] <= '9'))
                        return str;
                    if ((html[j] == '>'))
                    {
                        string s = "";
                        while (((html[j] != '<') && (html[j] != '{')))
                        {
                            if (j >= html.Length)
                                return str;
                            if (isPlainText(j, html))
                                if (html[j] == '>')
                                    s = "";
                                else
                                    s += html[j];
                            j++;
                        }
                        j--;
                        if (s != "")
                            str = str + "\n" + s;
                    }
                }
                return str;
            }
            catch
            {
                return str;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="html"></param>
        /// <returns></returns>
        private bool isPlainText(int j, string html)
        {
            if ((html[j] == '\r') || (html[j] == '\t') || (html[j] == '\n') || (html[j] == '<'))
                return false;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private string GetHeaderTextTillTagStarts(string html, ref int j)
        {
            string str = "";
            for (; j < html.Length; j++)
            {
                if ((html[j] != '<') && (html[j] != '{'))
                {
                    if (isPlainText(j, html))
                        if (html[j] == '>')
                            str = "";
                        else
                            str = str + html[j];
                }
                else
                    break;
            }
            return str;
        }

        /// <summary>
        /// inserts the file's contetnt (the d parameter) into the database
        /// </summary>
        /// <param name="path"></param>
        /// <param name="d">the file's (raw) content</param>
        private void InsertDocument_aux(string path, ModelDocument d)
        {
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
            double total_weights = filtered.Sum(w => w.Weight);
            foreach (RawWord word in filtered)
            {
                persistent_model.InsertWord(
                    word.Text, path, word.LocationID, word.Weight);
            }
            persistent_model.UpdateDB();
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
            var wordgroups = from x in
                                 (from w in words
                                  group w by w.Text into g
                                  select new { text = g.Key, locations = g })
                             select new { text = x.text, weight = x.locations.Sum(w => w.Weight) };
            foreach (var g in wordgroups)
            {
                double tf = g.weight / total_weight;
                double idf = 0;
                int c = persistent_model.CountFilesContains(g.text);
                if (c > 0)
                    idf = Math.Log((double)files_count / c);
                bag.Add(new BagWord { Word = g.text, TfIdf = tf * idf });
            }
            return bag;
        }

        /// <summary>
        /// generates the inner-product function pointer 
        /// </summary>
        /// <param name="f">the o operation between two elements in the inner-product
        /// e.g (1)f(x,y) = x*y ,(2) f(x,y) = x*y/sqrt(x^2+y^2)</param>
        /// <returns></returns>
        private Func<WordsBag, WordsBag, double> generateSimilarityFunction(
            Func<double, double, double> f)
        {
            return (b1, b2) =>
            (
                from w1 in b1.Bag
                from w2 in b2.Bag
                where w1.Word.Equals(w2.Word)
                select f(w1.TfIdf, w2.TfIdf)
            ).Sum(x => x);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>the total square sum of all the tf-ifds in the system,i.e
        /// sum for each words bag represents a file sums all tf-idf^2</returns>
        private double getTotalSquaresSum()
        {
            if (total_square_sum != -1) return total_square_sum;
            List<WordsBag> tb = this.getWordsBag();
            total_square_sum = (from b in tb select b.Bag.Sum(x => Math.Pow(x.TfIdf, 2))).Sum();
            return total_square_sum;
        }

        /// <summary>
        /// if !StopList.contains(word) returns a normalized form of word 
        /// else returns an empty string
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
        /// 
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        private Record<string, double> GetMaxRecord(List<Record<string, double>> records)
        {
            if (records == null)
                return null;
            Record<string, double> maxRec = new Record<string,double>();
            maxRec.second = -1;
            foreach(Record<string, double> rec in records)
            {
                if (rec.second > maxRec.second)
                {
                    maxRec = rec;
                }
            }
            return maxRec;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pagesNumber"></param>
        /// <returns></returns>
        private LinkedList<ModelGoogleSearchResult> CheckGoogleSimilarity(
            string searchLabel, SimilarityType type, int pagesNumber,SortingMethod method)
        {
            int pages = 0;
            LinkedList<ModelGoogleSearchResult> originalResults = SearchWeb(searchLabel);
            Dictionary<ModelGoogleSearchResult, double> highestResults = 
                new Dictionary<ModelGoogleSearchResult, double>();
            foreach (ModelGoogleSearchResult result in originalResults)
            {
                if (pages >= pagesNumber)
                    break;
                ModelDocument doc = ImportDocument(result.URL);
                if (doc == null)
                    continue;
                double similarity = 0.0;
                List<Record<string, double>> l = new List<Record<string,double>>();
                switch (type)
                {
                    case SimilarityType.L2_Norm:
                        l= L2NormSimilarity(doc);
                        break;
                    case SimilarityType.Min_Value:
                        l = minValSimilarity(doc);
                        break;
                }
                if (method.Equals(SortingMethod.Maximum) && l.Count > 0)
                    similarity = (from r in l select r.second).Max();
                else if (method.Equals(SortingMethod.Summary) && l.Count > 0)
                    similarity = (from r in l select r.second).Sum();
                highestResults.Add(result, similarity);
                pages++;
            }
            IOrderedEnumerable<KeyValuePair<ModelGoogleSearchResult,double>> ordered =
                highestResults.OrderByDescending(x => x.Value);
            
            return OrderedSimilarityResults(highestResults);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="highestResults"></param>
        /// <returns></returns>
        private LinkedList<ModelGoogleSearchResult> OrderedSimilarityResults(
            Dictionary<ModelGoogleSearchResult, double> highestResults)
        {
            if (highestResults == null)
                return null;
            LinkedList<ModelGoogleSearchResult> orderedResults = new LinkedList<ModelGoogleSearchResult>();
            foreach (ModelGoogleSearchResult res1 in highestResults.Keys)
            {
                orderedResults.AddFirst(res1);
                break;
            }
            foreach (ModelGoogleSearchResult res1 in highestResults.Keys)
            {
                foreach (ModelGoogleSearchResult res2 in orderedResults)
                {
                    if ((res1 != res2) && (highestResults[res1] <= highestResults[res2]))
                    {
                        orderedResults.AddBefore(orderedResults.Find(res2), res1);
                        break;
                    }
                }
            }
            return orderedResults;
        }

        #endregion // Private Mehtods
   
        #endregion // Methods

    }
}
