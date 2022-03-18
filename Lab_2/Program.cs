using System;

namespace Lab_2
{
    public class Person
    {
        String name { get; }
        int age { get; }
        public Person (String name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public bool Equals(Person other)
        {
            if (other == null) return false;
            if (other == this) return true;

            return Object.Equals(this.name, other.name) && Object.Equals(this.age, other.age);
        }
        public override string ToString()
        {
            return name + "(" + age + " y.o)";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
