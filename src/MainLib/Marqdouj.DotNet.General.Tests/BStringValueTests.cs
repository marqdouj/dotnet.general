namespace Marqdouj.DotNet.General.Tests
{
    [TestClass]
    public sealed class BStringValueTests
    {
        #region BStringValue

        [TestMethod]
        public void BStringValue_Create_WithDefaults()
        {
            var svalue = new BStringValue();
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.IsFalse(svalue.Value);
        }

        [TestMethod]
        public void BStringValue_Create_WithValue_False()
        {
            var value = false;
            var svalue = new BStringValue(value);
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.AreEqual(value, svalue.Value);
        }

        [TestMethod]
        public void BStringValue_Create_WithValue_True()
        {
            var value = true;
            var svalue = new BStringValue(value);
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.AreEqual(value, svalue.Value);
        }

        [TestMethod]
        public void BStringValue_SetValue_Null()
        {
            string? value = null;
            var svalue = new BStringValue
            {
                StringValue = value
            };
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.IsFalse(svalue.Value);
        }

        [TestMethod]
        public void BStringValue_SetValue_True()
        {
            string? value = true.ToString();
            var svalue = new BStringValue
            {
                StringValue = value
            };
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.AreEqual(value, svalue.StringValue);
        }

        [TestMethod]
        public void BStringValue_SetValue_False()
        {
            string? value = false.ToString();
            var svalue = new BStringValue
            {
                StringValue = value
            };
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.AreEqual(value, svalue.StringValue);
        }

        [TestMethod]
        public void BStringValue_SetValue_Invalid()
        {
            string? value = "this is bad!";
            var svalue = new BStringValue
            {
                StringValue = value
            };
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.IsFalse(svalue.Value);
        }

        [TestMethod]
        public void BStringValue_SetValue_Invalid_OverwriteValid()
        {
            string? value = "this is bad!";
            var svalue = new BStringValue(true)
            {
                StringValue = value
            };
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.IsTrue(svalue.Value);
        }

        #endregion

        #region BStringValueN

        [TestMethod]
        public void BStringValueN_Create_WithDefaults()
        {
            var svalue = new BStringValueN();
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.IsNull(svalue.Value);
        }

        [TestMethod]
        public void BStringValueN_Create_WithValue_False()
        {
            var value = false;
            var svalue = new BStringValueN(value);
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.AreEqual(value, svalue.Value);
        }

        [TestMethod]
        public void BStringValueN_Create_WithValue_True()
        {
            var value = true;
            var svalue = new BStringValueN(value);
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.AreEqual(value, svalue.Value);
        }

        [TestMethod]
        public void BStringValueN_Create_WithNullableValue_Null()
        {
            bool? value = null;
            var svalue = new BStringValueN(value);
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.AreEqual(value, svalue.Value);
        }

        [TestMethod]
        public void BStringValueN_Create_WithNullableValue_False()
        {
            bool? value = false;
            var svalue = new BStringValueN(value);
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.AreEqual(value, svalue.Value);
        }

        [TestMethod]
        public void BStringValueN_Create_WithNullableValue_True()
        {
            bool? value = true;
            var svalue = new BStringValueN(value);
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.AreEqual(value, svalue.Value);
        }

        [TestMethod]
        public void BStringValueN_SetValue_Null()
        {
            string? value = null;
            var svalue = new BStringValueN
            {
                StringValue = value
            };
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.AreEqual(value, svalue.StringValue);
        }

        [TestMethod]
        public void BStringValueN_SetValue_True()
        {
            string? value = true.ToString();
            var svalue = new BStringValueN
            {
                StringValue = value
            };
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.AreEqual(value, svalue.StringValue);
        }

        [TestMethod]
        public void BStringValueN_SetValue_False()
        {
            string? value = false.ToString();
            var svalue = new BStringValueN
            {
                StringValue = value
            };
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.AreEqual(value, svalue.StringValue);
        }

        [TestMethod]
        public void BStringValueN_SetValue_Invalid()
        {
            string? value = "this is bad!";
            var svalue = new BStringValueN
            {
                StringValue = value
            };
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.IsNull(svalue.StringValue);
        }

        [TestMethod]
        public void BStringValueN_SetValue_Invalid_OverwriteValid()
        {
            string? value = "this is bad!";
            var svalue = new BStringValueN(true)
            {
                StringValue = value
            };
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.IsTrue(svalue.Value);
        }

        #endregion
    }
}
