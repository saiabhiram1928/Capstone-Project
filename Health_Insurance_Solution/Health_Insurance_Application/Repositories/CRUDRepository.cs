using Health_Insurance_Application.Context;
using Health_Insurance_Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.Data.Common;

namespace Health_Insurance_Application.Repositories
{
    public abstract class CRUDRepository<K ,T> where T : class
    {
        protected HealthInsuranceContext _context;

        public CRUDRepository(HealthInsuranceContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item), "The item to add cannot be null.");

            try
            {
                await _context.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> Delete(K key)
        {
            var item = await GetById(key);
            if (item == null) throw new ArgumentNullException(nameof(key), "The item to delete was not found.");

            try
            {
                _context.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public async Task<T> Update(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item), "The item to update cannot be null.");

            try
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                throw; 
            }
        }

        public async Task<T> GetById(K key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), "The key cannot be null.");

            try
            {
                var entity = await _context.Set<T>().FindAsync(key);
                if (entity == null)
                {
                    throw new NoSuchItemInDbException($"No entity found with key {key}.");
                }
                return entity;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                throw;
            }
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            try 
            { 
                return await _context.Set<T>().ToListAsync(); 
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }

        }
    }
}
