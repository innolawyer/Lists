using System;

namespace List1
{
    public class ArrayList
    {
        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[index];
            }
            set
            {
                if (index >= Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[index] = value;
            }
        }

        private const int _minArrayLength = 10;

        private int[] _array;

        public ArrayList()
        {
            Length = 0;
            _array = new int[_minArrayLength];
        }

        public ArrayList(int a) //сделать конструктор
        {
            Length = a;
            _array = new int[Length];
        }

        public ArrayList(int[] a)
        {
            _array = new int[(int)(a.Length * 1.5 + 1)];
            Length = a.Length;
            Array.Copy(a, _array, Length);
        }



        public void Add(int value) //добавление значения в конец
        {
            if (Length == _array.Length)
            {
                UpArraySize();
            }


            _array[Length] = value;
            Length++;
        }

        public void AddFirst(int value) //добавление значения в начало
        {
            if (Length == _array.Length)
            {
                UpArraySize();
            }
            if (Length == 0)
            {
                Length++;
                ShiftToRight(Length, 0);
                _array[0] = value;
            }
            else
            {
                ShiftToRight(0, Length);
                Length++;
                _array[0] = value;
            }


        }

        public void Insert(int index, int value) //добавление значения по индексу
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (Length == _array.Length)
            {
                UpArraySize();
            }

            for (int i = Length; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[index] = value;
            Length++;
        }


        public void RemoveLast() //удаление из конца одного элемента
        {
            if (Length > 0)
            {
                _array[Length - 1] = 0;
                Length--;
                DownArraySize();
            }

        }

        public void RemoveFirst() //удаление из начала одного элемента
        {
            if (Length > 0)
            {
                DownArraySize();
                ShiftToLeft(1, Length);
                Length--;
            }


        }

