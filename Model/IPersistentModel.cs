using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// General interface for each Persistent model implementation
    /// </summary>
    public interface IPersistentModel
    {   
        /// <summary>
        /// Deletes all DB content
        /// </summary>   
        void CleanDB();

        /// <summary>
        /// commits all changes to the DB
        /// </summary>
        void UpdateDB();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="path"></param>
        /// <param name="locationID"></param>
        /// <param name="weight"></param>
        void InsertWord(String word, String path, int locationID, double weight);
                
        /// <summary>
        /// returns the total weight of word in the file describes in path
        /// </summary>
        /// <param name="word"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        double GetTotalWeight(string word, string path);

        /// <summary>
        /// returns the total weight of all the words in the file describes in path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        double GetTotalWeights(string path);

        /// <summary>
        /// returns the number of files contains word with total_weight > 0
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        int CountFilesContains(string word);

        /// <summary>
        /// returns the number of files in the DB
        /// </summary>
        /// <returns></returns>
        int FilesCount();

        /// <summary>
        /// returns all words in the specified file as a list of <code>RawWord</code> 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        List<RawWord> getFileWords(string path);

        /// <summary>
        /// a list of locations (location = file name,location id and the weight 
        /// of the word in that location) of a given word
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        List<Location> getWordLocations(string w);

        /// <summary>
        /// all the words (notice: normalized form !) in the database
        /// </summary>
        /// <returns></returns>
        List<string> getWords();
        
        /// <summary>
        /// all file names in the database
        /// </summary>
        /// <returns></returns>
        List<string> getFiles();
        
        #region Obsolete Methods

        [Obsolete("tf is calculated instead of stored")]
        void InsertWordTF(String word, String path, double tf);

        [Obsolete("tf is calculated instead of stored")]
        double GetTFByWordAndFile(String word, String path);

        [Obsolete("idf is calculated instead of stored")]
        double GetIDFByWordAndFile(String word, String path);

        #endregion

        #region TestMethods

        void UpdateWordWeightTest(string tableName, string word, string path, int locationID, double weight, int counter);

        string GetWeightsTableNameTest(string word);

        #endregion

    }
}
