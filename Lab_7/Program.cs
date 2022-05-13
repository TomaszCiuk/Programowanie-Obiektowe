using System;
using System.Data.Linq;
using System.Linq;

namespace Lab_7
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = @"Data Source=PK1-21-T;Initial Catalog=projectdb;Integrated Security=True;";

            using (DataContext dataContext = new DataContext(connectionString))
            {
                Table<UserEntity> users = dataContext.GetTable<UserEntity>();

                IQueryable<UserEntity> query = from user in users
                                               where user.RemovedAt.HasValue == false // user.RemovedAt == null
                                               select user;

                foreach (UserEntity user in query)
                    Console.WriteLine("{0} {1}", user.Id, user.Name);
            }
        }
    }
}
