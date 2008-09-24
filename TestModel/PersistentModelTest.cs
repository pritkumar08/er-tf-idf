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
            InsertWord("dome", "file1", 1, 1.242);
            InsertWord("dome", "file2", 12, 0.03);
            InsertWord("dome","file1",12,0.005);
            double tw = model_instance.GetTotalWeight("DOME", "file1");
            Assert.AreEqual(1.247, tw);         
        }
        public void InsertWord(string word, string path, int location, double weight)
        {
            model_instance.InsertWord(word, path, location, weight);
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
            /*
            actual = model_instance.WordAndFileExistTest(word, path, tableName, out result);
            Assert.AreEqual(resultExpected, result);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
             */
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
            /*
            model_instance.WordAndFileExistTest(word, path, tableName, out result);
            Assert.AreEqual(word.ToUpper(), result[0]);
            Assert.AreEqual(path, result[1]);
            Assert.AreEqual(locationID, result[2]);
            Assert.AreEqual(weight, result[3]);
            Assert.AreEqual(counter, result[4]);
             */
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

        [TestMethod()]
        public void GetWordsTest()
        {        
            List<string> expected = new List<string>(){};
            List<string> actual = model_instance.getWords();
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count;i++ )
                Assert.AreEqual(expected[i], actual[i]);
            InsertWord("w1", "f1", 1, 1.0);
            InsertWord("w1", "f2", 1, 1.0);
            InsertWord("w2", "f1", 1, 1.0);
            InsertWord("w3", "f1", 1, 1.0);
            InsertWord("w1", "f1", 2, 1.0);
            InsertWord("w1", "f1", 1, 1.0);
            actual = model_instance.getWords();
            expected.AddRange(new string[]{"W1","W2","W3"});
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
                Assert.AreEqual(expected[i], actual[i]);


            //List<RawWord> getFileWords(string path);
            //List<Location> getWordLocations(string w);
        }

        [TestMethod()]
        public void getFileWords()
        {
            List<RawWord> expected = new List<RawWord>() { };
            InsertWord("w1", "f1", 1, 1.0);
            InsertWord("w1", "f2", 1, 1.0);
            InsertWord("w2", "f1", 1, 1.0);
            InsertWord("w3", "f1", 1, 1.0);
            InsertWord("w1", "f1", 2, 1.0);
            InsertWord("w1", "f1", 1, 1.0);
            List<RawWord> actual = model_instance.getFileWords("f1");
            expected.AddRange(new RawWord[] { 
                new RawWord(){Text="W1",LocationID=1,Weight=2.0},
                new RawWord(){Text="W2",LocationID=1,Weight=1.0},
                new RawWord(){Text="W3",LocationID=1,Weight=1.0},
                new RawWord(){Text="W1",LocationID=2,Weight=1.0}
            });
            CollectionAssert.AreEquivalent(expected, actual);            
            actual = model_instance.getFileWords("f2");
            expected.Clear();
            expected.AddRange(new RawWord[] { 
                new RawWord(){Text="W1",LocationID=1,Weight=1.0}
            });
            CollectionAssert.AreEquivalent(expected, actual);
            expected.Clear();
            actual = model_instance.getFileWords("f3");
            CollectionAssert.AreEquivalent(expected, actual);            
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
