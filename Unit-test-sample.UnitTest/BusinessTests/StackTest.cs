using System;
using System.Collections.Generic;
using NUnit.Framework;
using Unit_test_sample.Fundamentals;

namespace Unit_test_sample.UnitTest
{
    [TestFixture]
    public class StackTest 
    {
        private Fundamentals.Stack<User> _mylist;

        [SetUp]
         public void Setup() //run this method after every testable unit method block
        {
          _mylist = new Fundamentals.Stack<User>();
          _mylist.Push(new User{IsAdmin =false});
          _mylist.Push(new User{IsAdmin = true});
        }

        [TearDown]
        public void Teardown()
        {
            _mylist = null;
        }

        [Test]
        public void Stack_PushItemCheckIfEmpty_ReturnsTrue()
        {   
            Assert.That(_mylist.IsEmpty, Is.False); 
        }

        [Test]
        public void Stack_PopItem_ReturnsTrue()
        {   
            _mylist.Pop();
            _mylist.Pop();
            Assert.That(_mylist.IsEmpty, Is.True); 

           // Assert.Throws<InvalidOperationException>(() => _mylist.Pop());
        }

         [Test]
        public void Stack_Peek_ReturnsHeadObject()
        {   
            var stack = new Fundamentals.Stack<int>();

            stack.Push(1);
            stack.Push(5);

            var result = stack.Peek();
            Assert.That(result, Is.EqualTo(5)); 
        }
    }
}
