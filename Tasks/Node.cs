﻿

namespace Tasks
{
    public class Node<T>
    {
        public T Data { get; set; }


        public Node(T data)
        {
            Data = data;
        }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }

    }
}
