using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bekk.dotnetintro.TDD.Stack
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void IsEmpty_NoElementsOnStack_ReturnsTrue()
        {
            var stack = new Stack<object>();

            var result = stack.IsEmpty();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEmpty_OneStringElementPushedOnStack_ReturnsFalse()
        {
            var stack = new Stack<string>();
            stack.Push("myElement");

            var result = stack.IsEmpty();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsEmpty_OneIntElementPushedOnStack_ReturnsFalse()
        {
            var stack = new Stack<int>();
            stack.Push(1);

            var result = stack.IsEmpty();

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Pop_OneElementIsPushedOnStack_ReturnsTheElement()
        {
            var stack = new Stack<string>();
            const string elementToBePopped = "toBePopped";
            stack.Push(elementToBePopped);

            var result = stack.Pop();

            Assert.AreEqual(elementToBePopped, result);
        }

        [TestMethod]
        public void IsEmpty_OneElementPushedAndThenPoped_ReturnIsTrue()
        {
            var stack = new Stack<string>();
            const string elementToBePopped = "toBePopped";
            stack.Push(elementToBePopped);
            stack.Pop();
            
            var result = stack.IsEmpty();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Top_OneElementIsPushed_ReturnsTheElement()
        {
            var stack = new Stack<string>();
            const string element = "element";
            stack.Push(element);

            var result = stack.Top();

            Assert.AreEqual(element, result);
        }
    }
}
