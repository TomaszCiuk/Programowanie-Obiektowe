using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Lab_7b
{
    public class CorpoContext : DbContext
    {
        public DbSet<Post> Users { get; set; }
        public DbSet<Blog> Roles { get; set; }
        public DbSet<Post> Tasks { get; set; }

        public string ConnectionString { get; }

        public CorpoContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(this.ConnectionString);
        }
    }
    public class Corpo
    {
        public long Id { get; set; }
        public string Url { get; set; }

        public List<User> Users { get; } = new();
        public List<Role> Roles { get; } = new();
        public List<Task> Tasks { get; } = new();
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Task
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
