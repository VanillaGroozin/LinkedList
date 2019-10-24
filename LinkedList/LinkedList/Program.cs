using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> linkedString = new LinkedList<string>();
            LinkedList<int> linkedInt = new LinkedList<int>();

            // добавление элементов
            linkedString.Add("Alesha");
            linkedString.Add("Alex");
            linkedString.Add("Aleksey");
            linkedString.Add("Aleksandr");
            linkedString.Add("Sasha");
            linkedString.Add("Sanya");

            // добавление элемента в определенную позицию
            linkedString.Add("Saniya", 4);
            Console.WriteLine($"4. элемент: {linkedString.Get(4)}"); ;

            // удаляем
            linkedString.Remove(4);
            Console.WriteLine($"4. элемент: {linkedString.Get(4)}"); ;

            // выводим элементы
            foreach (var item in linkedString.Where(x => x.Contains("Ale")))
            {
                Console.WriteLine(item);
            }

            int count = linkedString.Count;



            Console.ReadKey();
        }
    }

    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public int Index { get; set; }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        Node<T> head; // головной элемент
        Node<T> tail; // последний элемент
        int count;  // количество элементов в списке

        // Метод для вставки новых элементов в конец списка.
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }

        // Метод для вставки новых элементов в произвольную позицию, по индексу.
        public void Add(T data, int index)
        {
            if (index < 0 || index > count)
                throw new System.IndexOutOfRangeException();

            int counter = 0;
            Node<T> node = new Node<T>(data);

            if (index != 0)
            {
                Node<T> current = head;
                Node<T> previous = null;
                while (current != null && counter != index)
                {
                    counter++;
                    previous = current;
                    current = current.Next;
                }

                node.Next = current;
                previous.Next = node;
            }
            else
            {
                node.Next = head;
                head = node;
            }

            count++;
        }

        // Метод для удаления элементов списка по индексу.
        public void Remove(int index)
        {
            if (index < 0 || index >= count)
                throw new System.IndexOutOfRangeException();

            int counter = 0;
            Node<T> current = head;
            Node<T> previous = null;

            if (index != 0)
            {
                while (current != null && counter != index)
                {
                    counter++;                  

                    previous = current;
                    current = current.Next;
                }

                previous.Next = current.Next;
            }
            else
            {
                head = current.Next;
            }
            count--;
        }

        // Метод для получения элемента списка по индексу.
        public T Get(int index)
        {
            if (index < 0 || index >= count)
                throw new System.IndexOutOfRangeException();

            int counter = 0;
            Node<T> current = head;

            while (current != null && counter != index)
            {
                counter++;
                current = current.Next;
            }
            return current.Data;
        }


        // Свойство или метод для получения количества элементов в списке.
        public int Count { get { return count; } }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

    }
}
