using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    internal interface IPersistentModel
    {
        void InsertWord(String word, String path, int locationID, double weight);

        void InsertFullWordDescription(String word, String path, double tf, double idf);

        Double GetTFByWordAndFile(String word, String path);

        Double GetIDFByWordAndFile(String word, String path);
    }
}
