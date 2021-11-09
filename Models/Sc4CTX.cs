namespace ProyectoSC4.Models
{
    using Microsoft.EntityFrameworkCore;
    public class Sc4CTX:DbContext
    {
        public Sc4CTX(DbContextOptions<Sc4CTX> options): base(options){
            

        }

        public DbSet<Admin> Admins {get; set;}
        public DbSet<Student> Students {get; set;}


    }
}