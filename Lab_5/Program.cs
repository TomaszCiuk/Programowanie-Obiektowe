using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Lab_5.Observable;

namespace Lab_5
{
    class Program
    {
        public static void Main()
        {
            ObservableList1<int> list1 = new ObservableList1<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Set(0, 5);
            list1.Set(1, 5);
            list1.Set(2, 5);
            Console.WriteLine(list1.Get(2));
            list1.RemoveAt(2);
            list1.Add(10);
            Console.WriteLine(list1.Get(2));
        }
    }
}
