using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User { Name = "Karol" , Role = "Student", Age = 23, Marks = new int[] {3, 3, 3, 4, 5 }},
                new User { Name = "Maciek" , Role = "Student", Age = 21, Marks = new int[] {3, 3, 4, 4, 5, 4}},
                new User { Name = "Bartek" , Role = "Student", Age = 22, Marks = new int[] {3, 4, 3, 4, 5, 3}},
                new User { Name = "Wincenty" , Role = "Student", Age = 19, Marks = new int[] {4, 3, 4, 5, 4}},
                new User { Name = "Robert" , Role = "Student", Age = 18, Marks = new int[] {3, 3, 3, 3, 3 }},
                new User { Name = "Hubert" , Role = "Student", Age = 25, Marks = new int[] {4, 4, 4, 5, 5}},
                new User { Name = "Piotrek" , Role = "Student", Age = 32, Marks = new int[] {4, 3, 4, 5, 5}},
                new User { Name = "Bartek" , Role = "Student", Age = 35, Marks = new int[] {3, 3, 3, 4, 5}},
                new User { Name = "Daniel" , Role = "Student", Age = 33, Marks = new int[] {4, 3, 4, 4, 5,}},
                new User { Name = "Dimitro" , Role = "Student", Age = 26, Marks = new int[] {3, 4, 4, 4, 5} },
                new User { Name = "Damian" , Role = "Student", Age = 29, Marks = new int[] {} },
                new User { Name = "Bartosz", Role = "Teacher", Age = 40, Marks = null },
                new User { Name = "Tomek", Role = "Teacher", Age = 34, Marks = null  },
                new User { Name = "Jacenty", Role = "Teacher", Age = 64, Marks = null  },
                new User { Name = "Grzegorz", Role = "Teacher", Age = 47, Marks = null  },
                new User { Name = "Karol", Role = "Teacher", Age = 39, Marks = null  },
                new User { Name = "Wiktor", Role = "Moderator", Age = 34, Marks = null  },
                new User { Name = "Norbert", Role = "Moderator", Age = 54, Marks = null  },
                new User { Name = "Ulbert", Role = "Moderator", Age = 52, Marks = null   },
                new User { Name = "Wit", Role = "Admin", Age = 65, Marks = null }
            };
            //1. Liczba rekordów w tablicy
            //Console.WriteLine(users.Count);
            //Console.WriteLine((from user in users select user).Count());

            //2. Lista nazw użytkowników
            List<string> names_1 = users.Select(user => user.Name).ToList();
            List<string> names_2 = (from user in users select user.Name).ToList();
            //foreach (string name in names_2)
            //    Console.WriteLine(name);

            //3. Posortowana lista użytkownikow po nazwach
            List<User> users_1 = users.OrderBy(user => user.Name).ToList();
            List<User> users_2 = (from user in users orderby user.Name select user).ToList();
            //foreach (User user in users_2)
            //    Console.WriteLine(user.Name);

            //4. Lista dostępnych ról
            List<string> rules_1 = users.Select(user => user.Role).Distinct().ToList();
            List<string> rules_2 = (from user in users select user.Role).Distinct().ToList();
            //foreach (string role in rules_2)
            //   Console.WriteLine(role);

            //5. Lista użytkowników pogrupowanych po rolach
            var rulesGroup_1 = users.GroupBy(user => user.Role).Select(group => group).ToList();
            var rulesGroup_2 = (from user in users group user by user.Role).ToList();
            //foreach (var group in rulesGroup_2)
            //{
            //    Console.WriteLine(group.Key);
            //    foreach (User user in group)
            //        Console.WriteLine("--> " + user.Name);
            //}

            //6. Ilość rekordów, dla których podano oceny (nie null i więcej niż 0)
            Console.Write(users.Where(user => user.Marks is not null || user.Marks.Length > 0).Count());
        }
    }
    public class User
    {
        public string Name { get; set; }
        public string Role { get; set; } // ADMIN, MODERATOR, TEACHER, STUDENT
        public int Age { get; set; }
        public int[] Marks { get; set; } // zawsze null gdy ADMIN, MODERATOR lub TEACHER
        public DateTime? CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
    }
}
