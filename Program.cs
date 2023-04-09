using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    //static void Main(string[] args)
    //{
    //    int[] a = { 1, 3, 4, 5, 6 };
    //    int[] b = { 5, 7, 8, 9, 3, 4 };
    //    int[] c = { 8, 9, 2, 7, 1 };
    //    int[] d = { 3, 5, 6, 7 };
    //    int[] e = { 3, 5, 6, 7, 11, 12 };

    //    ResultSets(a, b, c, d, e);

    //    AVLTree();

    //    Console.ReadKey();

    //}

    private static void ResultSets(int[] a, int[] b, int[] c, int[] d, int[] e)
    {
        var result = a.Except(b);
        var x = result.Except(c);
        var y = (x.Except(d));
        var z = (d.Except(x));
        var union = y.Union(z);
        var unionE = union.Union(e);

        int[] eArray = unionE.ToArray();

        //for (int i = 0; i < eArray.Length; i++)
        //{
        //    Console.WriteLine(eArray[i]);
        //}
    }


    private static void AVLTree()
    {
        // Create an instance of the AVL tree
        AVLTree<int> tree = new AVLTree<int>();

        // Insert some nodes into the tree
        tree.Insert(10);
        tree.Insert(20);
        tree.Insert(30);
        tree.Insert(40);
        tree.Insert(50);
        tree.Insert(25);

        tree.ShowTree();
        // Print the contents of the tree
        Console.WriteLine("AVL Tree:");
        Console.WriteLine(tree.ToString());


    }
}
        
    





