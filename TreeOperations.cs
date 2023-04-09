using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   static class TreeOperations
    {

    public static AVL MUL(AVL tree1, int amount = 0) //умножение 
    {
        AVL result = new AVL();
        if (tree1.root == null) { return tree1; }
        int counter = tree1.maxAmount + 1;
        int counter1 = tree1.maxAmount;
        int i = 0;
        CopyTreeData(tree1, result, counter);
        while (counter < (counter1 * amount + 1))
        {
            i++;
            if (i % (counter1 + 1) == 0) { continue; }
            int m = i % (counter1 + 1);
            result.Add(tree1.FindByNumber(m).data, counter++);
        }
        return result;
    }

    private static void CopyTreeData(AVL tree1, AVL result, int counter)
    {
        for (int s = 1; s < counter; s++)
        {
            result.Add(tree1.FindByNumber(s).data, s);
        }
    }

    public static AVL CONCAT(AVL tree1, AVL tree2) // объединение
    {
        AVL result = new AVL();

        if (tree1.root != null)
        {
            int counter = tree1.maxAmount + 1;
            int counter1 = tree2.maxAmount + 1;

            CopyTreeData(tree1, result, counter);

            for (int i=1; i<counter1; i++)
            {
                result.Add(tree2.FindByNumber(i).data, counter++);

            }
        }
        return result;
    }

    public static AVL EXCEL(AVL tree1, AVL tree2) // объединение
    {
        AVL result = new AVL();

        if (tree1.root != null)
        {
            CopyTreeData(tree1, result, tree1.maxAmount + 1);

            int counter = result.maxAmount + 1;
            int counter1 = tree2.maxAmount + 1;

            if (counter1 > counter)
            {
                Console.WriteLine("Невозможно исключить вторую последовательность из первой");
                return result;
            }

            AVL.Node startNode=tree2.FindByNumber(1);
            if (result.Find(startNode.data))
            {
                AVL.Node sameNode = result.GetNodeByData(startNode.data);
                CheckAllNodeNumbers(sameNode, counter1, result, tree2);
            }
           
        }
        return result;
    }

    private static void CheckAllNodeNumbers(AVL.Node sameNode, int counter1, AVL tree1, AVL tree2)
    {
        int x = 0;

        while (sameNode.numbers.Count != x)
        {
            if (!CompareSequence(sameNode.numbers[x], counter1, tree1, tree2))
            {
                x++;
            }
        }

    }

    private static bool CompareSequence(int firstTreeNumber, int counter1, AVL tree1, AVL tree2)
    {
        List<AVL.Node> objectsToDelete = new List<AVL.Node>();

        bool same = true;
        int m = firstTreeNumber;

        if ((m + tree2.maxAmount - 1) > tree1.maxAmount)
        {
            same = false;
            return same;
        }

        for (int i = 1; i < counter1; i++)
        {
            if (tree1.FindByNumber(m).data != tree2.FindByNumber(i).data)
            {
                same = false;
                break;
            }
            m++;
        }

        m = firstTreeNumber;

        if (same == true)
        {
            for (int i = 1; i < counter1; i++)
            {
                AVL.Node node = tree1.FindByNumber(m);
                objectsToDelete.Add(tree1.FindByNumber(m));
                node.deleteNumbers.Add(m);
                m++;
            }
           
            Delete(objectsToDelete, tree1, firstTreeNumber);
           
        }


  
        return same;
    }

    public static void Delete(List<AVL.Node> objectsToDelete, AVL tree1, int firstNumber)
    {
        int length = objectsToDelete.Count;

        for (int i=0; i<objectsToDelete.Count; i++)
        {
            if (objectsToDelete[i].duplicates < 2)
            {
                objectsToDelete[i].duplicates -= 1;
                objectsToDelete[i].numbers.Remove(objectsToDelete[i].deleteNumbers[0]);
                objectsToDelete[i].deleteNumbers.Remove(objectsToDelete[i].deleteNumbers[0]);
                tree1.Delete(objectsToDelete[i].data);

            }
            else
            {
                objectsToDelete[i].duplicates -= 1;
                objectsToDelete[i].numbers.Remove(objectsToDelete[i].deleteNumbers[0]);
                objectsToDelete[i].deleteNumbers.Remove(objectsToDelete[i].deleteNumbers[0]);
            }
        }
        tree1.maxAmount -= length;
        tree1.Reorder(firstNumber, length);
    }
}

