using DBLayer;
using Microsoft.EntityFrameworkCore;
using PathOfRegexDB.Interfaces;
using PathOfRegexDB.Models;

namespace PathOfRegexDB.Repositories
{
    public class AffixRepository : IRepository<Affix>
    {
        private readonly ApplicationContext _context;

        public AffixRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task AddAsync(Affix entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _context.Affixes.Add(entity);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task DeleteAsync(Affix entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _context.Affixes.Remove(entity);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task<IAsyncEnumerable<Affix>> GetAllAsync()
        {
            return Task.FromResult(_context.Affixes.AsAsyncEnumerable());
        }

        public Task<Affix> GetAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            return _context.Affixes.FirstAsync(a => a.Id == id);
        }

        public Task UpdateAsync(Affix entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _context.Affixes.Update(entity);
            _context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
