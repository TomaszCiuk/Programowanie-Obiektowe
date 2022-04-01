using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.Dynamic
{
    class DynamicArray<T> : IEnumerable<T>
    {
        private int[] table;
        public DynamicArray(int[] table)
        {
            this.table = table;
        }
        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(this.table);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
