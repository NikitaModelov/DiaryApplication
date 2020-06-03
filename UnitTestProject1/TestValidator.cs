
using System;
using DiaryApplication.Utills;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class TestValidator
    {
        [DataTestMethod]
        [DataRow("Никита", LengthText.NameLength, true)]
        [DataRow("        ", LengthText.NameLength, false)]
        [DataRow("", LengthText.NameLength, false)]
        [DataRow("dsadsafsafgdfggsdgfdgsdfgdfgfdgsddfgdfgdfsgsdfgfdgfdgdfgfdsgdfsgfdgfdgdfgdsfgdfgdfsgdfsgdfsgdfgddddd", LengthText.NameLength, true)]
        [DataRow("dsadsafsafgdfggsdgfdgsdfgdfgfdgsddfgdfgdfsgsdfgfdgfdgdfgfdsgdfsgfdgfdgdfgdsfgdfgdfsgdfsgdfsgdfgddddgfgfgfghh", LengthText.NameLength, false)]
        public void TestNameValidation(string text, LengthText lengthText, bool expectedValue)
        {
            Assert.AreEqual(Validator.ValidateTextField(text, lengthText), expectedValue);
        }
    }
}
