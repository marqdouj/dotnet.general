using System.Text.Json;

namespace Marqdouj.DotNet.General.Tests
{
    [TestClass]
    public sealed class NRangeTests
    {
        [TestMethod]
        public void NRange_Constructor_Json()
        {
            NRange<int> range = new(0, 100, 50);
            string json = JsonSerializer.Serialize(range);
            NRange<int>? minMaxN2 = JsonSerializer.Deserialize<NRange<int>>(json);
            Assert.IsNotNull(minMaxN2);
            Assert.AreEqual(range.Min, minMaxN2.Min);
            Assert.AreEqual(range.Max, minMaxN2.Max);
            Assert.AreEqual(range.Value, minMaxN2.Value);
        }

        [TestMethod]
        public void NRange_Constructor_MinGreaterThanMax()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => 
            { 
                var range = new NRange<int>(1, 0);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var range = new NRange<double>(0.00001, 0);
            });
        }

        [TestMethod]
        public void NRange_Constructor_MinMaxSame()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var range = new NRange<int>(0, 0);
            });

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var range = new NRange<double>(0, 0);
            });
        }

        #region Integer

        [TestMethod]
        public void NRange_ToString_Int()
        {
            NRange<int> range = new(0, 100, 50);
            Assert.AreEqual("50", range.ToString());
        }

        [TestMethod]
        public void NRange_Step_Int()
        {
            NRange<int> range = new(0, 100, 50)
            {
                Step = 5
            };

            Assert.AreEqual(5, range.Step);
        }

        [TestMethod]
        public void NRange_Constructor_Step_Int()
        {
            NRange<int> range = new(0, 100, 50);

            Assert.AreEqual(1, range.Step);
        }

        [TestMethod]
        public void NRange_Constructor_Int_NoValue()
        {
            var range = new NRange<int>(int.MinValue, int.MaxValue);

            Assert.AreEqual(int.MinValue, range.Value);
            Assert.AreEqual(int.MinValue, range.Min);
            Assert.AreEqual(int.MaxValue, range.Max);
            Assert.AreEqual(range.Min, range.Value);
        }

        [TestMethod]
        public void NRange_Constructor_Int_WithValue()
        {
            var range = new NRange<int>(int.MinValue, int.MaxValue, 1);

            Assert.AreEqual(int.MinValue, range.Min);
            Assert.AreEqual(int.MaxValue, range.Max);
            Assert.AreEqual(1, range.Value);
        }

        [TestMethod]
        public void NRange_Constructor_Int_ValueLessThanMin()
        {
            var range = new NRange<int>(0, 10, -10);
            Assert.AreEqual(range.Min, range.Value);
            Assert.AreEqual(0, range.Value);
        }

        [TestMethod]
        public void NRange_Constructor_Int_ValueGreaterThanMax()
        {
            var range = new NRange<int>(0, 10, 15);
            Assert.AreEqual(range.Max, range.Value);
            Assert.AreEqual(10, range.Value);
        }

        [TestMethod]
        public void NRange_Int_Width()
        {
            var range = new NRange<int>(0, 10);
            Assert.AreEqual(10, range.Width);

            range = new NRange<int>(1, 7);
            Assert.AreEqual(6, range.Width);

            range = new NRange<int>(-10, 0);
            Assert.AreEqual(10, range.Width);
        }

        [TestMethod]
        public void NRange_Int_Center()
        {
            var range = new NRange<int>(0, 10);
            Assert.AreEqual(5, range.Center);

            range = new NRange<int>(1, 7);
            Assert.AreEqual(4, range.Center);

            range = new NRange<int>(1, 8);
            Assert.AreEqual(4.5, range.Center);

            range = new NRange<int>(-10, 0);
            Assert.AreEqual(-5, range.Center);

            range = new NRange<int>(-10, -3);
            Assert.AreEqual(-6.5, range.Center);
        }

        #endregion

        #region Double

        [TestMethod]
        public void NRange_ToString_Double()
        {
            NRange<double> range = new(0, 100, 50);
            Assert.AreEqual("50", range.ToString());
        }

        [TestMethod]
        public void NRange_Step_Double()
        {
            NRange<double> range = new(0, 100, 50)
            {
                Step = 1.5
            };

            Assert.AreEqual(1.5, range.Step);
        }

        [TestMethod]
        public void NRange_Constructor_Step_Double()
        {
            NRange<double> range = new(0, 100, 50);

            Assert.AreEqual(1, range.Step);
        }

        [TestMethod]
        public void NRange_Constructor_Double_NoValue()
        {
            var range = new NRange<double>(double.MinValue, double.MaxValue);

            Assert.AreEqual(double.MinValue, range.Value);
            Assert.AreEqual(double.MinValue, range.Min);
            Assert.AreEqual(double.MaxValue, range.Max);
            Assert.AreEqual(range.Min, range.Value);
        }

        [TestMethod]
        public void NRange_Constructor_Double_WithValue()
        {
            var range = new NRange<double>(double.MinValue, double.MaxValue, 1.45);

            Assert.AreEqual(double.MinValue, range.Min);
            Assert.AreEqual(double.MaxValue, range.Max);
            Assert.AreEqual(1.45, range.Value);
        }

        [TestMethod]
        public void NRange_Constructor_Double_ValueLessThanMin()
        {
            var range = new NRange<double>(0, 10, -0.1);
            Assert.AreEqual(range.Min, range.Value);
            Assert.AreEqual(0, range.Value);
        }

        [TestMethod]
        public void NRange_Constructor_Double_ValueGreaterThanMax()
        {
            var range = new NRange<double>(0, 10.45, 15.1);
            Assert.AreEqual(range.Max, range.Value);
            Assert.AreEqual(10.45, range.Value);
        }

        [TestMethod]
        public void NRange_Double_Width()
        {
            var range = new NRange<double>(0, 10);
            Assert.AreEqual(10, range.Width);

            range = new NRange<double>(1.25, 7);
            Assert.AreEqual(5.75, range.Width);

            range = new NRange<double>(-10, 0);
            Assert.AreEqual(10, range.Width);
        }

        [TestMethod]
        public void NRange_Double_Center()
        {
            var range = new NRange<double>(0.1, 10.1);
            Assert.AreEqual(5.1, range.Center);

            range = new NRange<double>(1.1, 7.1);
            Assert.AreEqual(4.1, range.Center);

            range = new NRange<double>(1.1, 8.1);
            Assert.AreEqual(4.6, range.Center);

            range = new NRange<double>(-10.1, 0.1);
            Assert.AreEqual(-5, range.Center);

            range = new NRange<double>(-10.25, -3.25);
            Assert.AreEqual(-6.75, range.Center);
        }

        #endregion
    }
}
