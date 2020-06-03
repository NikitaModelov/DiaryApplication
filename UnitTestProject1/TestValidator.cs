
using System;
using System.Text;
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

        [DataTestMethod]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", LengthText.TitleLength, true )]
        [DataRow("Title", LengthText.TitleLength, true)]
        [DataRow("Title   ", LengthText.TitleLength, true)]
        [DataRow("     ", LengthText.TitleLength, false)]
        [DataRow("", LengthText.TitleLength, false)]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaфффф", LengthText.TitleLength, false)]
        public void TestTitleValidation(string text, LengthText lengthText, bool expectedValue)
        {
            Assert.AreEqual(Validator.ValidateTextField(text, lengthText), expectedValue);
        }

        [DataTestMethod]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaa", LengthText.SubtitleLength, true)]
        [DataRow("Subtitle", LengthText.SubtitleLength, true)]
        [DataRow("Subtitle   ", LengthText.SubtitleLength, true)]
        [DataRow("", LengthText.SubtitleLength, false)]
        [DataRow("    ", LengthText.SubtitleLength, false)]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaggggggggg", LengthText.SubtitleLength, false)]
        public void TestSubtitleValidation(string text, LengthText lengthText, bool expectedValue)
        {
            Assert.AreEqual(Validator.ValidateTextField(text, lengthText), expectedValue);
        }

        [DataTestMethod]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaa", LengthText.DescriptionLength, true)]
        [DataRow("DescriptionLength", LengthText.DescriptionLength, true)]
        [DataRow("DescriptionLength   ", LengthText.DescriptionLength, true)]
        [DataRow("", LengthText.DescriptionLength, false)]
        [DataRow("    ", LengthText.DescriptionLength, false)]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                 "aaaaaaaaaaaaaaaaaaaaaaaaffffff", LengthText.DescriptionLength, false)]
        public void TestDescriptionValidation(string text, LengthText lengthText, bool expectedValue)
        {
            Assert.AreEqual(Validator.ValidateTextField(text, lengthText), expectedValue);
        }

        [DataTestMethod]
        [DataRow("TypeTypeTypeTypeType" , LengthText.TypeLength, true)]
        [DataRow("Type", LengthText.TypeLength, true)]
        [DataRow("Type   ", LengthText.TypeLength, true)]
        [DataRow("TypeTypeTypeTypeTypeTypeTypeTypeTypeType", LengthText.TypeLength, false)]
        [DataRow("    ", LengthText.TypeLength, false)]
        [DataRow("", LengthText.TypeLength, false)]
        public void TestTypeValidation(string text, LengthText lengthText, bool expectedValue)
        {
            Assert.AreEqual(Validator.ValidateTextField(text, lengthText), expectedValue);
        }
    }
}
