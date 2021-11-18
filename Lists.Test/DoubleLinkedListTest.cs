using NUnit.Framework;
using System;
using List1;


namespace List1.Test
{
    internal class DoubleLinkedTest
    {
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
    }
}
