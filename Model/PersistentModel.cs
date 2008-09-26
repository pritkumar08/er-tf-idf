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

        private static PersistentModel instance = null;

        private static OleDbConnection connection;
        //private OleDbDataAdapter adapter;
        //private PersistentDataSet dataset;

        private const String connectionString_old =
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Project in advanced programming\\Model\\ModelDatabase.mdb";
        private const String connectionString =
        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Project in advanced programming\\Model\\erp.mdb";
        private static string ALL = "";

        private static string WEIGHTS_TABLE_PREFIX = "Weights_";
        private static string TF_IDF_TABLE_PREFIX = "TFIDF_";
        
        #endregion

        #region PersistentModel : Initialization

        protected PersistentModel()
        {
            CleanDB();
            createTables();
        }

        private void createTables()
        {
            createWeightTables();
//            createTFTables();
//            createIDFTables();
        }

        private void createTFTables()
        {
            string query_suffix="(Word VARCHAR(50),FileName VARCHAR(100),tf DECIMAL)";
            createTablesOfType(
                Enum.GetNames(typeof(TF_IDF_Segments)),
                TF_IDF_TABLE_PREFIX, query_suffix);
        }

        private void createIDFTables()
        {
            string query_suffix = "(Word VARCHAR(50),idf DECIMAL)";
            createTablesOfType(Enum.GetNames(typeof(TF_IDF_Segments)),
                TF_IDF_TABLE_PREFIX, query_suffix);

        }

        private void createWeightTables()
        {
            string query_suffix = " (Word VARCHAR(50),FileName VARCHAR(200),"+
            "Location INT,Weight Double,wCount INT)";
            createTablesOfType(
                Enum.GetNames(typeof(WEIGHTS_Segments)), 
                WEIGHTS_TABLE_PREFIX, query_suffix);
        }

        private void createTablesOfType(string[] tableNames,string commmonNamePrefix ,string fieldsDef)
        {
            string query_prefix = "CREATE TABLE ";
            foreach (string tableName in tableNames)
                ExecuteNonQuery(
                    query_prefix + commmonNamePrefix + tableName + fieldsDef);
        }

        public static PersistentModel getInstance()
        {
            connection = new OleDbConnection(connectionString);
            if (instance == null)
            {
                instance = new PersistentModel();
            }
            return instance;
        }

        #endregion

        #region PersistentModel : DB Clean

        public void CleanDB()
        {
            foreach (string tName in Enum.GetNames(typeof(WEIGHTS_Segments)))
            {
                try
                {
                    ExecuteNonQuery("DROP TABLE " + WEIGHTS_TABLE_PREFIX + tName);
                }
                catch (Exception e)
                {
                    if (!e.Message.Contains("not exist"))
                        throw e;
                }
            }
            /*
            foreach (string tName in Enum.GetNames(typeof(TF_IDF_Segments)))
            {
                try
                {
                    ExecuteNonQuery("DROP TABLE " + TF_IDF_TABLE_PREFIX + tName);
                }
                catch (Exception e)
                {
                    if (!e.Message.Contains("not exist"))
                        throw e;
                }
            }*/
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
            A = 0, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, Symbols
        }
        #endregion

        #region PersistentModel : Methods

        #region PersistentModel : Public Methods

        public void InsertWord(String word, String path, int locationID, double weight)
        {
            if (word.Length > 50 || path.Length > 200)
                throw new PersistentModelException("word must be at most 50 chars and file path"
                    + " must be at most 200 chars\n");
            try
            {
                string tableName = getTableName(word,typeof(WEIGHTS_Segments));
                object[] result = new object[5];
                if (WordExistsInLocation(word, path,locationID, tableName,out result))
                {
                    double old_w = (double)result[3];
                    UpdateWordWeight(tableName, word, path, locationID, old_w + weight,(int)result[4]+1);
                    return;
                }
                InsertWordWeight(tableName, word, path, locationID, weight);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }     

        public void InsertWordTF(String word, String path, double tf)
        {
            /*
            string tableName = getTableName(word, typeof(TF_IDF_Segments));
            object[] result;
            if (WordExistsInLocation(word, path, tableName,out result))
            {
                UpdateWordTF(tableName, word, path, tf);
                return;
            }
            InsertWordTF(tableName, word, path, tf);
             */
        }

        public Double GetTFByWordAndFile(String word, String path)
        {
            return (Double)getFieldByWordAndFile("tf",word,path);
        }

        public Double GetIDFByWordAndFile(String word, String path)
        {
            return (Double)getFieldByWordAndFile("idf",word,path);
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
            if (word.Length > 50)
                throw new PersistentModelException("word length must be at most 50 chars\n");
            return getFilesCount(word);
        }
        
        public List<RawWord> getFileWords(string path)
        {
            if (path.Length > 200)
                throw new PersistentModelException("file path length must be at most 200 chars\n");
            List<RawWord> words = new List<RawWord>();
            try
            {
                connection.Open();
                foreach (string tableName in Enum.GetNames(typeof(WEIGHTS_Segments)))
                {
                    string query = "SELECT Word,Location,Weight*wCount FROM "
                    + WEIGHTS_TABLE_PREFIX + tableName +
                    " WHERE FileName = '" + path + "'";
                    OleDbDataReader reader = ExecuteSelectionQuery(query);
                    while (reader.Read())
                    {
                        words.Add(new RawWord(
                            reader.GetString(0), 
                            reader.GetInt32(1), 
                            reader.GetDouble(2)));
                    }
                    reader.Close();
                }
                return words;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<string> getWords()
        {
            List<string> words = new List<string>();
            try
            {
                connection.Open();
                foreach (string tableName in Enum.GetNames(typeof(WEIGHTS_Segments)))
                {
                    string query = "SELECT DISTINCT Word FROM "
                    + WEIGHTS_TABLE_PREFIX + tableName;
                    OleDbDataReader reader = ExecuteSelectionQuery(query);
                    while (reader.Read())
                    {
                        words.Add(reader.GetString(0));
                    }
                }
                return words;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            
        }
        
        public List<string> getFiles()
        {
            return getFiles_aux("");
        }

        public List<string> getFiles(string word)
        {
            if (word.Length > 50)
                throw new PersistentModelException("word length must be at most 50 chars\n");
            return getFiles_aux(" WHERE Word = '" + word);
        }

        public int FilesCount()
        {
            return getFiles().Count;
        }                

        public List<Location> getWordLocations(string w)
        {
            if (w.Length > 50)
                throw new PersistentModelException("word length must be at most 50 chars\n");

            List<Location> locations = new List<Location>();
            try
            {
                connection.Open();
                foreach (string tableName in Enum.GetNames(typeof(WEIGHTS_Segments)))
                {
                    string query = "SELECT FileName,Location,Weight*wCount FROM "
                    + WEIGHTS_TABLE_PREFIX + tableName +
                    " WHERE Word = '" + w + "'";
                    OleDbDataReader reader = ExecuteSelectionQuery(query);
                    while (reader.Read())
                    {
                        locations.Add(new Location(){
                            FileName = reader.GetString(0),
                            LocationID = reader.GetInt32(1),
                            Weight = reader.GetDouble(2)
                        });
                    }
                }
                return locations;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateDB()
        {
            //do nothing here - all operations in this impl are directly on the DB 
        }

        #endregion

        #region PersistentModel : Private Methods

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
                connection.Open();
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                connection.Close();
            }
        }

        private bool WordExistsInLocation(string word, string path,int location, string tableName,
            out object[] result)
        {
            result = null;
            try
            {
                connection.Open();
                string query = "SELECT * FROM " + tableName
                    + " WHERE Word = '" + word + "' AND FileName = '" + path + "'"
                    + " AND Location = " + location + "";
                OleDbDataReader reader = ExecuteSelectionQuery(query);
                if (reader.Read())
                {
                    result = new object[reader.FieldCount];
                    reader.GetValues(result);
                    reader.Close();
                    return true;
                }
                reader.Close();
                return false;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                connection.Close();
            }
        }
        
        private void InsertWordWeight(string tableName, string word, string path, int locationID, double weight)
        {
            string query = "INSERT INTO " + tableName
               + " (Word,FileName,Location,Weight,wCount) VALUES ('"
               + word.ToUpper() + "','" + path + "',"
               + locationID + "," + weight + "," + 1 + ")";
            ExecuteNonQuery(query);
        }

        private void UpdateWordWeight(string tableName, string word, string path, 
            int locationID, double weight,int counter)
        {
            string query = "UPDATE " + tableName +
                    " SET Weight = " + weight + ", wCount = " + counter +
                    " WHERE Word = '" + word + "' AND FileName = '" + path + "'"
                    + " AND Location = " + locationID + "";
            ExecuteNonQuery(query);
        }

        private void InsertWordTF(string tableName, string word, string path, double tf)
        {
            string query = "INSERT INTO " + tableName + " (Word,FileName,tf)" + 
                " VALUES "  + "('" + word + "','" + path + "'," + tf + ")";
            ExecuteNonQuery(query);
        }

        private void UpdateWordTF(string tableName, string word, string path, double tf)
        {
            string query = "UPDATE " + tableName + " SET tf = " + tf + 
                " WHERE Word = '" + word + "' AND FileName = '" + path + "'" ;
            ExecuteNonQuery(query);
        }

        private object getFieldByWordAndFile(string field, string word, string path)
        {
            try
            {
                connection.Open();
                object retVal = null;
                string tableName = getTableName(word, typeof(TF_IDF_Segments));
                string query = "SELECT " + field + " FROM " + tableName
                            + " WHERE FileName = '" + path + "' AND Word = '" + word + "'";
                OleDbDataReader reader = ExecuteSelectionQuery(query);
                while (reader.Read())
                {
                    retVal = reader.GetValue(0);
                }
                reader.Close();
                return retVal;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        private double getWeight(string word, string path)
        {
            try
            {
                connection.Open();
                string having_suffix = " HAVING FileName ='" + path + "'";
                having_suffix += word.Equals(ALL) ? "" : " And Word ='" + word + "'";
                string group_by_suffix = word.Equals(ALL) ? "" : ",Word";
                double totalWeight = 0.0;
                foreach (string tableName in Enum.GetNames(typeof(WEIGHTS_Segments)))
                {
                    string query = "SELECT SUM(Weight) AS t_weight FROM " +
                        WEIGHTS_TABLE_PREFIX + tableName
                        + " GROUP BY FileName " + group_by_suffix + having_suffix;
                    OleDbDataReader reader = ExecuteSelectionQuery(query);
                    while (reader.Read())
                    {
                        totalWeight += reader.GetDouble(0);
                    }
                    reader.Close();
                }
                return totalWeight;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                connection.Close();
            }
        }

        private static TF_IDF_Segments LetterToSegments(char letter)
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

        private static string getTableName(string word, Type tType)
        {
            char c = word.ToUpper().ToCharArray()[0];
            if (tType.Equals(typeof(WEIGHTS_Segments)))
                return WEIGHTS_TABLE_PREFIX + (char.IsLetter(c)?c.ToString():"Symbols");
            if (tType.Equals(typeof(TF_IDF_Segments)))
                return TF_IDF_TABLE_PREFIX + LetterToSegments(word.ToCharArray()[0]);
            return "";
        }

        private int getFilesCount(string word)
        {
            return getFiles_aux(" WHERE Word = '" + word + "' AND Weight > 0").Count;
        }

        private List<string> getFiles_aux(string where_pred)
        {
            List<string> files = new List<string>();
            try
            {
                connection.Open();
                foreach (string tableName in Enum.GetNames(typeof(WEIGHTS_Segments)))
                {
                    string query = "SELECT DISTINCT FileName FROM "
                    + WEIGHTS_TABLE_PREFIX + tableName + where_pred;
                    OleDbDataReader reader = ExecuteSelectionQuery(query);
                    while (reader.Read())
                    {
                        string fname = reader.GetString(0);
                        if (!files.Contains(fname))
                            files.Add(fname);
                    }
                }
                return files;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
        }

        //private static string TF_IDF_SegmentsToString(TF_IDF_Segments s)
        //{
        //    if (s.Equals(TF_IDF_Segments.None))
        //    {
        //        throw new PersistentModelException("no matching table found");
        //    }
        //    string str = s.ToString();
        //    str.Replace('_', '-');
        //    return str + "_total";
        //}
        
        #endregion

        #endregion

        #region TestMethods

        public void UpdateWordWeightTest(string tableName, string word, string path, int locationID, double weight, int counter)
        {
            this.UpdateWordWeight(tableName, word, path, locationID, weight, counter);
        }

        public string GetWeightsTableNameTest(string word)
        {
            return getTableName(word, typeof(WEIGHTS_Segments));
        }
        #endregion

    }

    public class PersistentModelException : Exception
    {
        public PersistentModelException(string err)
            : base(err)
        {
        }
    }

}

