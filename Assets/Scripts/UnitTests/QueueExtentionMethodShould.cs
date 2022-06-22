using System.Collections.Generic;
using GameScripts.ExtentionMethods;
using NUnit.Framework;

namespace UnitTests{
    public class QueueExtentionMethodShould{
        [Test]
        public void Return_True() {
            Queue<int> _queue1 = new Queue<int>();
            Queue<int> _queue2 = new Queue<int>();
            
            _queue1.Enqueue(1);
            _queue1.Enqueue(2);
            _queue1.Enqueue(3);
            
            _queue2.Enqueue(1);
            _queue2.Enqueue(2);
            _queue2.Enqueue(3);
            
            Assert.IsTrue(_queue1.IsSameValues(_queue2));
        }
        
        [Test]
        public void Return_False() {
            Queue<int> _queue1 = new Queue<int>();
            Queue<int> _queue2 = new Queue<int>();
            
            _queue1.Enqueue(1);
            _queue1.Enqueue(3);
            _queue1.Enqueue(3);
            
            _queue2.Enqueue(1);
            _queue2.Enqueue(2);
            _queue2.Enqueue(3);
            
            Assert.IsFalse(_queue1.IsSameValues(_queue2));
        }
        
        [Test]
        public void Return_False_When_Diferent_Sizes() {
            Queue<int> _queue1 = new Queue<int>();
            Queue<int> _queue2 = new Queue<int>();
            
            _queue1.Enqueue(1);
            _queue1.Enqueue(3);
            _queue1.Enqueue(3);
            _queue1.Enqueue(3);
            
            _queue2.Enqueue(1);
            _queue2.Enqueue(2);
            _queue2.Enqueue(3);
            
            Assert.IsFalse(_queue1.IsSameValues(_queue2));
        }

    }
}