using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        protected DoublyLinkedList<T> _storage;
        private readonly string _invalidOperationExceptionMessage = "Storage is empty! Nothing to pop out!";

        public HybridFlowProcessor()
        {
            _storage = new DoublyLinkedList<T>();
        }
        public T Dequeue()
        {
            try
            {
                T firstElement = _storage.ElementAt(0);
                _storage.Remove(firstElement);
                return firstElement;
            }
            catch(IndexOutOfRangeException)
            {
                throw new InvalidOperationException(_invalidOperationExceptionMessage);
            }
        }

        public void Enqueue(T item)
        {
            _storage.Add(item);
        }

        public T Pop()
        {
            try
            {
                T lastElement = _storage.ElementAt(_storage.Length - 1);
                _storage.Remove(lastElement);
                return lastElement;
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException(_invalidOperationExceptionMessage);
            }
          
        }

        public void Push(T item)
        {
            _storage.Add(item);
        }
    }
}
