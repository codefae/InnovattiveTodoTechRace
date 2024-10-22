using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;

namespace InnovativeToDo.Avalonia.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private const string DbName = "MyToDoData.db";
    
        private SQLiteAsyncConnection _database;

        public Repository()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), DbName);
            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<T>().Wait();
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _database.Table<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _database.FindAsync<T>(id);
        }

        public async Task AddAsync(T entity)
        {
            await _database.InsertAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _database.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _database.FindAsync<T>(id);
            if (entity != null)
            {
                await _database.DeleteAsync(entity);
            }
            else
            {
                throw new Exception("Entity not found");
            }
        }
        public async Task DeleteTableAsync()
        {
            await _database.DropTableAsync<T>();
        }
    }
}