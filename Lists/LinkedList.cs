using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List1
{
    public class LinkedList
    {
        private Node _root;

        #region Constructors
        public LinkedList()
        {
            _root = null;
        }
        public LinkedList(int value)
        {
            _root = new Node(value);
        }

        public LinkedList(int[] array)
        {
            if (array.Length == 0)
            {
                _root = null;
                return;
            }
            Node newN = new Node(array[0]);
            int crnt = 1;
            _root = newN;
            while (crnt < array.Length)
            {
                newN.Next = new Node(array[crnt]);
                newN = newN.Next;
                crnt++;
            }
        }
        #endregion

        #region Indexator
        public int this[int index] //доступ к элементу по индексу, правильный вариант)
        {
            get
            {
                if (index < 0 || index >= GetLength())
                {
                    throw new IndexOutOfRangeException();
                }
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }
            set
            {
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }
        #endregion


        public void Add(int value) //добавить в конец
        {
            if (_root != null)
            {
                Node tmp = _root;

                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }

                tmp.Next = new Node(value);
            }
            else
            {
                _root = new Node(value);
            }
        }

        public void AddFirst(int value) //добавить в начало
        {
            if (_root != null)
            {
                Node tmp = new Node(_root.Value);
                tmp.Next = _root.Next;
                _root.Value = value;
                _root.Next = tmp;
            }
            else
            {
                _root = new Node(value);
            }
        }

        public void Insert(int index, int value) //добавить значение по индексу
        {
            if (index < 0 && index > GetLength())
            {
                throw new IndexOutOfRangeException();
            }

            if (_root != null)
            {
                if (index == 0)
                {
                    AddFirst(value);
                }
                else
                {
                    Node tmp = _root;

                    for (int i = 1; i < index + 1; i++)
                    {
                        tmp = tmp.Next;
                    }

                    Node tmp2 = new Node(tmp.Value);
                    tmp2.Next = tmp.Next;
                    tmp.Value = value;
                    tmp.Next = tmp2;
                }
            }
            else
            {
                _root = new Node(value);
            }
        }

        public void RemoveFirst() //удалить первый элемент
        {
            _root = _root.Next;
        }

        public void RemoveLast() //удалить последний элемент
        {
            if (_root != null)
            {
                Node tmp = _root;

                while (tmp.Next.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = tmp.Next.Next;
            }
            //else
            //{
            //    throw new NullReferenceException();
            //}
        }



        public void RemoveByIndex(int index) //удалить по индексу
        {
            if (index < 0 && index > GetLength())
            {
                throw new IndexOutOfRangeException();
            }
            if (_root != null)
            {
                Node tmp = _root;

                if (index == 0)
                {
                    RemoveFirst();
                }

                for (int i = 1; i <= index - 1; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = tmp.Next.Next;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void RemoveLastNElements(int n) // Удалить последние N элементов
        {
            //for (int i = 0; i<n; i++)
            //{
            //    RemoveLast();
            //}

            int length = 0;
            Node tmp = _root;
            while (tmp != null)
            {
                tmp = tmp.Next;
                length++;
            }
            if (n > length)
            {
                throw new ArgumentException();
            }
            tmp = _root;
            int newLength = length - n;
            int counter = 0;
            while (counter != newLength - 1)
            {
                tmp = tmp.Next;
                counter++;
            }
            tmp.Next = null;
        }



        public void RemoveFirstNElements(int n) //Удалить первые N элементов
        {
            for (int i = 0; i < n; i++)
            {
                RemoveFirst();
            }
        }

        public void RemoveByIndexNElements(int index, int n) //удалить N элементов по индексу
        {
            for (int i = 0; i < n; i++)
            {
                RemoveByIndex(index);
            }
        }

        public int GetLength() // вернуть длину
        {
            Node tmp = _root.Next;

            int lenght = 1;
            if (_root != null)
            {
                while (tmp != null)
                {
                    tmp = tmp.Next;
                    lenght++;
                }

            }
            else
            {
                throw new NullReferenceException();
            }
            return lenght;

        }

        public int ReadByIndex(int index) //чтение по индексу, так себе вариант, выше есть через гетсет
        {
            if (index < 0 && index > GetLength())
            {
                throw new IndexOutOfRangeException();
            }
            if (_root != null)
            {
                Node tmp = _root;

                if (index == 0)
                {
                    return _root.Value;
                }

                for (int i = 1; i <= index - 1; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }
            else
            {
                throw new NullReferenceException();
            }
        }


        public int GetFirstIndexByValue(int value) //вернуть первый индекс по значению
        {

            Node tmp = _root.Next;
            int index = 1;

            if (_root.Value == value)
            {
                return 0;
            }

            else
            {
                while (tmp.Value != value)
                {
                    tmp = tmp.Next;
                    index++;
                }
                return index;
            }
        }

        public void EditByIndex(int index, int value) //изменить значение по индексу
        {
            if (index < 0 && index > GetLength())
            {
                throw new IndexOutOfRangeException();
            }
            if (_root != null)
            {
                Node tmp = _root;

                if (index == 0)
                {
                    _root.Value = value;
                }

                for (int i = 1; i <= index - 1; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }



        public void Reverse() //развернуть
        {
            if (_root != null)
            {
                Node oldRoot = _root;
                Node current;
                while (oldRoot.Next != null)
                {
                    current = oldRoot.Next;
                    oldRoot.Next = current.Next;
                    current.Next = _root;
                    _root = current;
                }
            }

        }

        public int GetMaxValue() //вернуть максимальное значение
        {
            Node tmp = _root;

            int max = tmp.Value;

            if (_root != null)
            {

                while (tmp.Next != null)
                {
                    tmp = tmp.Next;

                    if (tmp.Value > max)
                    {
                        max = tmp.Value;

                    }

                }

            }
            return max;

        }

        public int GetMinValue() //вернуть минимальное значение
        {
            Node tmp = _root;

            int min = tmp.Value;

            if (_root != null)
            {

                while (tmp.Next != null)
                {
                    tmp = tmp.Next;

                    if (tmp.Value < min)
                    {
                        min = tmp.Value;

                    }

                }
            }
            return min;

        }

        public int GetIndexOfMax() //вернуть индекс максимального значения
        {
            Node tmp = _root;

            int max = tmp.Value;
            int indexOfMax = 0;

            if (_root != null)
            {

                while (tmp.Next != null)
                {
                    tmp = tmp.Next;

                    if (tmp.Value > max)
                    {
                        max = tmp.Value;

                    }
                }
                tmp = _root;
                while (tmp.Value != max)
                {
                    tmp = tmp.Next;
                    indexOfMax++;
                }
                return indexOfMax;
            }
            else
            {
                return -1;
            }
        }

        public int GetIndexOfMin() //вернуть индекс минимального значения
        {
            Node tmp = _root;

            int min = tmp.Value;
            int indexOfMin = 0;

            if (_root != null)
            {

                while (tmp.Next != null)
                {
                    tmp = tmp.Next;

                    if (tmp.Value < min)
                    {
                        min = tmp.Value;

                    }
                }
                tmp = _root;
                while (tmp.Value != min)
                {
                    tmp = tmp.Next;
                    indexOfMin++;
                }
                return indexOfMin;
            }
            else
            {
                return -1;
            }
        }



        public void SortFromMinToMax() //сортировка по возрастанию
        {
            Node newRoot = new(GetMinValue()); ;
            Node newNext = newRoot; ;
            int min = newRoot.Value; ;
            if (_root != null)
            {
                while (_root.Next != null)
                {
                    RemoveFirstByValue(min);
                    newNext.Next = new(GetMinValue());
                    newNext = newNext.Next;
                    min = newNext.Value;
                }
                _root = newRoot;
            }


        }

        public void SortFromMaxToMin() //сортировка по убыванию
        {
            Node newRoot = new(GetMaxValue());
            Node newNext = newRoot;
            int max = newRoot.Value;
            if (_root != null)
            {
                while (_root.Next != null)
                {
                    RemoveFirstByValue(max);
                    newNext.Next = new(GetMaxValue());
                    newNext = newNext.Next;
                    max = newNext.Value;
                }
                _root = newRoot;
            }


        }

        public int RemoveFirstByValue(int value) //удаление первого найденного элемента по значению
        {
            int index = 0;
            Node first = _root;
            Node second = _root.Next;


            if (_root != null)
            {
                Node tmp = _root;

                while (tmp != null)
                {
                    if (tmp.Next.Value == value)
                    {
                        tmp.Next = tmp.Next.Next;
                        return index;

                    }
                    index++;
                    tmp = tmp.Next;
                }
            }
            return -1;
        }


        public int RemoveAllByValue(int value) //удаление всех найденных элементов по значению
        {
            Node first = _root;
            int count = 0;
            Node tmp = new Node(_root.Value);
            Node newRoot = tmp;
            _root = _root.Next;
            while (_root != null)
            {
                if (_root.Value != value)
                {
                    tmp.Next = new Node(_root.Value);
                    tmp = tmp.Next;
                }
                else
                {
                    count++;
                }
                _root = _root.Next;
            }
            _root = newRoot;
            if (_root.Value == value)
            {
                _root = _root.Next;
                count++;
            }
            return count;

            //while (_root.Value == value)
            //{

            //    _root = _root.Next;
            //    count++;
            //    if (_root==null)
            //    {
            //        return count;
            //    }
            //}

            //Node second = _root.Next;

            //while (second!=null)
            //{
            //    if (_root.Value == value)
            //    {
            //        _root = _root.Next;
            //    }

            //    if (second.Value == value)
            //    {
            //        first.Next = second.Next;
            //        count++;
            //    }
            //    first = second;
            //    second = second.Next;
            //}
            //return count;

        }

        public void AddFirst(LinkedList secondLinkedList) //добавить линкед лист в начало линкед листа
        {
            Node tmp = _root;

            if (secondLinkedList._root != null && _root != null)
            {
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = secondLinkedList._root;

            }
            else
            {
                _root = secondLinkedList._root;
            }
        }

        public void Add(LinkedList secondLinkedList) //добавить линкед лист в конец линкед листа
        {
            Node tmp = secondLinkedList._root;

            if (secondLinkedList._root != null && _root != null)
            {
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = _root;
                _root = secondLinkedList._root;
            }

            else
            {
                _root = secondLinkedList._root;
            }
        }

        public void Insert(int index, LinkedList newList)
        {
            if (index < 0 && index > GetLength())
            {
                throw new IndexOutOfRangeException();
            }

            Node node = newList._root;
            int i = index;
            while (node != null)
            {
                Insert(i, node.Value);
                i++;
                node = node.Next;
            }

        }




        public void WriteToConsole()
        {
            if (_root == null)
            {
                Console.WriteLine();
            }
            Node node = _root;
            string result = "";
            while (node != null)
            {
                result += node.Value + " ";
                node = node.Next;
            }
            Console.WriteLine($"{result}");
        }

        public override bool Equals(object obj)
        {
            LinkedList MyNode = (LinkedList)obj;
            Node tmp1 = _root;
            Node tmp2 = MyNode._root;

            if (tmp1 == null && tmp2 == null)
            {
                return false;
            }
            while (tmp1 != null && tmp2 != null)
            {
                if ((tmp1.Next == null && tmp2.Next != null)
                || (tmp1.Next != null && tmp2.Next == null))
                {
                    return false;
                }
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;

        }

        public override string ToString()
        {
            string s = "";
            if (_root == null)
                return s;
            Node myNode = _root;
            while (myNode != null)
            {
                s += myNode.Value + " ";
                myNode = myNode.Next;
            }
            return s;
        }



    }
}
