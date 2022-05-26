using System;
using System.Collections.Generic;

namespace test
{
    public class K
    {
        int i;

        public K(int j)
        {
            i = j;
        }

        public void m()
        {
            Console.WriteLine(i);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 2, 3, 4 };
            int[] b = new int[] { 5, 6, 7, 8 };

            Stack<int> S = new Stack<int>(a);
            Queue<int> Q = new Queue<int>(b);

            Q.Enqueue(S.Peek()); Console.WriteLine(S.Pop());
            S.Push(Q.Peek()); Console.WriteLine(Q.Dequeue());
            S.Push(Q.Peek()); Console.WriteLine(Q.Dequeue());
            Q.Enqueue(S.Peek()); Console.WriteLine(S.Pop());
            Q.Enqueue(S.Peek()); Console.WriteLine(S.Pop());
            S.Push(Q.Peek()); Console.WriteLine(Q.Dequeue());
        }
    }
}
