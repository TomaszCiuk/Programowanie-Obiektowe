using System;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace Lab_7b
{
    class Program
    {
        static void Main(string[] args)  
        {
            //TODO: change DESKTOP-123ABC\SQLEXPRESS
            string connectionString = @"Data Source=PK1-21-T;Initial Catalog=corpo;Integrated Security=True";

            using (CorpoContext db = new CorpoContext(connectionString))
            {
                Console.WriteLine($"Database ConnectionString: {db.ConnectionString}.");

                // Create
                Console.WriteLine("Adding new Role");

                db.Add(new Role { Id = 1, Name = "Programista"});
                db.Add(new Role { Id = 2, Name = "Administrator" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Role List");

                Corpo corpo = db.Roles
                    .OrderBy(b => b.Id)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");

                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");

                db.Remove(blog);
                db.SaveChanges();
            }
        }
    }
}
