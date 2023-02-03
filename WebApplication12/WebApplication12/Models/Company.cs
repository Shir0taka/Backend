using Microsoft.EntityFrameworkCore;

namespace WebApplication12.Models
{
    public class CompanyContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public string DbPath { get; }

        public CompanyContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "company.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Employees { get; set; }
    }
}
