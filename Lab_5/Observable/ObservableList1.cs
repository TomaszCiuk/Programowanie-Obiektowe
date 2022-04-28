using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5.Observable
{
    class ObservableList1<T>
    {
        private List<T> list = new List<T>();
        private int lenght;
        public int Lenght
        {
            get
            {
                return lenght;
            }
            set
            {
                lenght = value;
            }
        }

        public event EventHandler<AddedEventArgs<T>> Added;
        protected virtual void OnAdded(AddedEventArgs<T> e)
        {
            EventHandler<AddedEventArgs<T>> handler = this.Added;

            handler?.Invoke(this, e);
        }

        public event EventHandler<AddedEventArgs<T>> Setted;
        protected virtual void OnSetted(AddedEventArgs<T> e)
        {
            EventHandler<AddedEventArgs<T>> handler = this.Setted;

            handler?.Invoke(this, e);
        }

        public event EventHandler<AddedEventArgs<T>> Removed;
        protected virtual void OnRemoved(AddedEventArgs<T> e)
        {
            EventHandler<AddedEventArgs<T>> handler = this.Removed;

            handler?.Invoke(this, e);
        }

        internal void Add(T value)
        {
            this.list.Add(value);

            this.OnAdded(new AddedEventArgs<T> { Index = this.list.Count - 1, Value = value });
        }
        internal void Set(int index, T value)
        {
            this.list[index] = value;

            this.OnSetted(new AddedEventArgs<T> { Index = index, Value = value });
        }
        internal T Get(int index)
        {
            return this.list[index];
        }
        internal void RemoveAt(int index)
        {
            this.list.RemoveAt(index);

            this.OnRemoved(new AddedEventArgs<T> { Index = index });
        }
    }
    public class AddedEventArgs<T> : EventArgs
    {
        public int Index { get; set; }
        public T Value { get; set; }
    }
}
