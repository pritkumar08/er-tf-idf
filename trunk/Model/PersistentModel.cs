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

        private static string ALL = "";
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
        /// prefixes for the td-idf tables
        /// </summary>
        private enum TF_IDF_Segments
        {
            A_D = 0,
            E_G = 1,
            H_L = 2,
            M_O = 3,
            P_S = 4,
            T_Z = 5,
            None = 6
        }
        private enum WEIGHTS_Segments
        {
            A = 0,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z
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
                               + "_LETTER (Word,FileName,Place,Weight) VALUES ('"
                               + word.ToUpper() + "','" + path + "',"
                               + locationID + "," + weight + ")";

                ExecuteNonQuery(query);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public void InsertFullWordDescription(String word, String path, double tf, double idf)
        {
            char firstLetter = word.ToUpper().ToCharArray()[0];
            String tableName = "";
            TF_IDF_Segments letterSegment = LetterToSegments(firstLetter);
            switch (letterSegment)
            {
                case TF_IDF_Segments.A_D:
                    tableName = "A-D_total";
                    break;
                case TF_IDF_Segments.E_G:
                    tableName = "E-G_total";
                    break;
                case TF_IDF_Segments.H_L:
                    tableName = "H-L_total";
                    break;
                case TF_IDF_Segments.M_O:
                    tableName = "M-O_total";
                    break;
                case TF_IDF_Segments.P_S:
                    tableName = "P-S_total";
                    break;
                case TF_IDF_Segments.T_Z:
                    tableName = "T-Z_total";
                    break;
                case TF_IDF_Segments.None:
                    return;
            }
            if (WordAndFileExist(word, path, tableName))
            {
                UpdateWordTFIDF(tableName, word, path, tf, idf);
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

        public double GetTotalWeight(string word, string path)
        {
            return getWeight(word, path);
        }

        public double GetTotalWeights(string path)
        {
            return getWeight(ALL,path);
        }


        public int CountFilesContains(string word)
        {
            int fcount = 0;
            string where_suffix = 
                word.Equals(ALL)?"":"WHERE Word = '"+ word + "'AND Weight > 0";
            foreach (string tableName in Enum.GetNames(typeof(WEIGHTS_Segments)))
            {
                string query = "SELECT COUNT(DISTINCT FileName) FROM" +
                    tableName + where_suffix;
                OleDbDataReader reader = ExecuteSelectionQuery(query);
                while (reader.Read())
                {
                    fcount += reader.GetInt32(0);
                }
            }
            return fcount;
        }

        public int FilesCount()
        {
            return 0;
        }

        public List<Word> GetInversionList()
        {
            return new List<Word>();
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

        private double getWeight(string word, string path)
        {
            string having_suffix = "HAVING FileName = '" + path + "'";
            if (!word.Equals(ALL))
                having_suffix += ",Word = '" + word + "'";
            try
            {
                double totalWeight = 0.0;
                foreach (string tableName in Enum.GetNames(typeof(WEIGHTS_Segments)))
                {
                    string query = "SELECT SUM(Weight) AS t_weight FROM" + tableName
                        + "GROUP BY FileName " + having_suffix;
                    OleDbDataReader reader = ExecuteSelectionQuery(query);
                    while (reader.Read())
                    {
                        totalWeight += reader.GetDouble(0);
                    }
                }
                return totalWeight;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private TF_IDF_Segments LetterToSegments(char letter)
        {
            switch (letter)
            {
                case 'A':
                    return TF_IDF_Segments.A_D;
                case 'B':
                    return TF_IDF_Segments.A_D;
                case 'C':
                    return TF_IDF_Segments.A_D;
                case 'D':
                    return TF_IDF_Segments.A_D;
                case 'E':
                    return TF_IDF_Segments.E_G;
                case 'F':
                    return TF_IDF_Segments.E_G;
                case 'G':
                    return TF_IDF_Segments.E_G;
                case 'H':
                    return TF_IDF_Segments.H_L;
                case 'I':
                    return TF_IDF_Segments.H_L;
                case 'J':
                    return TF_IDF_Segments.H_L;
                case 'K':
                    return TF_IDF_Segments.H_L;
                case 'L':
                    return TF_IDF_Segments.H_L;
                case 'M':
                    return TF_IDF_Segments.M_O;
                case 'N':
                    return TF_IDF_Segments.M_O;
                case 'O':
                    return TF_IDF_Segments.M_O;
                case 'P':
                    return TF_IDF_Segments.P_S;
                case 'Q':
                    return TF_IDF_Segments.P_S;
                case 'R':
                    return TF_IDF_Segments.P_S;
                case 'S':
                    return TF_IDF_Segments.P_S;
                case 'T':
                    return TF_IDF_Segments.T_Z;
                case 'U':
                    return TF_IDF_Segments.T_Z;
                case 'V':
                    return TF_IDF_Segments.T_Z;
                case 'W':
                    return TF_IDF_Segments.T_Z;
                case 'X':
                    return TF_IDF_Segments.T_Z;
                case 'Y':
                    return TF_IDF_Segments.T_Z;
                case 'Z':
                    return TF_IDF_Segments.T_Z;
                default:
                    return TF_IDF_Segments.None;
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
