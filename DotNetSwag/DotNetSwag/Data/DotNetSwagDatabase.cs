using DotNetSwag.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetSwag
{
    public class DotNetSwagDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<DotNetSwagDatabase> Instance = new AsyncLazy<DotNetSwagDatabase>(async () =>
        {
            var instance = new DotNetSwagDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Orders>();
            return instance;
        });

        public DotNetSwagDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<Orders>> GetItemsAsync()
        {
            return Database.Table<Orders>().ToListAsync();
        }

        public Task<List<Orders>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<Orders>("SELECT * FROM [Orders] WHERE [Done] = 0");
        }

        public Task<Orders> GetItemAsync(int id)
        {
            return Database.Table<Orders>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Orders item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Orders item)
        {
            return Database.DeleteAsync(item);
        }
    }
}