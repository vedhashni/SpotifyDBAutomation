/*summary :DB Automation for Insert and select query
  Author: Vedhashni V
  Date  : 20-08-21
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System;

namespace SpotifyDBAutomation
{
    
    [TestClass]
    public class UnitTest1
    {
        SpotifyAutomation model;
        
        [TestInitialize]
        public void setup()
        {
            model = new SpotifyAutomation();
            
        }
        [DataRow(5, "track9", "QWE")]
        [DataRow(2, "track9", "RTY")]
        [DataRow(3, "track9", "UIO")]
        [DataRow(4, "track2", "PAS")]
        [DataRow(1, "track5", "HJL")]
        [DataRow(3, "track4", "ZXC")]
        [DataTestMethod]
        [Priority(1)]
        [TestMethod]
        public void TestMethod1ForInsert(int a, String b, String c)
        {
            
            int expected = 1;
            SpotifyModel model1 = new SpotifyModel();
            var actual = model.InsertIntoTable(a,b,c);
            Assert.AreEqual(expected, actual); 
        }

        [Priority(2)]
        [TestMethod]
        public void TestMethod2ForRetrive()
        {
            int expected = 9;
            var actual = model.retriveData();
            Assert.AreEqual(expected, actual);
        }

        [Priority(3)]
        [TestMethod]
        public void TestMethod3ForUpdate()
        {
            int expected = 1;
            SpotifyModel model1 = new SpotifyModel();
            var actual = model.EditExistingContact(model1);
            Assert.AreEqual(expected, actual);
        }

        [Priority(4)]
        [TestMethod]
        public void TestMethod4ForDelete()
        {
            int expected = 1;
            SpotifyModel model2 = new SpotifyModel();
            var actual = model.Delete(model2);
            Assert.AreEqual(expected, actual);
        }
    }
}
  


    




    

