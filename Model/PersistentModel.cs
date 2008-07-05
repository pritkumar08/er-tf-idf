using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;


namespace Model
{
    public class PersistentModel : IPersistentModel
    {
         
        #region PersistentModel : Members & Consts

            private OleDbConnection connection;
            //private OleDbDataAdapter adapter;
            //private PersistentDataSet dataset;

            private const String connectionString = 
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\ModelDatabase.mdb";

        #endregion

        #region PersistentModel : Initialization

            public PersistentModel()
            {
                connection = new OleDbConnection(connectionString);
                //adapter = new OleDbDataAdapter();
                //dataset = new PersistentDataSet();
            }

        #endregion

        #region PersistentModel : Enums
            /// <summary>
            /// 
            /// </summary>
            private enum Segments
            {
                A_D = 0,
                E_G = 1,
                H_L = 2,
                M_O = 3,
                P_S = 4,
                T_Z = 5,
                None = 6
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

            public void InsertNewWord(String word, String path, int locationID, double weight)
            {
                try
                {
                    char firstLetter = word.ToUpper().ToCharArray()[0];
                    string query = "INSERT INTO " + firstLetter
                                   + "_LETTER (Work,FileName,Place,Weight) VALUES ('"
                                   + word.ToUpper() + "','" + path + "',"
                                   + locationID + "," + weight + ")";

                    ExecuteNonQuery(query);
                }
                catch(Exception exp)
                {
                    throw exp;
                }
            }

            public void InsertFullWordDescription(String word, String path, double tf, double idf)
            {
                char firstLetter = word.ToUpper().ToCharArray()[0];
                String tableName = "";
                Segments letterSegment = LetterToSegments(firstLetter);
                switch (letterSegment)
                {
                    case Segments.A_D :
                        tableName = "A-D_total";
                        break;
                    case Segments.E_G :
                        tableName = "E-G_total";
                        break;
                    case Segments.H_L :
                        tableName = "H-L_total";
                        break;
                    case Segments.M_O :
                        tableName = "M-O_total";
                        break;
                    case Segments.P_S :
                        tableName = "P-S_total";
                        break;
                    case Segments.T_Z :
                        tableName = "T-Z_total";
                        break;
                    case Segments.None :
                        return;
                }
                if (WordAndFileExist(word,path,tableName))
                {
                   UpdateWordTFIDF(tableName,word,path,tf,idf);
                   return;
                }
                InsertWordTFIDF(tableName, word, path, tf, idf);
            }

            public Double GetTFByWordAndFile(String word, String path)
            {
                return new Double();
            }

            public Double GetIDFByWordAndFile(String word, String path)
            {
                return new Double();
            }

        #endregion

            #region PersistentModel : Private Methods

            /// <summary>
            /// 
            /// </summary>
            /// <param name="query"></param>
            /// <returns></returns>
            private OleDbDataReader ExecuteSelectionQuery(String query)
            {
                try
                {
                    OleDbCommand command = new OleDbCommand(query, connection);
                    return command.ExecuteReader();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }

            private void ExecuteNonQuery(String query)
            {
                try
                {
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.ExecuteNonQuery();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }

            private bool WordAndFileExist(string word, string path, string tableName)
            {
                try
                {

                    String query = "SELECT * FROM " + tableName + " WHERE Word = '"
                                   + word + "' AND FileName = '" + path + "'";
                    OleDbDataReader reader = ExecuteSelectionQuery(query);
                    return reader.HasRows;
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }

            private void InsertWordTFIDF(string tableName, string word, string path, double tf, double idf)
            {
                String query = "INSERT INTO " + tableName + " (Word,FileName,tf,idf) VALUES"
                               + "('" + word + "','" + path + "',"
                               + tf + "," + idf + ")";
            }

            private void UpdateWordTFIDF(string tableName, string word, string path, double tf, double idf)
            {
                throw new NotImplementedException();
            }

            private Segments LetterToSegments(char letter)
            {
                switch (letter)
                {
                    case 'A':
                        return Segments.A_D;
                    case 'B':
                        return Segments.A_D;
                    case 'C':
                        return Segments.A_D;
                    case 'D':
                        return Segments.A_D;
                    case 'E':
                        return Segments.E_G;
                    case 'F':
                        return Segments.E_G;
                    case 'G':
                        return Segments.E_G;
                    case 'H':
                        return Segments.H_L;
                    case 'I':
                        return Segments.H_L;
                    case 'J':
                        return Segments.H_L;
                    case 'K':
                        return Segments.H_L;
                    case 'L':
                        return Segments.H_L;
                    case 'M':
                        return Segments.M_O;
                    case 'N':
                        return Segments.M_O;
                    case 'O':
                        return Segments.M_O;
                    case 'P':
                        return Segments.P_S;
                    case 'Q':
                        return Segments.P_S;
                    case 'R':
                        return Segments.P_S;
                    case 'S':
                        return Segments.P_S;
                    case 'T':
                        return Segments.T_Z;
                    case 'U':
                        return Segments.T_Z;
                    case 'V':
                        return Segments.T_Z;
                    case 'W':
                        return Segments.T_Z;
                    case 'X':
                        return Segments.T_Z;
                    case 'Y':
                        return Segments.T_Z;
                    case 'Z':
                        return Segments.T_Z;
                    default :
                        return Segments.None;
                } 
            }

        #endregion
    
        #endregion

    }
}



//switch (firstLetter)
//{
//    case 'A':
//        dv = new DataView(dataset.A_Letter);
//        PersistentDataSet.A_LetterRow aNewRow =
//                dataset.A_Letter.NewA_LetterRow;
//        aNewRow.Word = word;
//        aNewRow.FileName = path;
//        aNewRow.Place = locationID;
//        aNewRow.Weight = weight;
//        dv.AddNew();
//        break;
