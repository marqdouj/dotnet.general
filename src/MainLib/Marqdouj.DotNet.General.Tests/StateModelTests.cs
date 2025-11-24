namespace Marqdouj.DotNet.General.Tests
{
    [TestClass]
    public sealed class StateModelTests
    {
        #region WillChange

        [TestMethod]
        public void StateModel_WillChange_Double()
        {
            Assert.IsTrue(StateModel.StateWillChange<double>(1.5, 1.49));
            Assert.IsTrue(StateModel.StateWillChange<double>(1.49, 1.5));
            Assert.IsFalse(StateModel.StateWillChange<double>(1.5, 1.5));
        }

        [TestMethod]
        public void StateModel_WillChange_DoubleN()
        {
            Assert.IsTrue(StateModel.StateWillChange<double?>(1.5, 1.49));
            Assert.IsTrue(StateModel.StateWillChange<double?>(1.49, 1.5));
            Assert.IsFalse(StateModel.StateWillChange<double?>(1.5, 1.5));
            Assert.IsTrue(StateModel.StateWillChange<double?>(null, 1.5));
            Assert.IsTrue(StateModel.StateWillChange<double?>(1.5, null));
            Assert.IsFalse(StateModel.StateWillChange<double?>(null, null));
        }

        [TestMethod]
        public void StateModel_WillChange_Int()
        {
            Assert.IsTrue(StateModel.StateWillChange<int>(1, 0));
            Assert.IsTrue(StateModel.StateWillChange<int>(0, 1));
            Assert.IsFalse(StateModel.StateWillChange<int>(0, 0));
        }

        [TestMethod]
        public void StateModel_WillChange_IntN()
        {
            Assert.IsTrue(StateModel.StateWillChange<int?>(1, 0));
            Assert.IsTrue(StateModel.StateWillChange<int?>(0, 1));
            Assert.IsFalse(StateModel.StateWillChange<int?>(0, 0));
            Assert.IsTrue(StateModel.StateWillChange<int?>(null, 0));
            Assert.IsTrue(StateModel.StateWillChange<int?>(0, null));
            Assert.IsFalse(StateModel.StateWillChange<int?>(null, null));
        }

        [TestMethod]
        public void StateModel_WillChange_String()
        {
            Assert.IsTrue(StateModel.StateWillChange<string>("a", "b"));
            Assert.IsTrue(StateModel.StateWillChange<string>("b", "a"));
            Assert.IsFalse(StateModel.StateWillChange<string>("a", "a"));
            Assert.IsFalse(StateModel.StateWillChange<string>("", ""));
        }

        [TestMethod]
        public void StateModel_WillChange_StringN()
        {
            Assert.IsTrue(StateModel.StateWillChange<string?>("a", "b"));
            Assert.IsTrue(StateModel.StateWillChange<string?>("b", "a"));
            Assert.IsFalse(StateModel.StateWillChange<string?>("a", "a"));
            Assert.IsTrue(StateModel.StateWillChange<string?>(null, "a"));
            Assert.IsTrue(StateModel.StateWillChange<string?>("a", null));
            Assert.IsFalse(StateModel.StateWillChange<string?>(null, null));
            Assert.IsTrue(StateModel.StateWillChange<string?>(null, ""));
            Assert.IsTrue(StateModel.StateWillChange<string?>("", null));
            Assert.IsFalse(StateModel.StateWillChange<string?>("", ""));
        }

        #endregion

        #region StateChanged

        [TestMethod]
        public void StateModel_SetValue_NotifiyChanged_True()
        {
            var wasChanged = false;

            var model = new TestModel();

            model.StateChanged += (string methodName) => 
            { 
                wasChanged = true;
            };

            model.MyInt = 1;

            Assert.IsTrue(wasChanged);
        }

        [TestMethod]
        public void StateModel_SetValue_NotifiyChanged_False()
        {
            var wasChanged = false;

            var model = new TestModel();

            model.StateChanged += (string methodName) =>
            {
                wasChanged = true;
            };

            model.MyInt = 0;

            Assert.IsFalse(wasChanged);
        }

        [TestMethod]
        public void StateModel_SetValue_NotifiyChanged_True_Suppressed()
        {
            var notified = false;

            var model = new TestModel
            {
                SuppressNotifications = true
            };

            model.StateChanged += (string methodName) =>
            {
                notified = true;
            };

            model.MyInt = 1;

            Assert.IsFalse(notified);
        }

        [TestMethod]
        public void StateModel_SetValue_True()
        {
            var model = new TestModel
            {
                MyInt = 1
            };
            Assert.IsTrue(model.WasChanged);
        }

        [TestMethod]
        public void StateModel_SetValue_False()
        {
            var model = new TestModel
            {
                MyInt = 0
            };
            Assert.IsFalse(model.WasChanged); ;
        }

        #endregion

        private class TestModel : StateModel
        {
            public bool WasChanged { get; private set; }

            #region MyInt
            private int myInt;
            public int MyInt { get => myInt; set => WasChanged = SetValue(ref myInt, value); }
            #endregion
        }
    }
}
