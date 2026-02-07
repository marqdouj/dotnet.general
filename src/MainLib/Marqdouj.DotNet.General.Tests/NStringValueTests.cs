namespace Marqdouj.DotNet.General.Tests
{
    [TestClass]
    public sealed class NStringValueTests
    {
        #region NStringValue

        [TestMethod]
        public void NStringValue_Create_WithDefaults()
        {
            var svalue = new NStringValue<double>();
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.AreEqual(0, svalue.Value);
        }

        [TestMethod]
        public void NStringValue_Create_WithValue()
        {
            double value = 1.999;
            var svalue = new NStringValue<double>(value);
            Assert.AreEqual(value, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValue_WithMinMax_ValueGood()
        {
            double value = 1.999;
            var svalue = new NStringValue<double>(value);
            svalue.SetMinMax(1, 2);
            Assert.AreEqual(value, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");

            svalue.StringValue = "1.567";
            Assert.AreEqual("1.567", svalue.StringValue);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValue_WithMinMax_ValueLess()
        {
            double value = 0.999;
            var svalue = new NStringValue<double>(value);
            svalue.SetMinMax(1, 2);
            Assert.AreEqual(1, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValue_WithMinMax_ValueGreater()
        {
            double value = 2.999;
            var svalue = new NStringValue<double>(value);
            svalue.SetMinMax(1, 2);
            Assert.AreEqual(2, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValue_WithMinMax_SetValueNull()
        {
            var svalue = new NStringValue<double>(1.5);
            svalue.SetMinMax(1, 2);
            Assert.AreEqual(1.5, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
            svalue.StringValue = null;
            Assert.AreEqual(1.5, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValue_WithMin_ValueLess()
        {
            double value = 0.999;
            var svalue = new NStringValue<double>(value);
            svalue.SetMinMax(1, null);
            Assert.AreEqual(1, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValue_WithMin_ValueGreater()
        {
            double value = 2.999;
            var svalue = new NStringValue<double>(value);
            svalue.SetMinMax(1, null);
            Assert.AreEqual(value, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValue_WithMax_ValueLess()
        {
            double value = 0.999;
            var svalue = new NStringValue<double>(value);
            svalue.SetMinMax(null, 1);
            Assert.AreEqual(value, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValue_WithMax_ValueGreater()
        {
            double value = 2.999;
            var svalue = new NStringValue<double>(value);
            svalue.SetMinMax(null, 1);
            Assert.AreEqual(1, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        #endregion

        #region NStringValueN

        [TestMethod]
        public void NStringValueN_Create_WithDefaults()
        {
            var svalue = new NStringValueN<double>();
            Console.WriteLine($"Value:{svalue.StringValue}");
            Assert.IsNull(svalue.Value);
        }

        [TestMethod]
        public void NStringValueN_Create_WithValue()
        {
            double value = 1.999;
            var svalue = new NStringValueN<double>(value);
            Assert.AreEqual(value, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValueN_Create_WithValueN()
        {
            double? value = 1.999;
            var svalue = new NStringValueN<double>(value);
            Assert.AreEqual(value, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValueN_WithMinMax_ValueGood()
        {
            double? value = 1.999;
            var svalue = new NStringValueN<double>(value);
            svalue.SetMinMax(1, 2);
            Assert.AreEqual(value, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");

            svalue.StringValue = "1.567";
            Assert.AreEqual("1.567", svalue.StringValue);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValueN_WithMinMax_ValueLess()
        {
            double? value = 0.999;
            var svalue = new NStringValueN<double>(value);
            svalue.SetMinMax(1, 2);
            Assert.AreEqual(1, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValueN_WithMinMax_ValueGreater()
        {
            double? value = 2.999;
            var svalue = new NStringValueN<double>(value);
            svalue.SetMinMax(1, 2);
            Assert.AreEqual(2, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValueN_WithMinMax_SetValueNull()
        {
            var svalue = new NStringValueN<double>(1.5);
            svalue.SetMinMax(1, 2);
            Assert.AreEqual(1.5, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
            svalue.StringValue = null;
            Assert.IsNull(svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValueN_WithMin_ValueLess()
        {
            double? value = 0.999;
            var svalue = new NStringValueN<double>(value);
            svalue.SetMinMax(1, null);
            Assert.AreEqual(1, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValueN_WithMin_ValueGreater()
        {
            double? value = 2.999;
            var svalue = new NStringValueN<double>(value);
            svalue.SetMinMax(1, null);
            Assert.AreEqual(value, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValueN_WithMax_ValueLess()
        {
            double? value = 0.999;
            var svalue = new NStringValueN<double>(value);
            svalue.SetMinMax(null, 1);
            Assert.AreEqual(value, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        [TestMethod]
        public void NStringValueN_WithMax_ValueGreater()
        {
            double? value = 2.999;
            var svalue = new NStringValueN<double>(value);
            svalue.SetMinMax(null, 1);
            Assert.AreEqual(1, svalue.Value);
            Console.WriteLine($"Value:{svalue.StringValue}");
        }

        #endregion
    }
}
