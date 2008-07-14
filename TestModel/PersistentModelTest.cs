using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.OleDb;
using System.Collections.Generic;

namespace TestModel
{
    
    
    /// <summary>
    ///This is a test class for PersistentModelTest and is intended
    ///to contain all PersistentModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PersistentModelTest
    {

        private static IPersistentModel model_instance;
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            if (model_instance != null)
                model_instance.CleanDB();
            model_instance = PersistentModel.getInstance();
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion

        /// <summary>
        ///A test for PersistentModel Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void PersistentModelConstructorTest()
        {
            PersistentModel_Accessor target = new PersistentModel_Accessor();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for createTables
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void createTablesTest()
        {
            PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            target.createTables();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for createWeightTables
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void createWeightTablesTest()
        {
            PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            target.createWeightTables();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for createTFIDFTables
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void createTFIDFTablesTest()
        {
            PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            target.createTFIDFTables();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }      

        /// <summary>
        ///A test for LetterToSegments
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void LetterToSegmentsTest()
        {
            char letter = '\0'; // TODO: Initialize to an appropriate value
            PersistentModel_Accessor.TF_IDF_Segments expected = null; // TODO: Initialize to an appropriate value
            PersistentModel_Accessor.TF_IDF_Segments actual;
            actual = PersistentModel_Accessor.LetterToSegments(letter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InsertWord
        ///</summary>
        [TestMethod()]
        public void InsertWordTest()
        {
            //PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = "dome"; // TODO: Initialize to an appropriate value
            string path = "file1"; // TODO: Initialize to an appropriate value
            int locationID = 1; // TODO: Initialize to an appropriate value
            double weight = 1.242; // TODO: Initialize to an appropriate value
            model_instance.InsertWord(word, path, locationID, weight);
            double tw = model_instance.GetTotalWeight("DOME", "file1");
            Assert.AreEqual(weight, tw);

            word = "dome"; 
            path = "file2";
            locationID = 12; 
            weight = 0.03;
            model_instance.InsertWord(word, path, locationID, weight);            
            tw = model_instance.GetTotalWeight("DOME", "file2");
            Assert.AreEqual(weight, tw);
            
            word = "dome";
            path = "file1";
            locationID = 12;
            weight = 0.005;
            model_instance.InsertWord(word, path, locationID, weight);
            tw = model_instance.GetTotalWeight("DOME", "file1");
            Assert.AreEqual(weight, tw);
        }

        /// <summary>
        ///A test for InsertWordTFIDF
        ///</summary>
        [TestMethod()]
        public void InsertWordTFIDFTest()
        {
            //PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = "home"; // TODO: Initialize to an appropriate value
            string path = "file1"; // TODO: Initialize to an appropriate value
            double tf = 1.4; // TODO: Initialize to an appropriate value
            double idf = 0.053; // TODO: Initialize to an appropriate value
            model_instance.InsertWordTFIDF(word, path, tf, idf);
            word = "home"; 
            path = "file2";
            tf = 1.4; 
            idf = 0.053;
            model_instance.InsertWordTFIDF(word, path, tf, idf);            
        }

        /// <summary>
        ///A test for GetTotalWeights
        ///</summary>
        [TestMethod()]
        public void GetTotalWeightsTest()
        {
            //PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string path = "file1"; // TODO: Initialize to an appropriate value
            double expected = 1.247; // TODO: Initialize to an appropriate value
            double actual;
            actual = model_instance.GetTotalWeights(path);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetTotalWeight
        ///</summary>
        [TestMethod()]
        public void GetTotalWeightTest()
        {
            //PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = "dome"; // TODO: Initialize to an appropriate value
            string path = "file1"; // TODO: Initialize to an appropriate value
            double expected = 1.247; // TODO: Initialize to an appropriate value
            double actual;
            actual = model_instance.GetTotalWeight(word, path);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetTFByWordAndFile
        ///</summary>
        [TestMethod()]
        public void GetTFByWordAndFileTest()
        {
            PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = string.Empty; // TODO: Initialize to an appropriate value
            string path = string.Empty; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.GetTFByWordAndFile(word, path);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for WordAndFileExist
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void WordAndFileExistTest()
        {
            //PersistentModel_Accessor target = new PersistentModel_Accessor();
            string word = "HOME";
            string path = "file1";
            string tableName = "Weights_H";
            object[] result = null; // TODO: Initialize to an appropriate value
            object[] resultExpected = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = model_instance.WordAndFileExistTest(word, path, tableName, out result);
            Assert.AreEqual(resultExpected, result);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetInversionList
        ///</summary>
        [TestMethod()]
        public void GetInversionListTest()
        {
            PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            List<Word> expected = null; // TODO: Initialize to an appropriate value
            List<Word> actual;
            actual = target.GetInversionList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getInstance
        ///</summary>
        [TestMethod()]
        public void getInstanceTest()
        {
            PersistentModel expected = null; // TODO: Initialize to an appropriate value
            PersistentModel actual;
            actual = PersistentModel.getInstance();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetIDFByWordAndFile
        ///</summary>
        [TestMethod()]
        public void GetIDFByWordAndFileTest()
        {
            PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = string.Empty; // TODO: Initialize to an appropriate value
            string path = string.Empty; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.GetIDFByWordAndFile(word, path);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getFilesCount
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void getFilesCountTest()
        {
            PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = string.Empty; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.getFilesCount(word);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getFieldByWordAndFile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void getFieldByWordAndFileTest()
        {
            PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string field = string.Empty; // TODO: Initialize to an appropriate value
            string word = string.Empty; // TODO: Initialize to an appropriate value
            string path = string.Empty; // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.getFieldByWordAndFile(field, word, path);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for FilesCount
        ///</summary>
        [TestMethod()]
        public void FilesCountTest()
        {
            this.InsertWordTest();
            this.CountFilesContainsTest();
            //PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            int expected = 2; // TODO: Initialize to an appropriate value
            int actual;
            actual = model_instance.FilesCount();
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for UpdateWordWeight
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void UpdateWordWeightTest()
        {
            //PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = "dome"; // TODO: Initialize to an appropriate value
            string tableName = model_instance.GetWeightsTableNameTest(word); // TODO: Initialize to an appropriate value
            string path = "file1"; // TODO: Initialize to an appropriate value
            int locationID = 1; // TODO: Initialize to an appropriate value
            double weight = 2.345; // TODO: Initialize to an appropriate value
            int counter = 2; // TODO: Initialize to an appropriate value
            model_instance.UpdateWordWeightTest(tableName, word, path, locationID, weight, counter);
            object[] result;
            model_instance.WordAndFileExistTest(word, path, tableName, out result);
            Assert.AreEqual(word.ToUpper(), result[0]);
            Assert.AreEqual(path, result[1]);
            Assert.AreEqual(locationID, result[2]);
            Assert.AreEqual(weight, result[3]);
            Assert.AreEqual(counter, result[4]);
        }

        /// <summary>
        ///A test for UpdateWordTFIDF
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void UpdateWordTFIDFTest()
        {
            PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string tableName = string.Empty; // TODO: Initialize to an appropriate value
            string word = string.Empty; // TODO: Initialize to an appropriate value
            string path = string.Empty; // TODO: Initialize to an appropriate value
            double tf = 0F; // TODO: Initialize to an appropriate value
            double idf = 0F; // TODO: Initialize to an appropriate value
            target.UpdateWordTFIDF(tableName, word, path, tf, idf);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExecuteSelectionQuery
        ///</summary>
        [DeploymentItem("Model.dll")]
        public void ExecuteSelectionQueryTest()
        {
            PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string query = string.Empty; // TODO: Initialize to an appropriate value
            OleDbDataReader expected = null; // TODO: Initialize to an appropriate value
            OleDbDataReader actual;
            actual = target.ExecuteSelectionQuery(query);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExecuteNonQuery
        ///</summary>
        [DeploymentItem("Model.dll")]
        public void ExecuteNonQueryTest()
        {
            PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string query = string.Empty; // TODO: Initialize to an appropriate value
            target.ExecuteNonQuery(query);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }        

        /// <summary>
        ///A test for CountFilesContains
        ///</summary>
        [TestMethod()]
        public void CountFilesContainsTest()
        {
            //PersistentModel_Accessor target = new PersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = "dome"; // TODO: Initialize to an appropriate value
            int expected = 2; // TODO: Initialize to an appropriate value
            int actual;
            actual = model_instance.CountFilesContains(word);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for DBClean
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void DBCleanTest()
        {
            //PersistentModel_Accessor target = new PersistentModel_Accessor();
            //Assert.Inconclusive("TODO: Implement code to verify target");
            model_instance.CleanDB();
        }
    }
}
