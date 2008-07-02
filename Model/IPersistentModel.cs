using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    internal interface IPersistentModel
    {
         void InsertWord(String word, String path, int locationID, double weight);
    }
}
