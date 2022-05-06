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
                new User { Name = "Karol" , Role = "Student", Age = 23, Marks = new int[] {3, 3, 3, 4, 5 }, CreatedAt = new DateTime(2017, 1, 2)},
                new User { Name = "Maciek" , Role = "Student", Age = 21, Marks = new int[] {3, 3, 4, 4, 5, 4}, CreatedAt = new DateTime(2017, 3, 4)},
                new User { Name = "Bartek" , Role = "Student", Age = 22, Marks = new int[] {3, 4, 5, 3}, CreatedAt = new DateTime(2017, 2, 16)},
                new User { Name = "Wincenty" , Role = "Student", Age = 19, Marks = new int[] {4, 5, 4}, CreatedAt = new DateTime(2017, 2, 16)},
                new User { Name = "Robert" , Role = "Student", Age = 18, Marks = new int[] {3, 3, 3, 3, 3 }, CreatedAt = new DateTime(2017, 6, 16)},
                new User { Name = "Hubert" , Role = "Student", Age = 25, Marks = new int[] {4, 4, 4, 5, 5}, CreatedAt = new DateTime(2017, 1, 2)},
                new User { Name = "Piotrek" , Role = "Student", Age = 32, Marks = new int[] {4, 5, 5}, CreatedAt = new DateTime(2016, 3, 16), RemovedAt = new DateTime(2019, 3, 1)},
                new User { Name = "Bartek" , Role = "Student", Age = 35, Marks = new int[] {3, 3, 3, 4, 5}, CreatedAt = new DateTime(2015, 3, 16), RemovedAt = new DateTime(2018, 2, 1)},
                new User { Name = "Daniel" , Role = "Student", Age = 33, Marks = new int[] {4, 3, 4,}, CreatedAt = new DateTime(2017, 12, 3), RemovedAt = new DateTime(2019, 3, 1)},
                new User { Name = "Dimitro" , Role = "Student", Age = 26, Marks = new int[] {3, 4}, CreatedAt = new DateTime(2014, 3, 16), RemovedAt = new DateTime(2017, 3, 1) },
                new User { Name = "Damian" , Role = "Student", Age = 29, Marks = new int[] {} },
                new User { Name = "Bartosz", Role = "Teacher", Age = 40, Marks = null, CreatedAt = new DateTime(2014, 3, 16)},
                new User { Name = "Tomek", Role = "Teacher", Age = 34, Marks = null, CreatedAt = new DateTime(2016, 3, 16), RemovedAt = new DateTime(2019, 3, 1)  },
                new User { Name = "Jacenty", Role = "Teacher", Age = 64, Marks = null, CreatedAt = new DateTime(2010, 3, 16)},
                new User { Name = "Grzegorz", Role = "Teacher", Age = 47, Marks = null, CreatedAt = new DateTime(2008, 3, 16), RemovedAt = new DateTime(2018, 5, 2)  },
                new User { Name = "Karol", Role = "Teacher", Age = 39, Marks = null, CreatedAt = new DateTime(2008, 3, 16) },
                new User { Name = "Wiktor", Role = "Moderator", Age = 34, Marks = null, CreatedAt = new DateTime(2004, 1, 1)  },
                new User { Name = "Norbert", Role = "Moderator", Age = 54, Marks = null, CreatedAt = new DateTime(2007, 7, 13)  },
                new User { Name = "Ulbert", Role = "Moderator", Age = 52, Marks = null, CreatedAt = new DateTime(2008, 3, 16)   },
                new User { Name = "Wit", Role = "Admin", Age = 65, Marks = null, CreatedAt = new DateTime(2004, 3, 16), RemovedAt = new DateTime(2010, 12, 31) }
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
            var marks = users.Where(user => user.Marks != null && user.Marks.Length > 0).Select(user => user).Count();
            //Console.WriteLine("Liczba rekordów dla których nie podano ocney: " + marks);
            //Console.WriteLine("Liczba rekordów dla których nie podano ocney: " + (from user in users where user.Marks != null && user.Marks.Length > 0 select user).Count());

            //7. --------- Suma,ilość i średnia wszystkich ocen studentow ---------
            var countUsers_1 = (from user in users where user.Marks != null && user.Marks.Length > 0 select user.Marks.Count()).Sum();
            var sumUsers_1 = (from user in users where user.Marks != null && user.Marks.Length > 0  select user.Marks.Sum()).Sum();
            var avgUsers_1 = (from user in users where user.Marks != null && user.Marks.Length > 0 select user.Marks.Average()).Average();
            var countUsers_2 = users.Where(user => user.Marks != null && user.Marks.Length > 0).Select(user => user.Marks.Count()).Sum();
            var sumUsers_2 = users.Where(user => user.Marks != null && user.Marks.Length > 0).Select(user => user.Marks.Sum()).Sum();
            var avgUsers_2 = users.Where(user => user.Marks != null && user.Marks.Length > 0).Select(user => user.Marks.Average()).Average();
            Console.WriteLine("Ilosc Ocen: " + countUsers_2 + "\n " + "Suma Ocen: " + sumUsers_2 + "\n " + "Srednia Ocen: " + avgUsers_2);

            //8. --------- Najlepsza ocena ---------
            var bestMark_1 = (from user in users where user.Marks != null && user.Marks.Length > 0 orderby user.Marks.Max() descending select user.Marks.Max());
            var bestMark_2 = users.Where(user => user.Marks != null && user.Marks.Length > 0).OrderByDescending(user => user.Marks.Max()).Select(user => user.Marks.Max());
            //foreach (var mark in bestMark_2.Take(1))
            //{
            //    Console.WriteLine("Najlepsza ocena to: " + mark);
            //}

            //9. --------- Najgorsza ocena ---------
            var worstMark_1 = (from user in users where user.Marks != null && user.Marks.Length > 0 orderby user.Marks.Min() ascending select user.Marks.Min());
            var worstMark_2 = users.Where(user => user.Marks != null && user.Marks.Length > 0).OrderBy(user => user.Marks.Min()).Select(user => user.Marks.Min());
            //foreach (var mark in worstMark_2.Take(1))
            //{
            //    Console.WriteLine("Najgorsza ocena to: " + mark);
            //}

            //10. --------- Najlepszy Student ---------
            var bestStudent_1 = (from user in users where user.Marks != null && user.Marks.Length > 0 orderby user.Marks.Average() descending select user.Name);
            var bestStudent_2 = users.Where(user => user.Marks != null && user.Marks.Length > 0).OrderByDescending(user => user.Marks.Average()).Select(user => user.Name);
            //foreach (var student in bestStudent_2.Take(1))
            //{
            //    Console.WriteLine("Najlepszym studentem jest: " + student);
            //}

            //11. --------- Liste studentów którzy posiadają najmniej ocen ---------
            var leastMarks_1 = (from user in users where user.Marks != null && user.Marks.Length > 0 orderby user.Marks.Length ascending select user).ToList();
            var leastMarks_2 = users.Where(user => user.Marks != null && user.Marks.Length > 0).OrderBy(user => user.Marks.Length).Select(user => user);
            //Console.WriteLine("Najmniej ocen posiadają:");
            //foreach (var user in leastMarks_2)
            //{
            //    Console.WriteLine(user.Name);
            //}

            //12. --------- Liste studentów którzy posiadają najwięcej ocen ---------
            var mostMarks_1 = (from user in users  where user.Marks != null && user.Marks.Length > 0 orderby user.Marks.Length descending select user).ToList();
            var mostMarks_2 = users.Where(user => user.Marks != null && user.Marks.Length > 0).OrderByDescending(user => user.Marks.Length).Select(user => user);
            //Console.WriteLine("Najwięcej ocen posiadają:");
            //foreach (var user in mostMarks_2)
            //{
            //    Console.WriteLine(user.Name);
            //}

            //13. --------- Liste obiektów zawierających tylko nazwę i średnią ocenę(mapowanie na inny obiekt) ---------



            //14. --------- Studentów posortowanych od najlepszego ---------
            var bestStudentSortetList_1 = (from user in users where user.Marks != null && user.Marks.Length > 0 orderby user.Marks.Average() descending select user.Name);
            var bestStudentSortetList_2 = users.Where(user => user.Marks != null && user.Marks.Length > 0).OrderByDescending(user => user.Marks.Average()).Select(user => user.Name);
            //foreach (var user in bestStudentSortetList_2)
            //    Console.WriteLine(user);

            //15. --------- Średnią ocenę wszystkich studentów ---------
            var avgAllStudentMarks_1 = (from user in users where user.Marks != null && user.Marks.Length > 0 select user.Marks.Average()).Average();
            var avgAllStudentMarks_2 = users.Where(user => user.Marks != null && user.Marks.Length > 0).Select(user => user.Marks.Average()).Average();
            //Console.WriteLine("Średnia ocena wszystkich studentów to: " + avgAllStudentMarks_2);

            //16. --------- Lista użytkowników pogrupowanych po miesiącach daty utworzenia (np. 2022-02,2022-03,2022-04, itp.) ---------
            var userCreateDateSortedList_1 = (from user in users orderby user.CreatedAt group user by user.CreatedAt);
            var userCreateDateSortedList_2 = users.GroupBy(user => user.CreatedAt).OrderByDescending(user => user.Key);
            //foreach (var group in userCreateDateSortedList_2)
            //{
            //    Console.WriteLine(group.Key.ToString());
            //    foreach (var user in group)
            //    {
            //        Console.WriteLine(user.Name);
            //    }
            //}

            //17. --------- Lista użytkowników którzy nie zostali usunięci(data usunięcia nie została ustawiona) ---------
            var usersNoRemoved_1 = (from user in users where user.RemovedAt == null select user).ToList();
            var usersNoRemoved_2 = users.Where(user => user.RemovedAt == null).Select(user => user).ToList();
            //foreach (var user in usersNoRemoved_1)
            //    Console.WriteLine(user.Name);

            //18. --------- Najnowszego Studenta(najnowsza data uwtorzenia) ---------
            Console.WriteLine();
            var latestStudent_1 = (from user in users orderby user.CreatedAt descending select user).ToList();
            var latestStudent_2 = users.OrderByDescending(user => user.CreatedAt).Select(user => user).ToList();
            //foreach (var user in latestStudent_2.Take(1))
            //{
            //    Console.WriteLine("Najnowszy student to: " + user.Name);
            //}
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
