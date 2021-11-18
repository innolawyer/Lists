using NUnit.Framework;
using System;
using List1;

namespace List1.Test
{
    public class LinkedListTest
    {
        #region AddTest
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0 })]
        [TestCase(-1, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, -1 })]
        [TestCase(4537567, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 4537567 })]
        [TestCase(0, new int[] { }, new int[] { 0 })]
        [TestCase(-565676, new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, -565676 })]
        public static void AddTest(int value, int[] firstArray, int[] secondArray)
        {
            LinkedList actual = new LinkedList(firstArray);
            LinkedList expected = new LinkedList(secondArray);

            actual.Add(value);
            Assert.AreEqual(expected, actual);

        }
        #endregion

        #region AddFirstTest
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 })]
        [TestCase(-1, new int[] { 1, 2, 3 }, new int[] { -1, 1, 2, 3 })]
        [TestCase(4537567, new int[] { 1, 2, 3, 4, 5 }, new int[] { 4537567, 1, 2, 3, 4, 5 })]
        [TestCase(0, new int[] { }, new int[] { 0 })]
        [TestCase(-565676, new int[] { 1, 1, 1, 1, 1 }, new int[] { -565676, 1, 1, 1, 1, 1 })]
        public static void AddFirstTest(int value, int[] firstArray, int[] secondArray)
        {
            LinkedList actual = new LinkedList(firstArray);
            LinkedList expected = new LinkedList(secondArray);

            actual.AddFirst(value);
            Assert.AreEqual(expected, actual);

        }
        #endregion

        #region InsertTest
        [TestCase(0, 10, new int[] { 1, 2, 3, 4, 5 }, new int[] { 10, 1, 2, 3, 4, 5 })]
        [TestCase(2, -1, new int[] { 1, 2, 3 }, new int[] { 1, 2, -1, 3, })]
        [TestCase(2, 4537567, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4537567, 3, 4, 5 })]
        [TestCase(0, -565676, new int[] { 1, 1, 1, 1, 1 }, new int[] { -565676, 1, 1, 1, 1, 1 })]
        public static void InsertTest(int index, int value, int[] firstArray, int[] secondArray)
        {
            LinkedList actual = new LinkedList(firstArray);
            LinkedList expected = new LinkedList(secondArray);

            actual.Insert(index, value);
            Assert.AreEqual(expected, actual);

        }


        [TestCase(-1, 10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, 10, new int[] { 1, 2, 3, 4, 5 })]
        public void InsertTest_WhenIndexIsLessThanZeroOrMoreThanLength_ShouldThrowsIndexOutOfRangeException(int index, int value, int[] array)
        {
            LinkedList test = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => test.Insert(index, value));
        }
        #endregion

        #region RemoveLastTest
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { -1, -2, 3, -4, 5 }, new int[] { -1, -2, 3, -4 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 })]
        public static void RemoveLastTest(int[] firstArray, int[] secondArray)
        {
            LinkedList actual = new LinkedList(firstArray);
            LinkedList expected = new LinkedList(secondArray);

            actual.RemoveLast();
            Assert.AreEqual(expected, actual);

        }

        //[TestCase(new int[] { })]
        //public void RemoveLastTest_WhenRootIsNull_ShouldThrowsIndexOutOfRangeException( int[] array)
        //{
        //    LinkedList test = new LinkedList(array);
        //    Assert.Throws<IndexOutOfRangeException>(() => test.RemoveLast());
        //}
        #endregion

        #region RemoveFirstTest
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { -1, -2, 3, -4, 5 }, new int[] { -2, 3, -4, 5 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        public static void RemoveFirstTest(int[] firstArray, int[] secondArray)
        {
            LinkedList actual = new LinkedList(firstArray);
            LinkedList expected = new LinkedList(secondArray);

            actual.RemoveFirst();
            Assert.AreEqual(expected, actual);

        }
        #endregion

        #region RemoveByIndexTest
        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(2, new int[] { -1, -2, 3, -4, 5 }, new int[] { -1, -2, -4, 5 })]
        [TestCase(3, new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        public static void RemoveByIndexTest(int index, int[] firstArray, int[] secondArray)
        {
            LinkedList actual = new LinkedList(firstArray);
            LinkedList expected = new LinkedList(secondArray);

            actual.RemoveByIndex(index);
            Assert.AreEqual(expected, actual);

        }
        public void RemoveByIndexTest_WhenRootIsNull_ShouldThrowsIndexOutOfRangeException(int index, int[] array)
        {
            LinkedList test = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => test.RemoveByIndex(index));
        }
        [TestCase(-1, 10, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, 10, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveByIndexTest_WhenIndexIsLessThanZeroOrMoreThanLength_ShouldThrowsIndexOutOfRangeException(int index, int[] array)
        {
            LinkedList test = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => test.RemoveByIndex(index));
        }

        #endregion

        #region RemoveLastNElementsTest
        [TestCase(2, new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(7, new int[] { -1, -2, -3, -4, -5, -6, -7 }, new int[] { })]
        [TestCase(2, new int[] { 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        public void RemoveLastNElementsTest(int n, int[] firstArray, int[] secondArray)
        {
            LinkedList actual = new LinkedList(firstArray);
            LinkedList expected = new LinkedList(secondArray);

            actual.RemoveLastNElements(n);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(100, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(-1, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void RemoveLastNElementsTest_WhenNIsMoreThanLengthOrLessThanZero_ShouldThrowsArgumentException(int n, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<ArgumentException>(() => actual.RemoveLastNElements(n));
        }

        #endregion

        #region RemoveFirstNElementsTest
        [TestCase(2, new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 3, 4, 5, 6, 7 })]
        [TestCase(0, new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(7, new int[] { -1, -2, -3, -4, -5, -6, -7 }, new int[] { })]
        [TestCase(2, new int[] { 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]

        public void RemoveFirstNElementsTest(int n, int[] firstArray, int[] secondArray)
        {
            LinkedList actual = new LinkedList(firstArray);
            LinkedList expected = new LinkedList(secondArray);

            actual.RemoveFirstNElements(n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(100, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(-1, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void RemoveFirstNElementsTest_WhenNIsMoreThanLengthOrLessThanZero_ShouldThrowsArgumentException(int n, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<ArgumentException>(() => actual.RemoveLastNElements(n));
        }
        #endregion

        #region RemoveByIndexNElementsTest
        [TestCase(2, 4, new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 7 })]
        [TestCase(0, 2, new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 3, 4, 5, 6, 7 })]
        [TestCase(0, 0, new int[] { -1, -2, -3, -4, -5, -6, -7 }, new int[] { -1, -2, -3, -4, -5, -6, -7 })]
        [TestCase(6, 1, new int[] { -1, -2, -3, -4, -5, -6, -7 }, new int[] { -1, -2, -3, -4, -5, -6 })]
        [TestCase(2, 2, new int[] { 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]

        public void RemoveByIndexNElementsTest(int index, int n, int[] firstArray, int[] secondArray)
        {
            LinkedList actual = new LinkedList(firstArray);
            LinkedList expected = new LinkedList(secondArray);

            actual.RemoveByIndexNElements(index, n);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, 4, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, 2, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(5, 5, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveByIndexNElementsTest_WhenIndexIsEqualOrMoreThanLengthOrLessThanZero_ShouldThrowsIndexOutOfRangeException(int index, int n, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.RemoveByIndexNElements(index, n));
        }

        [TestCase(1, -4, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(2, 200, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(3, 52, new int[] { 1, 2, 3, 4, 5 })]
        public void RemoveByIndexNElementsTest_WhenNIsMoreThanLengthOrLessThanZero_ShouldThrowsArgumentException(int index, int n, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<ArgumentException>(() => actual.RemoveByIndexNElements(index, n));
        }
        #endregion

        #region GetFirstIndexByValueTest

        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, 3)]
        [TestCase(10, new int[] { 1, 2, 3, 4, 5 }, -1)]
        [TestCase(-10, new int[] { 1, 2, 3, 4, 5 }, -1)]
        [TestCase(-10, new int[] { -1, -2, -3, -4, -5 }, -1)]
        [TestCase(-1, new int[] { -1, -2, -3, -4, -5 }, 0)]
        public void GetFirstIndexByValueTest(int value, int[] array, int expected)
        {
            LinkedList actualArray = new LinkedList(array);

            int actual = actualArray.GetFirstIndexByValue(value);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region EditByIndexTest

        [TestCase(2, 4, new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 4, 4, 5, 6, 7 })]
        [TestCase(0, 2, new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 2, 2, 3, 4, 5, 6, 7 })]
        [TestCase(0, 0, new int[] { -1, -2, -3, -4, -5, -6, -7 }, new int[] { 0, -2, -3, -4, -5, -6, -7 })]
        [TestCase(6, 1, new int[] { -1, -2, -3, -4, -5, -6, -7 }, new int[] { -1, -2, -3, -4, -5, -6, 1 })]
        [TestCase(2, 2, new int[] { 0, 0, 0, 0, 0, 0 }, new int[] { 0, 0, 2, 0, 0, 0 })]
        public void EditByIndexTest(int index, int value, int[] firstArray, int[] secondArray)
        {
            LinkedList actual = new LinkedList(firstArray);
            LinkedList expected = new LinkedList(secondArray);

            actual.EditByIndex(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(-1, 4, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, 2, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(5, 5, new int[] { 1, 2, 3, 4, 5 })]
        public void EditByIndexTest_WhenIndexIsEqualOrMoreThanLengthOrLessThanZero_ShouldThrowsIndexOutOfRangeException(int index, int value, int[] array)
        {
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => actual.EditByIndex(index, value));
        }
        #endregion

        #region ReverseTest
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { -1, -2, -3, -4 }, new int[] { -4, -3, -2, -1 })]
        [TestCase(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
        [TestCase(new int[] { }, new int[] { })]
        public void ReverseTest(int[] firstArray, int[] secondArray)
        {
            LinkedList actual = new LinkedList(firstArray);
            LinkedList expected = new LinkedList(secondArray);

            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region GetMaxValueTest
        [TestCase(new int[] { 1, 3, 5, 6 }, 6)]
        [TestCase(new int[] { -1, -3, -5, -6 }, -1)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 0)]
        public void GetMaxValueTest(int[] array, int expected)
        {
            LinkedList actualArray = new LinkedList(array);
            int actual = actualArray.GetMaxValue();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetMinValueTest
        [TestCase(new int[] { 1, 3, 5, 6 }, 1)]
        [TestCase(new int[] { -1, -3, -5, -6 }, -6)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 0)]
        public void GetMinValueTest(int[] array, int expected)
        {
            LinkedList actualArray = new LinkedList(array);
            int actual = actualArray.GetMinValue();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetIndexOfMinTest

        [TestCase(new int[] { 1, 3, 5, 6 }, 0)]
        [TestCase(new int[] { -1, -3, -5, -6 }, 3)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 0)]
        public void GetIndexOfMinTest(int[] array, int expected)
        {
            LinkedList actualArray = new LinkedList(array);
            int actual = actualArray.GetIndexOfMin();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetIndexOfMaxTest

        [TestCase(new int[] { 1, 3, 5, 6 }, 3)]
        [TestCase(new int[] { -1, -3, -5, -6 }, 0)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 0)]
        public void GetIndexOfMaxTest(int[] array, int expected)
        {
            LinkedList actualArray = new LinkedList(array);
            int actual = actualArray.GetIndexOfMax();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region SortFromMinToMaxTest
        [TestCase(new int[] { 4, 3, 5, 1, 2 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        [TestCase(new int[] { -4, -3, -5, -1, -2 }, new int[] { -5, -4, -3, -2, -1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortFromMinToMaxTest(int[] firstArray, int[] secondArray)
        {
            LinkedList actual = new LinkedList(firstArray);
            LinkedList expected = new LinkedList(secondArray);

            actual.SortFromMinToMax();
            Assert.AreEqual(expected, actual);

        }
        #endregion

        #region SortFromMaxToMinTest
        [TestCase(new int[] { 4, 3, 5, 1, 2 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 0, 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0, 0 })]
        [TestCase(new int[] { -4, -3, -5, -1, -2 }, new int[] { -1, -2, -3, -4, -5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortFromMaxToMinTest(int[] firstArray, int[] secondArray)
        {
            LinkedList actual = new LinkedList(firstArray);
            LinkedList expected = new LinkedList(secondArray);

            actual.SortFromMaxToMin();
            Assert.AreEqual(expected, actual);

        }
        #endregion

        #region RemoveFirstByValueTest
        [TestCase(4, new int[] { 4, 3, 5, 1, 2 }, 0)]
        [TestCase(1, new int[] { 0, 0, 0, 0, 0 }, -1)]
        [TestCase(-2, new int[] { -4, -3, -5, -1, -2 }, 4)]
        [TestCase(1, new int[] { }, -1)]
        public void RemoveFirstByValueTest(int value, int[] array, int expected)
        {
            LinkedList actualArray = new LinkedList(array);

            int actual = actualArray.RemoveFirstByValue(value);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region RemoveAllByValueTest
        [TestCase(4, new int[] { 4, 3, 5, 1, 2, 6, 7, 8 }, 1)]
        [TestCase(8, new int[] { 4, 3, 5, 1, 2, 6, 7, 8 }, 1)]
        [TestCase(0, new int[] { 0, 0, 0, 0, 0 }, 5)]
        [TestCase(-2, new int[] { -4, -3, -2, -2, -2 }, 3)]
        [TestCase(1, new int[] { }, 0)]
        [TestCase(10, new int[] { 4, 3, 5, 1, 2 }, 0)]
        public void RemoveAllByValueTest(int value, int[] array, int expected)
        {
            LinkedList actualArray = new LinkedList(array);

            int actual = actualArray.RemoveAllByValue(value);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region AddTest
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, new int[] { 1, 2, 3 })] //почему-то не проходит
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { -1, -2, -3 }, new int[] { 1, 2, 3 }, new int[] { -1, -2, -3, 1, 2, 3 })]
        public void AddTest(int[] array, int[] array2, int[] expectedArray)
        {
            LinkedList actualArray = new LinkedList(array);
            LinkedList addedArray = new LinkedList(array2);
            LinkedList expected = new LinkedList(expectedArray);

            actualArray.Add(addedArray);

            Assert.AreEqual(expected, actualArray);
        }
        #endregion

        #region AddFirstTest
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })] //опять таки почему-то не проходит
        [TestCase(new int[] { }, new int[] { }, new int[] { })]
        [TestCase(new int[] { -1, -2, -3 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, -1, -2, -3 })]
        public void AddFirstTest(int[] array, int[] array2, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList addedArray = new LinkedList(array2);
            LinkedList expected = new LinkedList(expectedArray);

            actual.AddFirst(addedArray);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region InsertTest
        [TestCase(3, new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(1, new int[] { 1, 2, 3, 4 }, new int[] { }, new int[] { 1, 2, 3, 4 })]
        [TestCase(3, new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 })]
        [TestCase(0, new int[] { 1, 2, 3, 4 }, new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1, 1, 2, 3, 4 })]
        public void InsertTest(int index, int[] array, int[] array2, int[] expectedArray)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList addedArray = new LinkedList(array2);
            LinkedList expected = new LinkedList(expectedArray);
            actual.Insert(index, addedArray);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(-1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(100, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        public void InsertTest_WhenIndexIsEqualOrMoreThanLengthOrLessThanZero_ShouldThrowsIndexOutOfRangeException(int index, int[] array, int[] array2)
        {
            LinkedList actual = new LinkedList(array);
            LinkedList addedArray = new LinkedList(array2);
            Assert.Throws<IndexOutOfRangeException>(() => actual.Insert(index, addedArray));
        }
        #endregion

    }

}