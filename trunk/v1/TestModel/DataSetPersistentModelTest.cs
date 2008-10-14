using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.OleDb;
using System.Collections.Generic;
using System;
using System.Linq;

namespace TestModel
{
    
    
    /// <summary>
    ///This is a test class for DataSetPersistentModelTest and is intended
    ///to contain all DataSetPersistentModelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DataSetPersistentModelTest
    {


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
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
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
        ///A test for UpdateWordWeightTest
        ///</summary>
        [TestMethod()]
        public void UpdateWordWeightTestTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string tableName = string.Empty; // TODO: Initialize to an appropriate value
            string word = string.Empty; // TODO: Initialize to an appropriate value
            string path = string.Empty; // TODO: Initialize to an appropriate value
            int locationID = 0; // TODO: Initialize to an appropriate value
            double weight = 0F; // TODO: Initialize to an appropriate value
            int counter = 0; // TODO: Initialize to an appropriate value
            target.UpdateWordWeightTest(tableName, word, path, locationID, weight, counter);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for UpdateWordWeight
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void UpdateWordWeightTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string tableName = string.Empty; // TODO: Initialize to an appropriate value
            string word = string.Empty; // TODO: Initialize to an appropriate value
            string path = string.Empty; // TODO: Initialize to an appropriate value
            int locationID = 0; // TODO: Initialize to an appropriate value
            double weight = 0F; // TODO: Initialize to an appropriate value
            int counter = 0; // TODO: Initialize to an appropriate value
            target.UpdateWordWeight(tableName, word, path, locationID, weight, counter);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }


