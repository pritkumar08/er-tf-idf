using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    internal class PersistentModel : IPersistentModel
    {
         
        #region PersistentModel 

        #endregion

        #region Header : Initialization

            public PersistentModel()
            {
               
            }

        #endregion

        #region PersistentModel : Properties

        #endregion

        #region PersistentModel : Events

        #endregion

        #region PersistentModel : EventHandlers

        #endregion

        #region PersistentModel : Methods

            #region PersistentModel : Public Methods

                public void InsertWord(String word, String path, int locationID, double weight)
                {

                }

                void InsertFullWordDescription(String word, String path, double tf, double idf)
                {

                }

                Double GetTFByWordAndFile(String word, String path)
                {

                }

                Double GetIDFByWordAndFile(String word, String path)
                {

                }

            #endregion

            #region PersistentModel : Private Methods

                private void FillGeneralTable(string connectionString, String tableName, ref Dataset ds)
                {

                }

                private void FillDataSet(ref DataSet ds)
                {

                }

                private void UpdateGeneralTable(string connectionString, String tableName, ref Dataset ds)
                {

                }

            #endregion
    
        #endregion

    }
}
