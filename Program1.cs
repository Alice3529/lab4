using System;
using System.Collections.Generic;

class Program1
{
    const int power = 6;

    static AVL a = null;
    static AVL b = null;
    static AVL c = null;
    static AVL d = null;
    static AVL e = null;
    static void Main(string[] args)
    {
        VVOD();

        Console.WriteLine("(A/B/C) XOR D U E");

        AVL result = (((a / b / c) + d) / ((a / b / c) & d)) + e;
        result.Display();

        Console.WriteLine("MUL a");
        Console.WriteLine("Введите количество раз выполнения операции MUL");
        int amount = Convert.ToInt32(Console.ReadLine());
        AVL mul = TreeOperations.MUL(a, 3);
        mul.Display();

        Console.WriteLine("Concat a, b");
        AVL concat = TreeOperations.CONCAT(a, b);
        concat.Display();

        Console.WriteLine("EXCEL a, b");
        AVL excel = TreeOperations.EXCEL(a, b);
        excel.Display();

        Console.ReadKey();
    }

    private static void VVOD()
    {
        Console.WriteLine("Генерация множества: a - автоматически, b-вручную");
        char vvod = Console.ReadKey().KeyChar;
        Console.WriteLine("");

        if (vvod == 'b')
        {
            a = CreateSet("a");
            b = CreateSet("b");
            c = CreateSet("c");
            d = CreateSet("d");
            e = CreateSet("e");
        }
        else if (vvod == 'a')
        {
            a = GenerateSet("a");
            b = GenerateSet("b");
            c = GenerateSet("c");
            d = GenerateSet("d");
            e = GenerateSet("e");
        }
        else
        {
            Console.WriteLine("Неверный ввод, попробуйте ещё раз.");
            VVOD();
        }
    }

    public static AVL GenerateSet(string setName)
    {
        AVL tree = new AVL();
        int counter = 0;
        Console.WriteLine(setName);
        for (int i = 0; i < power; i++)
        {
            counter++;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int value = rnd.Next(1, 10);
            tree.Add(value, counter);
        }
        tree.Display();
        return tree;
        
    }

    public static AVL CreateSet(string setName)
    {
        Console.WriteLine("Введите размер множества" + " " + setName);
        int amount = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите элементы множества" + " " + setName);
        AVL tree = new AVL();
        int i = 0;

        while (i<amount)
        {
            i++;
            int number=Convert.ToInt32(Console.ReadLine());
            tree.Add(number, i);
        }
        tree.Display();
        return tree;


    }
}
