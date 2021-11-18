using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List1
{
    public class DoubleNode
    {
        public int Value { get; set; }
        public DoubleNode Next { get; set; }
        public DoubleNode Previous { get; set; }

        public DoubleNode(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}
