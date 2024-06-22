using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> _head;
        private int _length;
        public int Length
        {
            private set { _length = value; }
            get { return _length; }
        }

        public DoublyLinkedList()
        {
            _head = null;
            Length = 0;
        }

        public DoublyLinkedList(T data)
        {
            Node<T> newNode = new Node<T>(data);
            _head = newNode;
            newNode.Previous = null;
            newNode.Next = null;

            Length++;
        }
      
        public void Add(T e)
        {
            Node<T> newNode = new Node<T>(e);

            newNode.Next = null;
            //if list is empty
            if (_head == null)
            {
                _head = newNode;
                newNode.Previous = null;
            }
            else
            {
                Node<T> tail = _head;
                while (tail.Next != null)
                    tail = tail.Next;
                tail.Next = newNode;
                newNode.Previous = tail;   
            }
            Length++;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > Length)
                throw new IndexOutOfRangeException();

            Node<T> newNode = new Node<T>(e);
            //if add at the list beginning
            if(index == 0 || _head == null)
            {
                newNode.Previous = null;
                newNode.Next = _head;
                _head = newNode;

            }
            else
            {
                Node<T> tail = _head;
                //iterate to previous to set index element
                for (int i = 0; i < index - 1; i++)
                {
                    tail = tail.Next;
                }

                tail.Next = newNode;
                newNode.Previous = tail;

                newNode.Next = tail.Next;
            }

            if (newNode.Next != null)
                newNode.Next.Previous = newNode;
            Length++;
        }

        public T ElementAt(int index)
        {
            Node<T> tail = _head;
            if (_head == null || index > Length - 1 || index < 0)
                throw new IndexOutOfRangeException();

            if (index == 0)
                return _head.Data;

            for (int i = 0; i < index; i++)
            {
                tail = tail.Next;
            }

            return tail.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(_head);
        }

        public void Remove(T item)
        {
            Node<T> tail = _head;
            while (!tail.Data.Equals(item))
            {
                if (tail.Next == null)
                    return;
                tail = tail.Next;                    
            }

            //if remove not from the list beginning
            if (tail.Previous != null)
                tail.Previous.Next = tail.Next;
            else
                _head = tail.Next;
            //if tail is not last element
            if(tail.Next != null)
                tail.Next.Previous = tail.Previous;
            Length--;
            
        }

        public T RemoveAt(int index)
        {
            if (_head == null || index > Length - 1 || index < 0)
                throw new IndexOutOfRangeException();

            Node<T> tail = _head;

            for (int i = 0; i < index; i++)
            {
                tail = tail.Next;
            }
            
            tail.Previous.Next = tail.Next;
            //if tail is not last element
            if(tail.Next != null)
                tail.Next.Previous = tail.Previous;
            Length--;
            return tail.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
