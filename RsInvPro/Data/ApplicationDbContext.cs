using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using RsInvPro.Data.Entities;
using Xamarin.Forms;

namespace RsInvPro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Inventory> Inntory { get; set; }
        public DbSet<InventoryColumn> InventoryColumn { get; set; }
        public DbSet<InventoryEbay> InventoryEbay { get; set; }
        public DbSet<InventoryPoshmark> InventoryPoshmark { get; set; }
        public DbSet<InventoryItem> InventoryItem { get; set; }
        public DbSet<InventorySold> InventorySold { get; set; }
        

        private const string DatabaseName = "rsinvpro.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String databasePath;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..",
                        "Library", DatabaseName);
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                        DatabaseName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }

            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
    }
}