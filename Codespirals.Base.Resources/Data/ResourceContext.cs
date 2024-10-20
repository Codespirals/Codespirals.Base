using Microsoft.EntityFrameworkCore;

namespace Codespirals.Base.Data
{
    internal class ResourceContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public string DbName { get; }
        public string DbPath { get; }

        public ResourceContext() : this("resources")
        {

        }
        public ResourceContext(string dbName) : this(dbName, $"{Directory.GetCurrentDirectory()}\\Data")
        {

        }
        public ResourceContext(string dbName, string folder)
        {
            try
            {
                var dir = Directory.CreateDirectory(folder);
                DbName = dbName;
                DbPath = $"{dir.FullName}\\{dbName}.db";
            }
            catch (Exception)
            {
                throw;
            }
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($@"Data Source={DbPath};");
    }
}
