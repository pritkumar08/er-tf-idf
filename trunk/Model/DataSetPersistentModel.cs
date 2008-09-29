using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;

namespace Model
{
    public class DataSetPersistentModel : IPersistentModel
    {

        #region DataSetPersistentModel : Members & Consts

        private static DataSetPersistentModel instance = null;

        private static OleDbConnection connection;
        private erpDataSet dataset = new erpDataSet();
        Dictionary<string, OleDbDataAdapter> adapters = new Dictionary<string, OleDbDataAdapter>();
        public static string ConnectionString;

        public const string TEST_CONNECTION_STRING = 
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\Project in advanced programming\\Model\\erp.mdb;Persist Security Info=True";
        public const string RELATIVE_CONNECTION_STRING =
        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|erp.mdb;Persist Security Info=True";
        private static string ALL = "";
        private static string WEIGHTS_TABLE_PREFIX = "Weights_";
        
        #endregion

        #region DataSetPersistentModel : Initialization

        protected DataSetPersistentModel()
        {
            createTables();
            try
            {
                foreach (string prefix in Enum.GetNames(typeof(WEIGHTS_Segments)))
                {
                    string table_name = WEIGHTS_TABLE_PREFIX + prefix;
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = CreateSelectCommand(table_name, connection);
                    adapter.InsertCommand = CreateInsertCommand(table_name, connection);
                    adapter.DeleteCommand = CreateDeleteCommand(table_name, connection);
                    adapter.UpdateCommand = CreateUpdateCommand(table_name, connection);
                    adapters.Add(table_name, adapter);
                    adapter.Fill(dataset, table_name);                    
                }
                CreateKeys();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }
       
        public static DataSetPersistentModel getInstance()
        {
            connection = new OleDbConnection(ConnectionString);
            if (instance == null)
            {
                instance = new DataSetPersistentModel();
            }
            return instance;
        }

        #endregion

        #region PersistentModel : DB Clean

        public void CleanDB()
        {
            try
            {
                foreach (string prefix in Enum.GetNames(typeof(WEIGHTS_Segments)))
                {
                    string table_name = WEIGHTS_TABLE_PREFIX + prefix;
                    foreach (DataRow r in dataset.Tables[table_name].Rows)
                    {
                        r.Delete();
                    }
                    adapters[table_name].Update(dataset, table_name);
                }
                dataset.AcceptChanges();
            }
            catch (OleDbException ex)
            {                
                throw ex;
            }
        }

        private static OleDbCommand CreateUpdateCommand(string table_name, OleDbConnection conn)
        {
            OleDbCommand cmd = new OleDbCommand(
            "UPDATE " + table_name + " SET wCount = ?"
            + " WHERE Word = ? AND FileName = ? AND Location = ?", conn);
            cmd.Parameters.Add("wCount", OleDbType.Integer, 10, "wCount");            
            cmd.Parameters.Add("Word", OleDbType.WChar, 50, "Word");
            cmd.Parameters.Add("FileName", OleDbType.WChar, 200, "FileName");
            cmd.Parameters.Add("Location", OleDbType.Integer, 10, "Location");
            return cmd;
        }

        private static OleDbCommand CreateDeleteCommand(string table_name, OleDbConnection conn)
        {
            OleDbCommand cmd = new OleDbCommand(
                 "DELETE * FROM " + table_name +
                 " WHERE Word = ? AND FileName = ? AND Location = ?", conn);
            cmd.Parameters.Add("Word", OleDbType.WChar, 50,"Word");
            cmd.Parameters.Add("FileName", OleDbType.WChar, 200,"FileName");
            cmd.Parameters.Add("Location", OleDbType.Integer, 10,"Location");
            return cmd;
        }

        private static OleDbCommand CreateSelectCommand(string table_name, OleDbConnection conn)
        {
            return new OleDbCommand(
                                "SELECT * FROM " + table_name, conn);
        }

        private OleDbCommand CreateInsertCommand(string table_name, OleDbConnection conn)
        {
            OleDbCommand cmd = new OleDbCommand(
            "INSERT INTO " + table_name + " (Word,FileName,Location,Weight,wCount)" 
            + "VALUES (?,?,?,?,?)", conn);
            cmd.Parameters.Add("Word", OleDbType.WChar, 50, "Word");
            cmd.Parameters.Add("FileName", OleDbType.WChar, 200, "FileName");
            cmd.Parameters.Add("Location", OleDbType.Integer, 10, "Location");
            cmd.Parameters.Add("Weight", OleDbType.Double, 15, "Weight");            
            cmd.Parameters.Add("wCount", OleDbType.Integer, 10, "wCount");            
            return cmd;
        }

        #endregion

        #region PersistentModel : Enums
        [Obsolete]
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
            A = 0, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, Symbols, 
            א , ב , ג , ד , ה , ו , ז , ח , ט , י , כ , ל , מ , נ , ס , ע , פ , צ , ק , ר , ש , ת 
        }
        #endregion

