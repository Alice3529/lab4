using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class AVL
    {
        public class Node
        {
            public int data;
            public Node left;
            public Node right;
            public int duplicates=1;
            public List<int> numbers=new List<int>();
            public List<int> deleteNumbers=new List<int>();

            public Node(int data, int number)
            {
                this.data = data;
                numbers.Add(number);
            }
        }
        public Node root;
        public int maxAmount;
        public AVL()
        {
        }
        public void Add(int data, int number)
        {
            Node newItem = new Node(data, number);
            maxAmount = number;
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = RecursiveInsert(root, newItem);
            }
        }
        private Node RecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.data < current.data)
            {
                current.left = RecursiveInsert(current.left, n);
                current = balance_tree(current);
            }
            else if (n.data == current.data)
            {
                current.duplicates++;
                current.numbers.Add(n.numbers[0]);
            }
            else if (n.data > current.data)
            {
                current.right = RecursiveInsert(current.right, n);
                current = balance_tree(current);
            }
            return current;
        }
        private Node balance_tree(Node current)
        {
            int b_factor = balance_factor(current);
            if (b_factor > 1)
            {
                if (balance_factor(current.left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (balance_factor(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        public void Delete(int target/*, int number*/)
        {

            root = Delete(root, target);
            
           
           // maxAmount -= 1;

        }

         public void Reorder(int firstNumber, int length)
         {
           if (root == null) { return; }
           foreach (Node node in Collect(root))
           {
               for (int k=0; k<node.numbers.Count; k++)
               {

                    if (node.numbers[k] > firstNumber)
                    {
                         node.numbers[k] -= length;
                    }
                    
               }
           }
        }
        

        private Node Delete(Node current, int target)
        {
        if (current == null)
        { return null; }
        else
        {
            //left subtree
            if (target < current.data)
            {
                current.left = Delete(current.left, target);
                current = balance_tree(current);
            }
            //right subtree
            else if (target > current.data)
            {
                current.right = Delete(current.right, target);
                current = balance_tree(current);
            }
            //if target is found
            else
            {
               
                 if (current.left == null)
                {
                    current = current.right;
                }
                else if (current.right == null)
                {
                    current = current.left;
                }
                else
                {
                    Node temp = MinValueNode(current.right);
                    current.data = temp.data;
                    current.numbers = temp.numbers;
                    current.duplicates = temp.duplicates;
                    current.right = Delete(current.right, temp.data);
                    current = balance_tree(current);
                }

            }
        }
        return current;
    }

    private Node MinValueNode(Node node)
    {
        Node current = node;
        while (current.left != null)
        {
            current = current.left;
        }
        return current;
    }


    public bool Find(int key)
        { 
            if (root == null) { return false; }
            if (Find(key, root) == key)
            {
                return true;
            }
            return false;
        }
        private int Find(int target, Node current)
        {

            if (target < current.data)
            {
                if (target == current.data)
                {
                    return current.data;
                }
                else if (current.left!=null)
                    return Find(target, current.left);
            }
            else
            {
                if (target == current.data)
                {
                    return current.data;
                }
                else if (current.right!=null)
                    return Find(target, current.right);
            }
            return -1;
        }


        public Node FindByNumber(int number)
        {
            Node desiredNode = null;
            foreach (Node node in Collect(root))
            {
               if (node.numbers.Contains(number))
               {
                   desiredNode = node;
                   break;
               }
            }
            return desiredNode;
        }

    public Node GetNodeByData(int data)
    {
        Node desiredNode = null;
        foreach (Node node in Collect(root))
        {
            if (node.data==data)
            {
                desiredNode = node;
                break;
            }
        }
        return desiredNode;
    }
    public void DisplayTree()
        {
            Container.OutPoint();

            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            int rootHeight = getHeight(root);
            InOrderDisplayTree(root, rootHeight, Container.columnAmount / 2, 0);
            Container.OutAll();
            Console.WriteLine();
        }
        private void InOrderDisplayTree(Node current, int rootHeight, int markup, int depth)
        {
            if (current != null)
            {
                Container.SCREEN[depth, markup] = current.data.ToString();
                Container.SCREEN[depth + 1, markup] = "o" ;
                Container.SCREEN[depth+2, markup] = current.duplicates.ToString();

                depth = depth + 1;
                int markup1 = 40 / (int)Math.Pow(2, depth);
                InOrderDisplayTree(current.left, rootHeight, markup - markup1, depth);
                InOrderDisplayTree(current.right, rootHeight, markup + markup1, depth);
            }
        }

        private int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = Math.Max(l, r);
                height = m + 1;
            }
            return height;
        }
        private int balance_factor(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }
        private Node RotateRR(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }

       public IEnumerable<Node> Collect(Node node)
       {
       
           yield return node;

           if (node.left != null)
           {
              foreach (var leftNode in Collect(node.left))
              {
                  yield return leftNode;
              }
           }

          if (node.right != null)
          {
            foreach (var rightNode in Collect(node.right))
            {
                yield return rightNode;
            }
         }

    }

    public void Display()
    {
        DisplaySet();
        DisplaySequence();
        DisplayTree();
    }

    public void DisplaySequence()
    {
        Console.Write("Sequence:");
        for (int i=1; i<maxAmount+1; i++)
        {
              Console.Write(FindByNumber(i).data + " ");
        }
        Console.WriteLine();

    }

    public void DisplaySet()
    {
        Console.Write("Set:");
        if (root == null) { return; }
        foreach (Node node in Collect(root))
        {
            Console.Write(node.data + " ");
        }
        Console.WriteLine();
    }

    public static AVL operator + (AVL tree1, AVL tree2) // объединение
    {
        AVL result = new AVL();

        int counter = 1;

        if (tree1.root != null)
        {
            foreach (Node node in tree1.Collect(tree1.root))
            {
                if (!result.Find(node.data))
                {
                    result.Add(node.data, counter);
                    counter++;
                }
            }
        }

        if (tree2.root != null)
        {
            foreach (Node node in tree2.Collect(tree2.root))
            {
                if (!result.Find(node.data))
                {
                    result.Add(node.data, counter);
                    counter++;
                }
            }
        }
        
        return result;
    }

    public static AVL operator & (AVL tree1, AVL tree2) // объединение
    {
        AVL result = new AVL();

        int counter = 1;

        foreach (Node node in tree2.Collect(tree2.root))
        {
            if (tree1.Find(node.data))
            {
                result.Add(node.data, counter);
                counter++;
            }
        }

        return result;
    }

    public static AVL operator / (AVL tree1, AVL tree2) //исключение
    {
        AVL result = new AVL();
        if (tree1.root == null) { return result; }
        int counter = 1;
        foreach (Node node in tree1.Collect(tree1.root))
        {
            if (!tree2.Find(node.data))
            {
                result.Add(node.data,counter);
                counter++;
            }
        }
        return result;
    }

}

