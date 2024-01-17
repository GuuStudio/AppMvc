


using App.Models.Contacts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Models {
    public class AppDbContext : DbContext {
        
        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }

        protected override void OnModelCreating (ModelBuilder builder) {

            base.OnModelCreating (builder);
            // Bỏ tiền tố AspNet của các bảng: mặc định
            // foreach (var entityType in builder.Model.GetEntityTypes ()) {
            //     var tableName = entityType.GetTableName ();
            //     if (tableName != null ) {
            //         if (tableName.StartsWith ("AspNet")) {
            //             entityType.SetTableName (tableName.Substring(6));
            //         }
            //     }
            // }
        }

        public DbSet<Contact> Contacts {set;get;}
    }
}