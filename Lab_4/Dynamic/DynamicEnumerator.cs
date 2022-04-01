using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Dynamic
{
    class DynamicEnumerator
    {
            private int index = -1;
            private int[] table;
            public object Current => this.table[this.index];
            public MyEnumerator(int[] table)
            {
                this.table = table;
            }
            public bool MoveNext()
            {
                if (this.index < this.table.Length - 1)
                {
                    this.index += 1;
                    return true;
                }
                return false;
            }
            public void Reset()
            {
                this.index = -1;
            }
     
    }
}
