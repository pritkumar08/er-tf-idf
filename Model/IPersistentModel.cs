using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IPersistentModel
    {
        void InsertWord(String word, String path, int locationID, double weight);
        
        [Obsolete("tf is calculated instead of stored")]
        void InsertWordTF(String word, String path, double tf);
        
        [Obsolete("tf is calculated instead of stored")]
        double GetTFByWordAndFile(String word, String path);

        [Obsolete("idf is calculated instead of stored")]
        double GetIDFByWordAndFile(String word, String path);

        // returns the total weight of word in the file describes in path
        double GetTotalWeight(string word, string path);

        // returns the total weight of all the words in the file describes in path
        double GetTotalWeights(string path);

        // returns the number of files contains word with total_weight > 0
        int CountFilesContains(string word);

        // return the number of files in the DB
        int FilesCount();

        List<RawWord> getFileWords(string path);

        List<string> getWords();
        
        List<string> getFiles();
        
        List<Location> getWordLocations(string w);

        void CleanDB();

        #region TestMethods       

        void UpdateWordWeightTest(string tableName, string word, string path, int locationID, double weight, int counter);

        string GetWeightsTableNameTest(string word);

        #endregion

    }
}
