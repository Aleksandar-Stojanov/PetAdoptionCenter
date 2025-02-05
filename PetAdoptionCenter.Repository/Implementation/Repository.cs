using Microsoft.EntityFrameworkCore;
using PetAdoptionCenter.Domain.Domain_Models;
using PetAdoptionCenter.Repository.Interface;

namespace PetAdoptionCenter.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;
        //string errorMessage = string.Empty;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            if (typeof(T).IsAssignableFrom(typeof(Adoption)))
            {
                return entities
                    .Include("Center")
                    .Include("Pet")
                    .Include("User")
                    .AsEnumerable();

            }
            else if (typeof(T).IsAssignableFrom(typeof(Pet)))
            {
                return entities
                    .Include("Requests")
                    .Include("Requests.User")
                    .Include("Center")
                    .AsEnumerable();
            }
            else
            {
                return entities.AsEnumerable();
            }
        }

        public T Get(Guid? id)
        {
            if (typeof(T).IsAssignableFrom(typeof(Adoption)))
            {
                return entities
                    .Include("Center")
                    .Include("Pet")
                    .Include("User")
                    .First(s => s.Id == id);
            }
            else if (typeof(T).IsAssignableFrom(typeof(Pet)))
            {
                return entities
                    .Include("Requests")
                    .Include("Requests.User")
                    .Include("Center")
                    .First(s => s.Id == id);
            }
            else
            {
                return entities.First(s => s.Id == id);
            }

        }
        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
            return entity;
        }

        public List<T> InsertMany(List<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }
            entities.AddRange(entities);
            context.SaveChanges();
            return entities;
        }
    }
}
