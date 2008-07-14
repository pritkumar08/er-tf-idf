using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IPersistentModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="path"></param>
        /// <param name="locationID"></param>
        /// <param name="weight"></param>
        void InsertWord(String word, String path, int locationID, double weight);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="path"></param>
        /// <param name="tf"></param>
        /// <param name="idf"></param>
        void InsertWordTFIDF(String word, String path, double tf, double idf);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        double GetTFByWordAndFile(String word, String path);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        double GetIDFByWordAndFile(String word, String path);

        // returns the total weight of word in the file describes in path
        double GetTotalWeight(string word, string path);

        // returns the total weight of all the words in the file describes in path
        double GetTotalWeights(string path);

        // returns the number of files contains word
        int CountFilesContains(string word);

        // return the number of files in the DB
        int FilesCount();

        List<Word> GetInversionList();

        void CleanDB();

        #region TestMethods

        bool WordAndFileExistTest(string word, string path, string tableName, out object[] result);

        void UpdateWordWeightTest(string tableName, string word, string path, int locationID, double weight, int counter);

        string GetWeightsTableNameTest(string word);

        #endregion


        
    }
}
