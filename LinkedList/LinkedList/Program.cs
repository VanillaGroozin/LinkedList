using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList.LinkedList;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList.LinkedList.LinkedList<string> linkedString = new LinkedList.LinkedList.LinkedList<string>();
            LinkedList.LinkedList.LinkedList<int> linkedInt = new LinkedList.LinkedList.LinkedList<int>();

            // добавление элементов          
            linkedString.Add("Sasha");
            linkedString.Add("Alex");
            linkedString.Add("Sanya");
            linkedString.Add("Alesha");
            linkedString.Add("Boris");
            linkedString.Add("Mark");
            linkedString.Add("Gosha");
            linkedString.Add("Eldar");
            linkedString.Add("Aleksey");
            linkedString.Add("Aleksandr");

            // добавление элемента в определенную позицию
            linkedString.Add("Saniya", 4);
            Console.WriteLine($"4. элемент: {linkedString.Get(4)}"); ;

            // удаляем
            linkedString.Remove(4);
            Console.WriteLine($"4. элемент: {linkedString.Get(4)}"); ;

            // выводим элементы с "Ale"
            foreach (var item in linkedString.Where(x => x.Contains("Ale")))
            {
                Console.WriteLine(item);
            }
            // выводим количество элементов
            Console.WriteLine($"Количество элементов: {linkedString.Count}");

            // выводим все элементы
            Console.Write("Неотсортированный лист: ");
            foreach (var item in linkedString)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // сортируем
            linkedString.QuickSort();
            // выводим все отсортированные элементы
            Console.Write("Отсортированный лист: ");
            foreach (var item in linkedString)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            // другие типы тоже работают
            linkedInt.Add(1);
            linkedInt.Add(6);
            linkedInt.Add(8);
            linkedInt.Add(3);
            linkedInt.Add(10);
            linkedInt.Add(5);
            linkedInt.Add(2);
            linkedInt.Add(4);
            linkedInt.Add(7);
            linkedInt.Add(9);

            // выводим все элементы
            Console.Write("Неотсортированный лист: ");
            foreach (var item in linkedInt)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // сортируем
            linkedInt.QuickSort();
            // выводим все отсортированные элементы
            Console.Write("Отсортированный лист: ");
            foreach (var item in linkedInt)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();
        }
    }
}