        #region PersistentModel : Methods

        #region PersistentModel : Public Methods

        public void InsertWord(String word, String path, int locationID, double weight)
        {
            string tableName = getTableName(word, typeof(WEIGHTS_Segments));
            DataRow r;
            if (dataset.Tables[tableName].Rows.Contains(
                new object[] { word, path, locationID }))
            {
                r = dataset.Tables[tableName].Rows.Find(
                    new object[] { word, path, locationID });
                r["wCount"] = ((int)r["wCount"]) + 1;
                return;
            }
            else
            {
                r = dataset.Tables[tableName].NewRow();
                r["Word"] = word;
                r["FileName"] = path;
                r["Location"] = locationID;
                r["Weight"] = weight;
                r["wCount"] = 1;
                dataset.Tables[tableName].Rows.Add(r);
            }
        }     

        [Obsolete]
        public void InsertWordTF(String word, String path, double tf)
        {
        }

        [Obsolete]
        public Double GetTFByWordAndFile(String word, String path)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        public Double GetIDFByWordAndFile(String word, String path)
        {
            throw new NotImplementedException();
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
            return getFilesCount(word);
        }
        
        public List<RawWord> getFileWords(string path)
        {
            List<RawWord> words = new List<RawWord>();
            foreach (DataTable t in dataset.Tables)
            {
                words.AddRange(from r in t.AsEnumerable()
                               where r.Field<string>("FileName").Equals(path)
                               select new RawWord()
                               {
                                   Text = r.Field<string>("Word"),
                                   LocationID = r.Field<int>("Location"),
                                   Weight = r.Field<double>("Weight")
                               });
            }
            return words;
        }

        public List<string> getWords()
        {
            List<string> words = new List<string>();
            foreach (DataTable t in dataset.Tables)
            {
                words.AddRange((from r in t.AsEnumerable()
                               select r.Field<string>("Word")).Distinct());
            }
            return words;
        }
        
        public List<string> getFiles()
        {
            return getFiles_aux(ALL);
        }

        public List<string> getFiles(string word)
        {
            return getFiles_aux(word);
        }

        public int FilesCount()
        {
            return getFiles().Count;
        }                

        public List<Location> getWordLocations(string w)
        {
            List<Location> locations = new List<Location>();
            foreach (DataTable t in dataset.Tables)
            {
                locations.AddRange( from r in t.AsEnumerable()
                                    where w.Equals(r.Field<string>("Word"))
                                    select new Location(){ 
                                        FileName = r.Field<string>("FileName"),
                                     LocationID = r.Field<int>("Location"),
                                        Weight = r.Field<double>("Weight")*r.Field<int>("wCount")
                                    });
            }
            return locations;
        }

        #endregion

        public void UpdateDB()
        {
            foreach (string prefix in Enum.GetNames(typeof(WEIGHTS_Segments)))
            {
                string table_name = WEIGHTS_TABLE_PREFIX + prefix;
                adapters[table_name].Update(dataset, table_name);
            }
            dataset.AcceptChanges();            
        }

        public void RejectChanges()
        {
            dataset.RejectChanges();
        }
        #region PersistentModel : Private Methods

        private void createWeightTables()
        {
            string query_suffix = " (Word VARCHAR(50),FileName VARCHAR(200)," +
            "Location INT,Weight Double,wCount INT)";
            createTablesOfType(
                Enum.GetNames(typeof(WEIGHTS_Segments)),
                WEIGHTS_TABLE_PREFIX, query_suffix);
        }

        private void createTablesOfType(string[] tableNames, string commmonNamePrefix, string fieldsDef)
        {
            string query_prefix = "CREATE TABLE ";
            foreach (string tableName in tableNames)
            {
                if (!TableExists(commmonNamePrefix + tableName))
                ExecuteNonQuery(
                    query_prefix + commmonNamePrefix + tableName + fieldsDef);
            }
        }

