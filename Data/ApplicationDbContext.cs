using FormulaOneApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FormulaOneApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Team>? Teams { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
        }
    }
}