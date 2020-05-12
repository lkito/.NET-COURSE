using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice;

namespace MyStackTests
{
    [TestClass]
    public class StackUnitTest
    {
        [TestMethod]
        public void TestAccessors()
        {
            MyStack<int> st = new MyStack<int>();
            Assert.AreEqual(st.IsEmpty(), true);
            st.Push(4);
            Assert.AreEqual(st.IsEmpty(), false);
            st.Push(4);
            Assert.AreEqual(st.Size(), 2);
            st.Pop();
            Assert.AreEqual(st.Size(), 1);
        }

        [TestMethod]
        public void TestModifiers()
        {
            MyStack<string> st = new MyStack<string>();
            st.Push("dunk");
            st.Push("shpee");
            Assert.AreEqual(st.Pop(), "shpee");
            Assert.AreEqual(st.Pop(), "dunk");
            st.Push("1");
            st.Push("2");
            st.Push("3");
            Assert.AreEqual(st.Size(), 3);
            st.Flush();
            Assert.AreEqual(st.IsEmpty(), true);
        }
    }
}
