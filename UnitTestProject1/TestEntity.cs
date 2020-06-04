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
        #region TypeEntityTest

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

        #endregion

        #region ProfileEntityTest

        [DataTestMethod]
        [DataRow(1, "Имя", "Фамилия", 1, "Имя", "Фамилия")]
        public void ProfileEntitySuccess(
            int id,
            string firstName,
            string secondName,
            int expectedId,
            string expectedFirstName,
            string expectedSecondName )
        {
            var profile = new Profile(id, firstName, secondName, new List<TaskEntity>());
            Assert.AreEqual(profile.FirstName, expectedFirstName);
            Assert.AreEqual(profile.SecondName, expectedSecondName);
            Assert.AreEqual(profile.Id, expectedId);
        }

        [DataTestMethod]
        [DataRow(1, " ", " ")]
        public void ProfileEntityError(
            int id,
            string firstName,
            string secondName)
        {
            Assert.ThrowsException<Exception>(() => new Profile(id, firstName, secondName, new List<TaskEntity>()));
        }

        #endregion

        #region IntervalTest

        [TestMethod]
        public void TestIntervalEntitySuccess()
        {
            var startTime = DateTime.Now;
            var finishTime = DateTime.Parse("01:00:00 04.06.2020");

            var interval = new Interval(1, startTime, finishTime, 3);
            var expectedId = 1;
            var expectedStartTime = startTime;
            var expectedFinishTime = finishTime;
            double expectedRating = 3;

            Assert.AreEqual(expectedId, interval.Id);
            Assert.AreEqual(expectedStartTime, interval.StartTime);
            Assert.AreEqual(expectedFinishTime, interval.FinishTime);
            Assert.AreEqual(expectedRating, interval.Rating);
        }

        [TestMethod]
        public void TestIntervalError()
        {
            var startTime = DateTime.Now;
            var finishTime = DateTime.Parse("01:00:00 04.06.2020");

            Assert.ThrowsException<Exception>(() => new Interval(-1, startTime, finishTime, 2));
            Assert.ThrowsException<Exception>(() => new Interval(1, startTime, finishTime, -2));
        }

        #endregion

        #region TestTaskEntity

        [TestMethod]
        public void TestTaskEntitySuccess()
        {
            var id = 1;
            var title = "Title";
            var subtitle = "Subtitle";
            var description = "Description";
            var addTime = DateTime.Now;
            var lastChangeTime = DateTime.Now;
            var isClosed = false;
            var types = new List<TypeEntity>();
            var intervals = new List<Interval>();

            var expectedId = id;
            var expectedTitle = "Title";
            var expectedSubtitle = "Subtitle";
            var expectedDescription = "Description";
            var expectedAddTime = addTime;
            var expectedLastChangeTime = lastChangeTime;
            var expectedIsClosed = false;
            var expectedTypes = types;
            var expectedIntervals = intervals;

            var task = new TaskEntity(id, title, subtitle, description, addTime, lastChangeTime, isClosed, types, intervals);

            Assert.AreEqual(expectedId, task.Id);
            Assert.AreEqual(expectedTitle, task.Title);
            Assert.AreEqual(expectedSubtitle, task.Subtitle);
            Assert.AreEqual(expectedDescription, task.Description);
            Assert.AreEqual(expectedAddTime, task.AddTime);
            Assert.AreEqual(expectedLastChangeTime, task.LastChangeTime);
            Assert.AreEqual(expectedIsClosed, task.IsClosed);
            Assert.AreEqual(expectedTypes, task.Types);
            Assert.AreEqual(expectedIntervals, task.Intervals);
        }

        [TestMethod]
        public void TestTaskEntitError()
        {
            Assert.ThrowsException<Exception>(() => new TaskEntity(
                -1,
                "Title",
                "Subtitle",
                "Description",
                DateTime.Now,
                DateTime.Now,
                false,
                new List<TypeEntity>(),
                new List<Interval>()));
            Assert.ThrowsException<Exception>(() => new TaskEntity(
                1,
                "  ",
                "  ",
                "  ",
                DateTime.Now,
                DateTime.Now,
                false,
                new List<TypeEntity>(),
                new List<Interval>()));

        }


        #endregion

    }
}
