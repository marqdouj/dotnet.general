using Marqdouj.DotNet.General.Extensions;

namespace Marqdouj.DotNet.General.Tests
{
    [TestClass]
    public sealed class NumberTests
    {
        #region Byte

        [TestMethod]
        public void Object_IsNumber_Byte_False()
        {
            //Arrange
            const byte ba = (byte)'a';
            const byte b1 = 1;

            //Act
            var baIsNumber = ba.IsNumberTypeCode(false);
            var b1IsNumber = b1.IsNumberTypeCode(false);

            //Assert
            Assert.IsFalse(baIsNumber);
            Assert.IsFalse(b1IsNumber);
        }

        [TestMethod]
        public void Object_IsNumber_Byte_True()
        {
            //Arrange
            const byte ba = (byte)'a';
            const byte b1 = 1;

            //Act
            var baIsNumber = ba.IsNumberTypeCode(true);
            var b1IsNumber = b1.IsNumberTypeCode(true);

            //Assert
            Assert.IsTrue(baIsNumber);
            Assert.IsTrue(b1IsNumber);
        }

        #endregion

        #region SByte

        [TestMethod]
        public void Object_IsNumber_SByte_False()
        {
            //Arrange
            const sbyte ba = (sbyte)'a';
            const sbyte b1 = 1;

            //Act
            var baIsNumber = ba.IsNumberTypeCode(false);
            var b1IsNumber = b1.IsNumberTypeCode(false);

            //Assert
            Assert.IsFalse(baIsNumber);
            Assert.IsFalse(b1IsNumber);
        }

        [TestMethod]
        public void Object_IsNumber_SByte_True()
        {
            //Arrange
            const sbyte ba = (sbyte)'a';
            const sbyte b1 = 1;

            //Act
            var baIsNumber = ba.IsNumberTypeCode(true);
            var b1IsNumber = b1.IsNumberTypeCode(true);

            //Assert
            Assert.IsTrue(baIsNumber);
            Assert.IsTrue(b1IsNumber);
        }

        #endregion

        [TestMethod]
        public void Object_IsNumber()
        {
            //Arrange
            const UInt16 a = 1;
            const UInt32 b = 2;
            const UInt64 c = 3;
            const Int16 d = 4;
            const Int32 e = 5;
            const Int64 f = 6;
            const Decimal g = 7;
            const Double h = 8;
            const Single j = 9;

            //Act
            var aIsNumber = a.IsNumberTypeCode();
            var bIsNumber = b.IsNumberTypeCode();
            var cIsNumber = c.IsNumberTypeCode();
            var dIsNumber = d.IsNumberTypeCode();
            var eIsNumber = e.IsNumberTypeCode();
            var fIsNumber = f.IsNumberTypeCode();
            var gIsNumber = g.IsNumberTypeCode();
            var hIsNumber = h.IsNumberTypeCode();
            var jIsNumber = j.IsNumberTypeCode();

            //Assert
            Assert.IsTrue(aIsNumber);
            Assert.IsTrue(bIsNumber);
            Assert.IsTrue(cIsNumber);
            Assert.IsTrue(dIsNumber);
            Assert.IsTrue(eIsNumber);
            Assert.IsTrue(fIsNumber);
            Assert.IsTrue(gIsNumber);
            Assert.IsTrue(hIsNumber);
            Assert.IsTrue(jIsNumber);
        }

        [TestMethod]
        public void Object_IsNumber_False()
        {
            //Arrange
            const UInt16 a = 1;
            const UInt32 b = 2;
            const UInt64 c = 3;
            const Int16 d = 4;
            const Int32 e = 5;
            const Int64 f = 6;
            const Decimal g = 7;
            const Double h = 8;
            const Single j = 9;

            //Act
            var aIsNumber = a.IsNumberTypeCode(false);
            var bIsNumber = b.IsNumberTypeCode(false);
            var cIsNumber = c.IsNumberTypeCode(false);
            var dIsNumber = d.IsNumberTypeCode(false);
            var eIsNumber = e.IsNumberTypeCode(false);
            var fIsNumber = f.IsNumberTypeCode(false);
            var gIsNumber = g.IsNumberTypeCode(false);
            var hIsNumber = h.IsNumberTypeCode(false);
            var jIsNumber = j.IsNumberTypeCode(false);

            //Assert
            Assert.IsTrue(aIsNumber);
            Assert.IsTrue(bIsNumber);
            Assert.IsTrue(cIsNumber);
            Assert.IsTrue(dIsNumber);
            Assert.IsTrue(eIsNumber);
            Assert.IsTrue(fIsNumber);
            Assert.IsTrue(gIsNumber);
            Assert.IsTrue(hIsNumber);
            Assert.IsTrue(jIsNumber);
        }

        [TestMethod]
        public void Object_IsNumber_String()
        {
            //Arrange
            object value = "1";

            //Act
            var isNumber = value.IsNumberTypeCode();

            //Assert
            Assert.IsFalse(isNumber);
        }

        [TestMethod]
        public void Object_IsNumber_Null()
        {
            //Arrange
            object? value = null;

            //Act
            var isNumber = value.IsNumberTypeCode();

            //Assert
            Assert.IsFalse(isNumber);
        }

        [TestMethod]
        public void Object_IsNumber_Class()
        {
            //Arrange
            var item = new TestIsNumber();

            //Act
            var isNumber = item.IsNumberTypeCode();

            //Assert
            Assert.IsFalse(isNumber);
        }

        private class TestIsNumber { }
    }
}
