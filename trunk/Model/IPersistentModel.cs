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
        void InsertNewWord(String word, String path, int locationID, double weight);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="path"></param>
        /// <param name="tf"></param>
        /// <param name="idf"></param>
        void InsertFullWordDescription(String word, String path, double tf, double idf);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        Double GetTFByWordAndFile(String word, String path);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        Double GetIDFByWordAndFile(String word, String path);
    }
}
