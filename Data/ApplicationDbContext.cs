using Microsoft.EntityFrameworkCore;
using messages_crud.Models.Entities;

namespace messages_crud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Message> Messages { get; set; }
    }
}
