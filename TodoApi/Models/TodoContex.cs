using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContex : DbContext
    {
        public TodoContex(DbContextOptions<TodoContex> options)
            :base(options)
        {

        }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
