using System;

namespace ConsoleApp1
{
    internal class AVLTree<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }

            public Node(T data)
            {
                Data = data;
                Height = 1;
            }

            public void ShowChildren()
            {
                Console.WriteLine(Data);
                if (Right.Right != null)
                {
                    Right.ShowChildren();
                }
                if (Left.Left != null)
                {
                    Left.ShowChildren();
                }

            }
        }

            private Node root;

            private Node Insert(Node node, T data)
            {
                if (node == null)
                {
                    return new Node(data);
                }
                return null;
            }

            public void Insert(T data)
            {
                root = Insert(root, data);
            }

            public void ShowTree()
            {
                root.ShowChildren();
            }
        }
    }
