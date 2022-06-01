using SQLite;
using System;
using System.Collections.Generic;


namespace DotNetSwag
{
    internal class DotNetSwagDatabase
    {
        private SQLiteConnection _database;

        public static DotNetSwagDatabase Instance = new DotNetSwagDatabase();

        public DotNetSwagDatabase()
        {
           
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = path + "Orders.db";

            _database = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);

            _database.CreateTable<OrderHistory>();
        }

        public List<OrderHistory> GetJokes()
        {
            return _database.Table<OrderHistory>().OrderByDescending(x => x.OrderDate).ToList();
        }

        public void SaveDotNetSwag(OrderHistory Order)
        {
            _database.Insert(Order);
        }
    }
}