        /// <summary>
        ///A test for InsertWordTF
        ///</summary>
        [TestMethod()]
        public void InsertWordTFTest1()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = string.Empty; // TODO: Initialize to an appropriate value
            string path = string.Empty; // TODO: Initialize to an appropriate value
            double tf = 0F; // TODO: Initialize to an appropriate value
            target.InsertWordTF(word, path, tf);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }


        /// <summary>
        ///A test for InsertWord
        ///</summary>
        [TestMethod()]
        public void InsertWordTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = string.Empty; // TODO: Initialize to an appropriate value
            string path = string.Empty; // TODO: Initialize to an appropriate value
            int locationID = 0; // TODO: Initialize to an appropriate value
            double weight = 0F; // TODO: Initialize to an appropriate value
            target.InsertWord(word, path, locationID, weight);
        }

        /// <summary>
        ///A test for getWords
        ///</summary>
        [TestMethod()]
        public void getWordsTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            List<string> expected = new List<string>();
            List<string> actual;
            actual = target.getWords();
            Assert.AreEqual(Enumerable.SequenceEqual(expected, actual), true);
        }

        /// <summary>
        ///A test for getWordLocations
        ///</summary>
        [TestMethod()]
        public void getWordLocationsTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string w = "first";
            List<Location> expected = new List<Location>();
            List<Location> actual;
            target.CleanDB();
            actual = target.getWordLocations(w);
            Assert.AreEqual(Enumerable.SequenceEqual(expected, actual), true);
            target.InsertWord("first", "file1", 2, 1.0);
            target.InsertWord("first", "file1", 2, 1.0);
            target.InsertWord("third", "file1", 12, 4.0);
            target.InsertWord("first", "file2", 21, 5.6);
            target.InsertWord("first", "file1", 21, 0.67);
            actual = target.getWordLocations(w);
            expected.Add(new Location() { FileName = "file1",LocationID = 2, Weight =  2.0});
            expected.Add(new Location() { FileName = "file2", LocationID = 21, Weight = 5.6 });
            expected.Add(new Location() { FileName = "file1", LocationID = 21, Weight = 0.67 });
            Assert.AreEqual(Enumerable.Except(expected, actual).Count(), 0);
            Assert.AreEqual(Enumerable.Except(actual,expected).Count(), 0);
        }

        /// <summary>
        ///A test for getWeight
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void getWeightTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = string.Empty; // TODO: Initialize to an appropriate value
            string path = string.Empty; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.getWeight(word, path);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetTotalWeights
        ///</summary>
        [TestMethod()]
        public void GetTotalWeightsTest()
        {
            DataSetPersistentModel_Accessor target = 
                new DataSetPersistentModel_Accessor();
            string path = "file1";
            double expected = 0.0;
            double actual;
            target.CleanDB();
            actual = target.GetTotalWeights(path);
            Assert.AreEqual(expected, actual);
            target.InsertWord("first", "file1", 2, 1.0);
            target.InsertWord("second", "file1", 2, 1.0);
            target.InsertWord("third", "file1", 12, 4.0);
            target.InsertWord("first", "file2", 21, 5.6);
            actual = target.GetTotalWeights(path);
            expected = 6.0;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetTotalWeight
        ///</summary>
        [TestMethod()]
        public void GetTotalWeightTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = "first";
            string path = "file1";
            double expected = 0.0;
            double actual;
            target.CleanDB();
            actual = target.GetTotalWeight(word, path);
            Assert.AreEqual(expected, actual);
            target.InsertWord("first", "file1", 2, 1.0);
            target.InsertWord("first", "file1", 2, 1.0);
            target.InsertWord("first", "file1", 12, 1.4);
            target.InsertWord("first", "file1", 21, 5.6);
            actual = target.GetTotalWeight(word, path);
            expected = 9.0;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetTFByWordAndFile
        ///</summary>
        [TestMethod()]
        public void GetTFByWordAndFileTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = string.Empty; // TODO: Initialize to an appropriate value
            string path = string.Empty; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.GetTFByWordAndFile(word, path);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getTableName
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void getTableNameTest()
        {
            string word = string.Empty; // TODO: Initialize to an appropriate value
            Type tType = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = DataSetPersistentModel_Accessor.getTableName(word, tType);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getInstance
        ///</summary>
        [TestMethod()]
        public void getInstanceTest()
        {
            List<string> expected = new List<string>(); 
            DataSetPersistentModel actual;
            actual = DataSetPersistentModel.getInstance();
            actual.CleanDB();
            List<string> words = actual.getWords();
            Assert.AreEqual(Enumerable.SequenceEqual(expected, words), true);
        }

        /// <summary>
        ///A test for GetIDFByWordAndFile
        ///</summary>
        [TestMethod()]
        public void GetIDFByWordAndFileTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = string.Empty; // TODO: Initialize to an appropriate value
            string path = string.Empty; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.GetIDFByWordAndFile(word, path);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getFileWords
        ///</summary>
        [TestMethod()]
        public void getFileWordsTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string path = "file1";
            List<RawWord> expected = new List<RawWord>();
            List<RawWord> actual;
            actual = target.getFileWords(path);
            Assert.AreEqual(Enumerable.SequenceEqual(expected, actual), true);
            target.InsertWord("first", "file1", 2, 1.0);
            target.InsertWord("first", "file2", 2, 1.0);
            target.InsertWord("second", "file1", 3, 1.0);
            actual = target.getFileWords(path);
            expected.Add(new RawWord("first", 2, 1.0));
            expected.Add(new RawWord("second", 3, 1.0));
            Assert.AreEqual(Enumerable.SequenceEqual(expected, actual), true);
        }

        /// <summary>
        ///A test for getFilesCount
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void getFilesCountTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            string word = "first";
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.getFilesCount(word);
            Assert.AreEqual(expected, actual);
            target.InsertWord(word, "file1", 2, 1.0);
            target.InsertWord(word, "file2", 2, 1.0);
            actual = target.getFilesCount(word);
            expected = 2;
            Assert.AreEqual(expected, actual);
        }
        
        /// <summary>
        ///A test for getFiles
        ///</summary>
        [TestMethod()]
        public void getFilesTest1()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            List<string> expected = new List<string>();
            List<string> actual;
            string word = "first";
            actual = target.getFiles(word);
            Assert.AreEqual(Enumerable.SequenceEqual(expected, actual), true);
            target.InsertWord(word, "file1", 2, 1.0);
            target.InsertWord(word, "file2", 2, 1.0);
            expected.Add("file1");
            expected.Add("file2");
            actual = target.getFiles(word);
            AssertUnOrderedSequenceEqual(expected, actual);
        }

        /// <summary>
        /// compares two sequences using set comparison e.g. 
        /// expected == actual <=> expected\actual = actual\expected = empty_sequence
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        private static void AssertUnOrderedSequenceEqual<T>(List<T> expected, List<T> actual)
        {
            Assert.AreEqual(Enumerable.Except(expected, actual).Count(), 0);
            Assert.AreEqual(Enumerable.Except(actual, expected).Count(), 0);
        }

        /// <summary>
        ///A test for getFiles
        ///</summary>
        [TestMethod()]
        public void getFilesTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            List<string> expected = new List<string>();
            List<string> actual;
            actual = target.getFiles();
            Assert.AreEqual(Enumerable.SequenceEqual(expected, actual), true);
            target.InsertWord("first", "file1", 2, 1.0);
            actual = target.getFiles();
            expected.Add("file1");
            Assert.AreEqual(Enumerable.SequenceEqual(expected, actual), true);
            target.InsertWord("first", "file2", 2, 1.0);
            actual = target.getFiles();
            expected.Add("file2");
            Assert.AreEqual(Enumerable.SequenceEqual(expected, actual), true);
        }

        /// <summary>
        ///A test for FilesCount
        ///</summary>
        [TestMethod()]
        public void FilesCountTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            int expected = 3;
            int actual;
            target.CleanDB();
            target.InsertWord("first", "file1", 2, 1.0);
            target.InsertWord("first", "file2", 2, 1.0);
            target.InsertWord("first", "file3", 2, 1.0);
            target.InsertWord("second", "file1", 2, 1.0);
            actual = target.FilesCount();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for CountFilesContains
        ///</summary>
        [TestMethod()]
        public void CountFilesContainsTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            int actual;
            int expected = 1;
            target.CleanDB();
            target.InsertWord("first", "file1", 2, 1.0);
            actual = target.CountFilesContains("first");
            Assert.AreEqual(expected, actual);
            target.InsertWord("first", "file1", 2, 1.0);
            actual = target.CountFilesContains("first");
            Assert.AreEqual(expected, actual);
            double ex = target.getWeight("first", "file1");
            Assert.AreEqual(ex,2.0);
        }

        /// <summary>
        ///A test for CleanDB
        ///</summary>
        [TestMethod()]
        public void CleanDBTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor(); // TODO: Initialize to an appropriate value
            target.CleanDB();
            Assert.AreEqual(target.getWords(), new List<string>());
        }

        /// <summary>
        ///A test for DataSetPersistentModel Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void DataSetPersistentModelConstructorTest()
        {
            DataSetPersistentModel_Accessor target = new DataSetPersistentModel_Accessor();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