        public void RemoveByIndex(int index) //удаление значения по индексу
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }


            DownArraySize();
            int tmp;
            for (int i = index; i < Length; i++)
            {
                tmp = _array[i];
                _array[i] = _array[i + 1];
                _array[i + 1] = tmp;
            }
            Length--;
        }

        public void RemoveLastNElements(int n) //удаление N элементов из конца
        {
            if (n > Length || n < 0)
            {
                throw new ArgumentException();
            }
            Length -= n;


        }

        public void RemoveFirstNElements(int n) //удаление N элементов из начала
        {

            if (n > Length || n < 0)
            {
                throw new ArgumentException();
            }

            DownArraySize();

            int tmp;
            for (int i = 0; i < Length - n; i++)
            {
                tmp = _array[i];
                _array[i] = _array[i + n];
                _array[i + n] = tmp;
            }
            Length -= n;
        }

        public void RemoveByIndexNElements(int index, int n) //удаление по индексу N элементов 
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (n > Length || n < 0)
            {
                throw new ArgumentException();
            }

            for (int i = index + n; i != index; i--)
            {

                RemoveByIndex(i - 1);

            }

        }



        public int GetLength() //вернуть длину
        {
            return Length;
        }



        public int ReadByIndex(int index) //доступ по индексу
        {
            if (index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = 0; i < Length; i++)
            {
                if (i == index)
                {
                    return _array[i];
                }
            }
            return -1;
        }

        public int GetFirstIndexByValue(int value) //найти первый индекс по значению
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }


        public void EditByIndex(int index, int value) // изменить значение по индексу
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            _array[index] = value;
        }

        public void Reverse() //разворот массива
        {
            if (Length > 0)
            {
                for (int i = 0; i < Length / 2; i++)
                {
                    int tmp = _array[i];
                    _array[i] = _array[Length - i - 1];
                    _array[Length - i - 1] = tmp;
                }
            }



        }

        public int GetMaxValue() //найти максимальный элемент
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int max = _array[0];

            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }

        public int GetMinValue() //найти минимальный элемент
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int min = _array[0];

            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }
            return min;
        }

        public int GetIndexOfMin() //индекс минимального элемента
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int min = _array[0];
            int minIndex = 0;

            for (int i = 1; i < Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }


        public int GetIndexOfMax() //индекс максимального элемента
        {
            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            int max = _array[0];
            int maxIndex = 0;

            for (int i = 1; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public void SortFromMinToMax() //отсортировать по возрастанию
        {
            for (int i = 0; i < Length; i++)
            {
                int indexOfMin = i;
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[j] < _array[indexOfMin])
                    {
                        indexOfMin = j;
                    }
                }
                int tmp = _array[i];
                _array[i] = _array[indexOfMin];
                _array[indexOfMin] = tmp;
            }
        }

        public void SortFromMaxToMin() //отсортировать по убыванию
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = i + 1; j < Length; j++)
                {
                    if (_array[j] > _array[i])
                    {
                        int tmp = _array[i];
                        _array[i] = _array[j];
                        _array[j] = tmp;
                    }
                }
            }

        }

        public int RemoveFirstByValue(int value) //удалить первое найденное значение и вернуть индекс
        {
            DownArraySize();
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    int tmp;
                    for (int j = i; j < Length; j++)
                    {
                        tmp = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = tmp;
                    }
                    Length--;
                    return i;
                }
            }
            return -1;
        }

        public int RemoveAllByValue(int value) //удалить все найденные значения и вернуть количество
        {
            DownArraySize();
            {
                int count = 0;
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] == value)
                    {
                        int start = i + 1;
                        ShiftToLeft(start, Length);
                        i--;
                        Length--;
                        count++;
                    }

                }
                return count;
            }
        }

        public void AddArrayListToEnd(ArrayList arrayList)
        {
            for (int i = 0; i < arrayList.Length; i++)
            {
                Add(arrayList[i]);
            }
        }

        public void AddArrayListToStart(ArrayList arrayList)
        {
            //int i = 0;
            //while (arrayList.Length > i)
            //{
            //    Insert(i, arrayList[i]);
            //    i++;
            //}
            for (int i = 0; i < arrayList.Length; i++)
            {
                ShiftToRight(i, Length - 1);
                _array[i] = arrayList[i];
            }



        }

        public void AddArrayListByIndex(ArrayList arrayList, int index)
        {
            if (Length + arrayList.Length >= _array.Length)
            {
                UpArraySize(arrayList.Length);
            }

            for (int i = index; i < arrayList.Length + index; i++)
            {
                ShiftToRight(Length - 1, i + 1);
                _array[i + 1] = arrayList[i - index];
                Length++;
            }
        }









        #region WriteToConsole
        public void WriteToConsole()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.Write($"{_array[i]} ");
            }
            Console.WriteLine();
        }
        #endregion


        public override bool Equals(object obj)
        {
            int i = 0;

            ArrayList arrayList = (ArrayList)obj;
            if (Length != arrayList.Length)
            {
                return false;
            }
            while (i < Length)
            {
                if (arrayList._array[i] != _array[i])
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Length; i++)
            {
                s += $"{_array[i]} ";
            }
            return s;
        }

        #region PrivateMethods
        private void UpArraySize(int count = 0) //увеличить размер массива
        {
            int[] tmpArray = new int[(int)(Length * 1.5) + count];
            for (int i = 0; i < Length; i++)
            {
                tmpArray[i] = _array[i];
            }
            _array = tmpArray;
        }

        private void DownArraySize() //уменьшить размер массива
        {
            if (Length <= (_array.Length / 2) && Length * 0.7 > _minArrayLength)
            {
                int[] tmpArray = new int[(int)(Length * 0.7)];
                for (int i = 0; i < Length; i++)
                {
                    tmpArray[i] = _array[i];
                }
                _array = tmpArray;
            }


        }


        private void ShiftToLeft(int start, int end) //подвинуть влево
        {
            for (int i = start; i < end; i++)
            {
                _array[i - 1] = _array[i];
            }
        }


        private void ShiftToRight(int start, int end) //подвинуть вправ
        {

            for (int i = end; i >= start; i--)
            {
                _array[i + 1] = _array[i];

            }
        }
        #endregion

    }
}
