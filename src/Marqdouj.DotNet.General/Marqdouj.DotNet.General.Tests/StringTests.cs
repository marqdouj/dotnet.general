using Marqdouj.DotNet.General.Extensions;

namespace Marqdouj.DotNet.General.Tests
{
    [TestClass]
    public sealed class StringTests
    {
        #region ToCrLf

        [TestMethod]
        public void Strings_ToCrLf_AtStart_CRLF()
        {
            //Arrange
            const string value = "\r\nThis is a test.";
            const string expected = "\r\nThis is a test.";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_ToCrLf_AtMiddle_CRLF()
        {
            //Arrange
            const string value = "This is\r\n a test.";
            const string expected = "This is\r\n a test.";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void Strings_ToCrLf_AtEnd_CRLF()
        {
            //Arrange
            const string value = "This is a test.\r\n";
            const string expected = "This is a test.\r\n";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_ToCrLf_AtStart_LF()
        {
            //Arrange
            const string value = "\nThis is a test.";
            const string expected = "\r\nThis is a test.";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_ToCrLf_AtMiddle_LF()
        {
            //Arrange
            const string value = "This is\n a test.";
            const string expected = "This is\r\n a test.";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void Strings_ToCrLf_AtEnd_LF()
        {
            //Arrange
            const string value = "This is a test.\n";
            const string expected = "This is a test.\r\n";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_ToCrLf_AtStart_MIXED()
        {
            //Arrange
            const string value = "\r\n\nThis is a test.";
            const string expected = "\r\n\r\nThis is a test.";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_ToCrLf_AtMiddle_MIXED()
        {
            //Arrange
            const string value = "This is\r\n\n a test.";
            const string expected = "This is\r\n\r\n a test.";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void Strings_ToCrLf_AtEnd_MIXED()
        {
            //Arrange
            const string value = "This is a test.\r\n\n";
            const string expected = "This is a test.\r\n\r\n";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_ToCrLf_NoLineFeed()
        {
            //Arrange
            const string value = "This is a test.";
            const string expected = "This is a test.";
            //Act
            var result = value.ToCrLf();
            //Assert
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region NList Double

        [TestMethod]
        public void NList_Double()
        {
            var value = "1.1,2,3.59";
            var items = value.ToNList<double>();
            Assert.HasCount(3, items);
            Assert.AreEqual(1.1, items[0]);
            Assert.AreEqual(2, items[1]);
            Assert.AreEqual(3.59, items[2]);
        }

        [TestMethod]
        public void NList_Double_WithEmpty()
        {
            var value = "1.1,,,2, ,3.59,, ,";
            var items = value.ToNList<double>();
            Assert.HasCount(3, items);
            Assert.AreEqual(1.1, items[0]);
            Assert.AreEqual(2, items[1]);
            Assert.AreEqual(3.59, items[2]);
        }

        [TestMethod]
        public void NList_Double_InvalidString()
        {
            var value = "1.1,x,3";
            Assert.Throws<FormatException>(() => value.ToNList<double>());
        }

        [TestMethod]
        public void NList_Double_Mixed()
        {
            var value = "1.6,2,3.999";
            var items = value.ToNList<double>();
            Assert.HasCount(3, items);
            Assert.AreEqual(1.6, items[0]);
            Assert.AreEqual(2, items[1]);
            Assert.AreEqual(3.999, items[2]);
        }

        #endregion

        #region NList Int

        [TestMethod]
        public void NList_Int()
        {
            var value = "1,2,3";
            var items = value.ToNList<int>();
            Assert.HasCount(3, items);
            Assert.AreEqual(1, items[0]);
            Assert.AreEqual(2, items[1]);
            Assert.AreEqual(3, items[2]);
        }

        [TestMethod]
        public void NList_Int_WithEmpty()
        {
            var value = "1,,2, ,3,, ,";
            var items = value.ToNList<int>();
            Assert.HasCount(3, items);
            Assert.AreEqual(1, items[0]);
            Assert.AreEqual(2, items[1]);
            Assert.AreEqual(3, items[2]);
        }

        [TestMethod]
        public void NList_Int_InvalidString()
        {
            var value = "1,x,3";
            Assert.Throws<FormatException>(() => value.ToNList<int>());
        }

        [TestMethod]
        public void NList_Int_Mixed()
        {
            var value = "1.6,2.3,3.999";
            var items = value.ToNList<int>();
            Assert.HasCount(3, items);
            Assert.AreEqual(1, items[0]);
            Assert.AreEqual(2, items[1]);
            Assert.AreEqual(3, items[2]);
        }

        #endregion

        #region Truncate

        [TestMethod]
        public void Strings_Truncate_MaxLengthEqual()
        {
            //Arrange
            const string value = "This is a test.";
            var maxLength = value.Length;
            const string suffix = Strings.ELLIPSIS;
            const string expected = value;
            var expectedLength = value.Length;

            //Act
            var result = value.Truncate(maxLength, suffix);

            //Assert
            Assert.AreEqual(expectedLength, result!.Length);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_Truncate_MaxLengthLess()
        {
            //Arrange
            const string value = "This is a test.";
            const int maxLength = 5;
            const string suffix = Strings.ELLIPSIS;
            const string expected = "This " + Strings.ELLIPSIS;
            var expectedLength = maxLength + suffix.Length;

            //Act
            var result = value.Truncate(maxLength, suffix);

            //Assert
            Assert.AreEqual(expectedLength, result!.Length);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_Truncate_MaxLengthMore()
        {
            //Arrange
            const string value = "This is a test.";
            var maxLength = value.Length + 1;
            const string suffix = Strings.ELLIPSIS;
            const string expected = value;
            var expectedLength = value.Length;

            //Act
            var result = value.Truncate(maxLength, suffix);

            //Assert
            Assert.AreEqual(expectedLength, result!.Length);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_Truncate_MaxLengthZero()
        {
            //Arrange
            const string value = "This is a test.";
            const int maxLength = 0;
            const string suffix = Strings.ELLIPSIS;
            const string expected = Strings.ELLIPSIS;
            var expectedLength = Strings.ELLIPSIS.Length;

            //Act
            var result = value.Truncate(maxLength, suffix);

            //Assert
            Assert.AreEqual(expectedLength, result!.Length);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Strings_Truncate_MaxLengthLessThanZero()
        {
            //Arrange
            const string value = "This is a test.";
            const int maxLength = -1;
            const string suffix = Strings.ELLIPSIS;

            //Act/Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => value.Truncate(maxLength, suffix));
        }

        #endregion
    }
}