        private bool TableExists(string tableName)
        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT (*) FROM " + tableName;
                OleDbCommand command = new OleDbCommand(query, connection);
                int? res = command.ExecuteScalar() as int?;
                return res != null;
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Make sure it exists"))
                    return false;
                else throw e;
            }
            finally
            {
                connection.Close();                
            }
        }

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

        private void createTables()
        {
            createWeightTables();
            /*
            foreach (string prefix in Enum.GetNames(typeof(WEIGHTS_Segments)))
            {
                if (TableExists(WEIGHTS_TABLE_PREFIX + prefix))
                    continue;
                DataTable weights_table = new DataTable(WEIGHTS_TABLE_PREFIX + prefix);
                DataColumn c;
                //word column
                c = new DataColumn();
                c.DataType = System.Type.GetType("System.String");
                c.ColumnName = "Word";
                c.Caption = "Word";
                c.ReadOnly = true;
                c.Unique = true;
                weights_table.Columns.Add(c);

                //FileName column
                c = new DataColumn();
                c.DataType = System.Type.GetType("System.String");
                c.ColumnName = "FileName";
                c.Caption = "FileName";
                c.ReadOnly = true;
                c.Unique = true;
                weights_table.Columns.Add(c);

                //Location column
                c = new DataColumn();
                c.DataType = System.Type.GetType("System.Int32");
                c.ColumnName = "Location";
                c.Caption = "Location";
                c.ReadOnly = true;
                c.Unique = true;
                weights_table.Columns.Add(c);

                //Weight column
                c = new DataColumn();
                c.DataType = System.Type.GetType("System.Double");
                c.ColumnName = "Weight";
                c.Caption = "Weight";
                weights_table.Columns.Add(c);

                //wCount column
                c = new DataColumn();
                c.DataType = System.Type.GetType("System.Int32");
                c.ColumnName = "wCount";
                c.Caption = "wCount";
                weights_table.Columns.Add(c);

                DataColumn[] PrimaryKeyColumns = new DataColumn[3];
                PrimaryKeyColumns[0] = weights_table.Columns["Word"];
                PrimaryKeyColumns[1] = weights_table.Columns["FileName"];
                PrimaryKeyColumns[2] = weights_table.Columns["Location"];
                weights_table.PrimaryKey = PrimaryKeyColumns;
                
                dataset.Tables.Add(weights_table);             
            }
           */
        }

        private void CreateKeys()
        {
            foreach (DataTable table in dataset.Tables)
            {
                DataColumn[] PrimaryKeyColumns = new DataColumn[3];
                PrimaryKeyColumns[0] = table.Columns["Word"];
                PrimaryKeyColumns[1] = table.Columns["FileName"];
                PrimaryKeyColumns[2] = table.Columns["Location"];
                table.PrimaryKey = PrimaryKeyColumns;
            }
        }

        private double getWeight(string word, string path)
        {
            double total_weight = 0;
            bool any_cond = word.Equals(ALL);
            foreach (DataTable t in dataset.Tables)
            {
                total_weight += (
                    from r in t.AsEnumerable()
                    where (
                    (r.Field<string>("Word").Equals(word) || any_cond) &&
                    (r.Field<string>("FileName").Equals(path))
                    )
                    select r.Field<double>("Weight")* r.Field<int>("wCount")).Sum();
            }
            return total_weight;
        }

        private int getFilesCount(string word)
        {
            int files_count = 0;
            foreach (DataTable t in dataset.Tables)
            {
                files_count += (from r in t.AsEnumerable()
                                where r.Field<string>("Word").Equals(word)
                                select r.Field<string>("FileName")).
                                Distinct().Count();
            }
            return files_count;
        }

        /*
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
        }*/

        private static string getTableName(string word, Type tType)
        {
            char c = word.ToUpper().ToCharArray()[0];
            if (tType.Equals(typeof(WEIGHTS_Segments)))
                return WEIGHTS_TABLE_PREFIX + (char.IsLetter(c)?c.ToString():"Symbols");
            return "";
        }

        private List<string> getFiles_aux(string word)
        {
            bool any_pred = word.Equals(ALL);
            List<string> files = new List<string>();
            foreach (DataTable t in dataset.Tables)
            {
                files.AddRange((from r in t.AsEnumerable()
                               where (r.Field<string>("Word").Equals(word) || any_pred)
                               select r.Field<string>("FileName")).Distinct());
            }
            return new List<string>((from f in files.AsEnumerable() select f).Distinct());
        }

        #endregion

        #endregion

        #region TestMethods
        
        [Obsolete]
        public void UpdateWordWeightTest(string tableName, string word, string path, int locationID, double weight, int counter)
        {            
        }
        [Obsolete]
        private void UpdateWordWeight(string tableName, string word, string path, int locationID, double weight, int counter)
        {         
        }
        [Obsolete]
        public string GetWeightsTableNameTest(string word)
        {
            return null;
        }
        #endregion
    }
}

