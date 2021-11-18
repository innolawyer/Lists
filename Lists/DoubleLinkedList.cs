using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List1
{
    public class DoubleLinkedList
    {
        private DoubleNode _root;
        private DoubleNode _tail;

        public int Length { get; set; }

        public DoubleLinkedList()
        {
            _root = null;
            _tail = null;
            Length = 0;
        }
        public DoubleLinkedList(int value)
        {
            _root = new DoubleNode(value);
            _tail = _root;
            Length = 1;
        }

        public void Add(int value) //добавить в конец
        {
            if (_root != null)
            {
                _tail.Next = new DoubleNode(value); ;
                _tail.Next.Previous = _tail;
                _tail = _tail.Next;
                Length++;
            }
            else
            {
                _root = new DoubleNode(value);
                _tail = _root;
                Length = 1;
            }
        }

        public override bool Equals(object obj)
        {
            DoubleLinkedList MyDoubleNode = (DoubleLinkedList)obj;
            DoubleNode tmp1 = _root;
            DoubleNode tmp2 = MyDoubleNode._root;

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
            DoubleNode MyDoubleNode = _root;
            while (MyDoubleNode != null)
            {
                s += MyDoubleNode.Value + " ";
                MyDoubleNode = MyDoubleNode.Next;
            }
            return s;
        }


    }


}
