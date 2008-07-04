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

            public void InsertWord(String word, String path, int locationID, double weight)
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

            private object[] ExecuteSelectionQuery(String query)
            {
                return null;
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
//    case 'B':
//        dv = new DataView(dataset.B_Letter);
//        PersistentDataSet.B_LetterRow bNewRow =
//                dataset.B_Letter.NewB_LetterRow;
//        bNewRow.Word = word;
//        bNewRow.FileName = path;
//        bNewRow.Place = locationID;
//        bNewRow.Weight = weight;
//        dv.AddNew();
//        break;
//    case 'C':
//        dv = new DataView(dataset.C_Letter);
//        PersistentDataSet.C_LetterRow cNewRow =
//                dataset.C_Letter.NewC_LetterRow;
//        cNewRow.Word = word;
//        cNewRow.FileName = path;
//        cNewRow.Place = locationID;
//        cNewRow.Weight = weight;
//        dv.AddNew();
//        break;
//    case 'D':
//        dv = new DataView(dataset.D_Letter);
//        newRow = dataset.D_Letter.NewD_LetterRow;
//        break;
//    case 'E':
//        dv = new DataView(dataset.E_Letter);
//        newRow = dataset.E_Letter.NewE_LetterRow;
//        break;
//    case 'F':
//        dv = new DataView(dataset.F_Letter);
//        newRow = dataset.F_Letter.NewF_LetterRow;
//        break;
//    case 'G':
//        dv = new DataView(dataset.G_Letter);
//        newRow = dataset.G_Letter.NewG_LetterRow;
//        break;
//    case 'H':
//        dv = new DataView(dataset.H_Letter);
//        newRow = dataset.H_Letter.NewH_LetterRow;
//        break;
//    case 'I':
//        dv = new DataView(dataset.I_Letter);
//        newRow = dataset.I_Letter.NewI_LetterRow;
//        break;
//    case 'J':
//        dv = new DataView(dataset.J_Letter);
//        newRow = dataset.J_Letter.NewJ_LetterRow;
//        break;
//    case 'K':
//        dv = new DataView(dataset.K_Letter);
//        newRow = dataset.K_Letter.NewK_LetterRow;
//        break;
//    case 'L':
//        dv = new DataView(dataset.K_Letter);
//        newRow = dataset.K_Letter.NewK_LetterRow;
//        break;
//    case 'M':
//        dv = new DataView(dataset.A_Letter);
//        newRow = dataset.A_Letter.NewA_LetterRow;
//        break;
//    case 'N':
//        dv = new DataView(dataset.A_Letter);
//        newRow = dataset.A_Letter.NewA_LetterRow;
//        break;
//    case 'O':
//        dv = new DataView(dataset.O_Letter);
//        newRow = dataset.O_Letter.NewO_LetterRow;
//        break;
//    case 'P':
//        dv = new DataView(dataset.P_Letter);
//        newRow = dataset.P_Letter.NewP_LetterRow;
//        break;
//    case 'Q':
//        dv = new DataView(dataset.Q_Letter);
//        newRow = dataset.Q_Letter.NewQ_LetterRow;
//        break;
//    case 'R':
//        dv = new DataView(dataset.R_Letter);
//        newRow = dataset.R_Letter.NewR_LetterRow;
//        break;
//    case 'S':
//        dv = new DataView(dataset.S_Letter);
//        newRow = dataset.S_Letter.NewS_LetterRow;
//        break;
//    case 'T':
//        dv = new DataView(dataset.T_Letter);
//        newRow = dataset.T_Letter.NewT_LetterRow;
//        break;
//    case 'U':
//        dv = new DataView(dataset.U_Letter);
//        newRow = dataset.U_Letter.NewU_LetterRow;
//        break;
//    case 'V':
//        dv = new DataView(dataset.V_Letter);
//        newRow = dataset.V_Letter.NewV_LetterRow;
//        break;
//    case 'W':
//        dv = new DataView(dataset.W_Letter);
//        newRow = dataset.W_Letter.NewW_LetterRow;
//        break;
//    case 'X':
//        dv = new DataView(dataset.X_Letter);
//        newRow = dataset.X_Letter.NewX_LetterRow;
//        break;
//    case 'Y':
//        dv = new DataView(dataset.Y_Letter);
//        newRow = dataset.Y_Letter.NewY_LetterRow;
//        break;
//    case 'Z':
//        dv = new DataView(dataset.Z_Letter);
//        newRow = dataset.Z_Letter.NewZ_LetterRow;
//        break;
//    default:
//        return;
//}

//private void FillGeneralTable(String tableName)
//{

//}

//private void FillDataSet()
//{

//}

//private void UpdateGeneralTable(String tableName)
//{

//}

