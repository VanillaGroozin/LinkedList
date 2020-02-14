using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        Node<T> head; // головной элемент
        Node<T> tail; // последний элемент
        int count;  // количество элементов в списке
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        // Метод для вставки новых элементов в конец списка.
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }

            tail = node;

            count++;
        }

        // Метод для вставки новых элементов в произвольную позицию, по индексу.
        public void Add(T data, int index)
        {
            if (index < 0 || index > count)
                throw new System.IndexOutOfRangeException();

            Node<T> node = new Node<T>(data);

            if (index != 0)
            {
                var current = GetNode(index);

                node.Previous = current.Previous;
                node.Next = current;
                current.Previous.Next = node;
                current.Previous = node;
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

            if (index != 0)
            {
                var current = GetNode(index);
                current.Previous.Next = current.Next.Previous;
                current.Next.Previous = current.Previous;
                current.Previous.Next = current.Next;
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

        private Node<T> GetNode(int index)
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
            return current;
        }

        // Свойство или метод для получения количества элементов в списке
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

        #region QSort
        private static void Swap(Node<T> x, Node<T> y)
        {
            var t = x.Data;
            x.Data = y.Data;
            y.Data = t;
        }

        // метод возвращающий индекс опорного элемента
        static int Partition(LinkedList<T> list, int minIndex, int maxIndex)
        {
            Type typeParameterType = typeof(T);
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                switch (Type.GetTypeCode(typeParameterType))
                {
                    case TypeCode.String:
                        if (string.Compare(list.GetNode(i).Data.ToString(),
                        list.GetNode(maxIndex).Data.ToString()) == -1)
                        {
                            pivot++;
                            Swap(list.GetNode(pivot), list.GetNode(i));
                        }
                        break;
                    case TypeCode.Int32:
                        if (int.Parse(list.GetNode(i).Data.ToString()) <
                            int.Parse(list.GetNode(maxIndex).Data.ToString()))
                        {
                            pivot++;
                            Swap(list.GetNode(pivot), list.GetNode(i));
                        }
                        break;
                    case TypeCode.Double:
                        if (double.Parse(list.GetNode(i).Data.ToString()) <
                            double.Parse(list.GetNode(maxIndex).Data.ToString()))
                        {
                            pivot++;
                            Swap(list.GetNode(pivot), list.GetNode(i));
                        }
                        break;
                    case TypeCode.Decimal:
                        if (decimal.Parse(list.GetNode(i).Data.ToString()) <
                            decimal.Parse(list.GetNode(maxIndex).Data.ToString()))
                        {
                            pivot++;
                            Swap(list.GetNode(pivot), list.GetNode(i));
                        }
                        break;
                    case TypeCode.DateTime:
                        if (DateTime.Parse(list.GetNode(i).Data.ToString()) <
                            DateTime.Parse(list.GetNode(maxIndex).Data.ToString()))
                        {
                            pivot++;
                            Swap(list.GetNode(pivot), list.GetNode(i));
                        }
                        break;
                    default:
                        throw new Exception("Unsupported datatype");
                }

            }
            pivot++;
            Swap(list.GetNode(pivot), list.GetNode(maxIndex));
            return pivot;
        }

        // быстрая сортировка
        private static LinkedList<T> QuickSort(LinkedList<T> list, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return list;
            }

            var pivotIndex = Partition(list, minIndex, maxIndex);
            QuickSort(list, minIndex, pivotIndex - 1);
            QuickSort(list, pivotIndex + 1, maxIndex);

            return list;
        }

        public LinkedList<T> QuickSort()
        {
            return QuickSort(this, 0, this.Count - 1);
        }
        #endregion
    }
}
