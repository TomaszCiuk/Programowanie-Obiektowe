using System;
using System.Collections.Generic;

namespace Lab_2
{
    public class Person
    {
        protected string name { get; set; }
        protected int age { get; set; }
        public Person (string name, int age)
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
    public enum TaskStatus
    {
        Waiting,
        Progress,
        Done,
        Rejected
    }
    public class Task
    {
        private String name { get; set; }
        private TaskStatus status { get; set; }
        public Task (string name, TaskStatus status)
        {
            this.name = name;
            this.status = status;
        }
        public bool Equals(Task other)
        {
            if (other == null) return false;
            if (other == this) return true;

            return Object.Equals(this.name, other.name) && Object.Equals(this.status, other.status);
        }
        public override string ToString()
        {
            return "Task "+name+" ["+status+"]";
        }
    }
    public class Student : Person
    {
        protected string group { get; set; }
        protected List<Task> tasks = new List<Task>();
        public Student (string name, int age, string group) : base (name,age)
        {
            this.name = name;
            this.age = age;
            this.group = group;
        }
        public Student(string name, int age, string group, List<Task> tasks) : base(name, age)
        {
            this.name = name;
            this.age = age;
            this.group = group;
            this.tasks = tasks;
        }
        public void AddTask (string taskName, TaskStatus taskStatus)
        {
            tasks.Add(new Task(taskName, taskStatus);
        }
        public void RemoveTask (int index)
        {
            tasks.RemoveAt(index);
        }
        public void UpdateTask(int index, TaskStatus taskStatus)
        {
            tasks[index] = taskStatus; 
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
