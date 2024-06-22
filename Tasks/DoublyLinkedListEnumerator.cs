using System;
using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private Node<T> _current;

        public DoublyLinkedListEnumerator(Node<T> head)
        {
            _current = new Node<T>(default) { Next = head };
        }

        public T Current => _current.Data;

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (_current.Next != null)
            {
                _current = _current.Next;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }
    }

}
