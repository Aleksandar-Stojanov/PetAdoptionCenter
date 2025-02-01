using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetAdoptionCenter.Domain.Domain_Models;

namespace PetAdoptionCenter.Repository
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<AdoptionCenter> AdoptionCenters{ get; set; }
        public virtual DbSet<Adoption> Adoptions { get; set; }
    }
}
