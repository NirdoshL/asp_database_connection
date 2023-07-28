using Microsoft.EntityFrameworkCore;
using AspnetcoreCRUDApp.Models;
namespace AspnetcoreCRUDApp.Data{
    public class ApplicationDbContext: DbContext{
       public virtual DbSet<Student>? Students{get;set;}

       public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options){

        }

           protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
        }
    }
}