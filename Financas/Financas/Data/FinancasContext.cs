using Microsoft.EntityFrameworkCore;
using Financas.Models;

namespace Financas.Data
{
    public class FinancasContext : DbContext
    {
        public FinancasContext(DbContextOptions<FinancasContext> options) : base(options)
        {
        }

        public DbSet<Group> Group { get; set; }
        public DbSet<SubGroup> SubGroup { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}