using Microsoft.EntityFrameworkCore;

namespace ToDoListApp.Models
{
    public class ToDoDbContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
