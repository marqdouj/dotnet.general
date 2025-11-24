namespace Marqdouj.DotNet.General.Tests
{
    [TestClass]
    public sealed class EnumListTests
    {
        private enum MyEnum
        {
            A, D, B, C,
        }

        [TestMethod]
        public void EnumList_Constructor_WithEnumGetValues()
        {
            var items = new List<MyEnum>(Enum.GetValues<MyEnum>());

            Assert.IsNotNull(items);
            Assert.HasCount(4, items);
        }

        [TestMethod]
        public void EnumList_Constructor_WithList()
        {
            var items = new List<MyEnum>([MyEnum.A, MyEnum.D]);

            Assert.IsNotNull(items);
            Assert.HasCount(2, items);
        }

        [TestMethod]
        public void EnumList_GetNames_Empty()
        {
            //Arrange
            var items = new EnumList<MyEnum>();
            var expectedCount = 0;

            //Act
            var names = items.GetNames();

            //Assert
            Assert.AreEqual(expectedCount, names.Count);
        }

        [TestMethod]
        public void EnumList_GetNames_NotSorted()
        {
            //Arrange
            var items = new EnumList<MyEnum>(Enum.GetValues<MyEnum>());
            var expectedCount = 4;

            var expectedItem0 = MyEnum.A.ToString();
            var expectedItem1 = MyEnum.D.ToString();
            var expectedItem2 = MyEnum.B.ToString();
            var expectedItem3 = MyEnum.C.ToString();

            //Act
            var names = items.GetNames(false);

            //Assert
            Assert.AreEqual(expectedCount, names.Count);
            Assert.AreEqual(expectedItem0, names[0]);
            Assert.AreEqual(expectedItem1, names[1]);
            Assert.AreEqual(expectedItem2, names[2]);
            Assert.AreEqual(expectedItem3, names[3]);
        }

        [TestMethod]
        public void EnumList_GetNames_Sorted()
        {
            //Arrange
            var items = new EnumList<MyEnum>(Enum.GetValues<MyEnum>());
            var expectedCount = 4;

            var expectedItem0 = MyEnum.A.ToString();
            var expectedItem1 = MyEnum.B.ToString();
            var expectedItem2 = MyEnum.C.ToString();
            var expectedItem3 = MyEnum.D.ToString();

            //Act
            var names = items.GetNames(true);

            //Assert
            Assert.AreEqual(expectedCount, names.Count);
            Assert.AreEqual(expectedItem0, names[0]);
            Assert.AreEqual(expectedItem1, names[1]);
            Assert.AreEqual(expectedItem2, names[2]);
            Assert.AreEqual(expectedItem3, names[3]);
        }

        [TestMethod]
        public void EnumList_IgnoreDuplicates_AddValue()
        {
            //Arrange
            var items = new EnumList<MyEnum>();

            //Act
            var addFirst = items.AddValue(MyEnum.A);
            var addSecond = items.AddValue(MyEnum.A);
            var count = items.Items.Count;

            //Assert
            Assert.AreEqual(1, count);
            Assert.IsTrue(items.Items.Contains(MyEnum.A));
            Assert.IsTrue(addFirst); 
            Assert.IsFalse(addSecond);
        }

        [TestMethod]
        public void EnumList_IgnoreDuplicates_AddValues_Constructor()
        {
            //Arrange
            var items = new EnumList<MyEnum>([MyEnum.A, MyEnum.D, MyEnum.A, MyEnum.D]);

            //Act
            var count = items.Items.Count;

            //Assert
            Assert.AreEqual(2, count);
            Assert.IsTrue(items.Items.Contains(MyEnum.A));
            Assert.IsTrue(items.Items.Contains(MyEnum.D));
        }

        [TestMethod]
        public void EnumList_IgnoreDuplicates_AddValues_List()
        {
            //Arrange
            var items = new EnumList<MyEnum>();

            //Act
            items.AddValues(new List<MyEnum> { MyEnum.A, MyEnum.D, MyEnum.A, MyEnum.D });
            var count = items.Items.Count;

            //Assert
            Assert.AreEqual(2, count);
            Assert.IsTrue(items.Items.Contains(MyEnum.A));
            Assert.IsTrue(items.Items.Contains(MyEnum.D));
        }

        [TestMethod]
        public void EnumList_IgnoreDuplicates_AddValues_List_Empty()
        {
            //Arrange
            var items = new EnumList<MyEnum>();
            List<MyEnum>? list = null;

            //Act
            items.AddValues(list!);
            var count = items.Items.Count;

            //Assert
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void EnumList_IgnoreDuplicates_AddValues_Params()
        {
            //Arrange
            var items = new EnumList<MyEnum>();

            //Act
            items.AddValues(MyEnum.A, MyEnum.D, MyEnum.A, MyEnum.D);
            var count = items.Items.Count;

            //Assert
            Assert.AreEqual(2, count);
            Assert.IsTrue(items.Items.Contains(MyEnum.A));
            Assert.IsTrue(items.Items.Contains(MyEnum.D));
        }
    }
}
