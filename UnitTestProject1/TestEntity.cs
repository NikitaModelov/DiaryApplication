using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryApplication.Core.Model;
using DiaryApplication.Tasks.Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class TestEntity
    {
        [DataTestMethod]
        [DataRow(1, "Type", 1, "Type")]
        public void TestTypeEntitySuccess(int id, string title, int expectedId, string expectedTitle)
        {
            var type = new TypeEntity(id, title);
            Assert.AreEqual(type.Title, expectedTitle);
            Assert.AreEqual(type.Id, expectedId);
        }

        [DataTestMethod]
        [DataRow(-1, "type")]
        [DataRow(1, "")]
        [DataRow(1, "  ")]
        public void TypeEntityError(int id, string title)
        {
            Assert.ThrowsException<Exception>(() => new TypeEntity(id, title));
        }

        [DataTestMethod]
        [DataRow(1, "Имя", "Фамилия", null, 1, "Имя", "Фамилия", null)]
        public void ProfileEntitySuccess(
            int id, 
            string firstName, 
            string secondName, 
            List<TaskEntity> tasks,
            int expectedId,
            string expectedFirstName,
            string expectedSecondName,
            List<TaskEntity> expectedTask)
        {
            var profile = new Profile(id, firstName, secondName, tasks);
            Assert.AreEqual(profile.FirstName, expectedFirstName);
            Assert.AreEqual(profile.SecondName, expectedSecondName);
            Assert.AreEqual(profile.Id, expectedId);
            Assert.AreEqual(profile.Tasks, expectedTask);
        }
    }
}
