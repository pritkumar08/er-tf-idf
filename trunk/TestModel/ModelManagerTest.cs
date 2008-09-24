using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TestModel
{


    /// <summary>
    ///This is a test class for ModelManagerTest and is intended
    ///to contain all ModelManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ModelManagerTest
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
        ///A test for normalize
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Model.dll")]
        public void normalizeTest()
        {
            ModelManager_Accessor target = new ModelManager_Accessor(); // TODO: Initialize to an appropriate value
            string word = "housing"; // TODO: Initialize to an appropriate value
            string expected = "hous"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.normalize(word);
            Assert.AreEqual(expected, actual);
            actual = target.normalize("house");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for InsertDocument
        ///</summary>
        [TestMethod()]
        public void InsertDocumentTest()
        {
            ModelManager target = new ModelManager(); // TODO: Initialize to an appropriate value
            List<string> words = target.getWords();
            string path = "D:\\Project in advanced programming\\TestModel\\XMLFile1.xml"; // TODO: Initialize to an appropriate value            
            target.InsertDocument(path);
            WordsBag b = target.getWordsBag(path);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for getWordsBag for all files
        ///</summary>
        [TestMethod()]
        public void getWordsBagTest1()
        {
            ModelManager target = new ModelManager(); // TODO: Initialize to an appropriate value
            List<WordsBag> expected = null; // TODO: Initialize to an appropriate value
            List<WordsBag> actual;
            string path = "D:\\Project in advanced programming\\TestModel\\XMLFile1.xml";
            target.InsertDocument(path);
            path = "D:\\Project in advanced programming\\TestModel\\XMLFile2.xml";
            target.InsertDocument(path);
            path = "D:\\Project in advanced programming\\TestModel\\XMLFile3.xml";
            target.InsertDocument(path);
            /*path = "D:\\Project in advanced programming\\TestModel\\XMLFile4.xml";
            target.InsertDocument(path);
            path = "D:\\Project in advanced programming\\TestModel\\XMLFile5.xml";
            target.InsertDocument(path);*/
            actual = target.getWordsBag();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for getWordsBag for a given file path
        ///</summary>
        [TestMethod()]
        public void getWordsBagTest()
        {
            ModelManager target = new ModelManager(); // TODO: Initialize to an appropriate value
            string path = "D:\\Project in advanced programming\\TestModel\\XMLFile1.xml";
            target.InsertDocument(path);
            WordsBag expected = null; // TODO: Initialize to an appropriate value
            WordsBag actual;
            actual = target.getWordsBag(path);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetInversionList
        ///</summary>
        [TestMethod()]
        public void GetInversionListTest()
        {
            ModelManager target = new ModelManager(); // TODO: Initialize to an appropriate value
            List<ProcessedWord> expected = null; // TODO: Initialize to an appropriate value
            List<ProcessedWord> actual;
            string path = "D:\\Project in advanced programming\\TestModel\\XMLFile1.xml";
            target.InsertDocument(path);
            path = "D:\\Project in advanced programming\\TestModel\\XMLFile2.xml";
            target.InsertDocument(path);
            path = "D:\\Project in advanced programming\\TestModel\\XMLFile3.xml";
            target.InsertDocument(path);
            actual = target.GetInversionList();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        /// A test for tagNewFile
        /// </summary>
        [TestMethod()]
        public void tagNewFileTest()
        {
            ModelManager target = new ModelManager(); // TODO: Initialize to an appropriate value
            List<ProcessedWord> expected = null; // TODO: Initialize to an appropriate value
            List<Record<string, double>> actual;
            WordsBag b11 = new WordsBag()
            {
                Name = "b11",
                Bag = new List<BagWord>() { 
                    new BagWord() { TfIdf = 1.0, Word = "w1" } ,
                    new BagWord() { TfIdf = 2.0, Word = "w2" } ,
                    new BagWord() { TfIdf = 3.0, Word = "w3" } 
                }
            };
            WordsBag b22 = new WordsBag()
            {
                Name = "b22",
                Bag = new List<BagWord>() { 
                    new BagWord() { TfIdf = 1.5, Word = "w1" } ,
                    new BagWord() { TfIdf = 1.0, Word = "w2" } ,
                    new BagWord() { TfIdf = 3.0, Word = "w4" } 
                }
            };
            Func<WordsBag, WordsBag, double> similarity = (b1, b2) =>
            (
            from w1 in b1.Bag
            from w2 in b2.Bag
            where w1.Word.Equals(w2.Word)
            select Math.Min(w1.TfIdf, w2.TfIdf)
            ).Sum(x => x) / (b1.Bag.Union(b2.Bag).Distinct().Count());
            double test = similarity(b11, b22);

            string path = "D:\\Project in advanced programming\\TestModel\\XMLFile6.xml";
            target.InsertDocument(path);
            path = "D:\\Project in advanced programming\\TestModel\\XMLFile7.xml";
            target.InsertDocument(path);
            string new_path = "D:\\Project in advanced programming\\TestModel\\XMLFile8.xml";
            actual = target.evaluateSimilarity(new_path, similarity);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ModelManager Constructor
        ///</summary>
        [TestMethod()]
        public void ModelManagerConstructorTest()
        {
            ModelManager target = new ModelManager();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    } 
}
