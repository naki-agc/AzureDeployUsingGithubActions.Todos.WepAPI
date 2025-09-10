using Microsoft.EntityFrameworkCore;
using Todos.WepAPI.Todo;

namespace Todos.WepAPI.Context
{
    public sealed class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ToDo> Todos { get; set; }

    }
}

