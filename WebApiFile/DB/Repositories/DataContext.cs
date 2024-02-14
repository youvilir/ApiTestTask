using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ApiEntity = WebApiFile.DB.Entities.ApiEntity;

namespace WebApiFile.DB.Repositories
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated(); // создание бд
        }

        public DbSet<ApiEntity> Api { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        internal void DetectChanges()
        {
            ChangeTracker.DetectChanges();
        }

    }

}


