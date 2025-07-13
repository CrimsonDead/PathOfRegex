using DBLayer;
using Microsoft.EntityFrameworkCore;
using PathOfRegexDB.Interfaces;
using PathOfRegexDB.Models;

namespace PathOfRegexDB.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly ApplicationContext context;

        public ItemRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public Task AddAsync(Item entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            context.Items.Add(entity);
            context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task DeleteAsync(Item entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            context.Items.Remove(entity);
            context.SaveChanges(); 
            
            return Task.CompletedTask;
        }

        public Task<IAsyncEnumerable<Item>> GetAllAsync()
        {
            return Task.FromResult(context.Items.AsAsyncEnumerable());
        }

        public Task<Item> GetAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            return context.Items.FirstAsync(i => i.Id == id);
        }

        public Task UpdateAsync(Item entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            context.Items.Update(entity);
            context.SaveChanges(); 
            
            return Task.CompletedTask;
        }
    }
}
