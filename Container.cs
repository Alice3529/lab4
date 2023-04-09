using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public static class Container
    {
    internal static int roleAmount = 7;
    internal static int columnAmount = 80;
    internal static string[,] SCREEN = new string[roleAmount, columnAmount]; // создаём массив screen 

    public static void OutAll() //выводим массив screen на экран
    {
        for (int i = 0; i < Container.roleAmount; i++)
        {
            for (int y = 0; y < Container.columnAmount; y++)
            {
                Console.Write(Container.SCREEN[i, y]);
            }
            Console.WriteLine("");

        }
    }

    public static void OutPoint() //заполняем массив screen точками
    {
        for (int i = 0; i < Container.roleAmount; i++)
        {
            for (int y = 0; y < Container.columnAmount; y++)
            {
                Container.SCREEN[i, y] = ".";
            }
        }
    }
}

