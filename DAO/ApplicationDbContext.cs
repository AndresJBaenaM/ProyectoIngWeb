using ApiParchePlanU.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiParchePlanU.DAO
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        //Constructor que recibe las opciones de conexión a la bd para tener contexto de esta
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //listado de clases -> a tablas en la base de datos
        //Los DB Set nos ayudan a mapear las clases como Entidades
        //Es decir que Entity Framework lee este archivo para tomar del modelo el esquema de las tablas

        public DbSet<Parche> Parches { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<ParcheMember> ParcheMembers { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<PlanOption> PlanOptions { get; set; }

    }
}
