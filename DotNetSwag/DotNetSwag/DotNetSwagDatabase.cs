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
            ///
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = path + "joke.db";

            _database = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);

            _database.CreateTable<DotNetSwag>();
        }

        public List<DadJoke> GetJokes()
        {
            return _database.Table<Orders>().OrderByDescending(x => x.JokeDate).ToList();
        }

        public void SaveDotNetSwag(DadJoke joke)
        {
            _database.Insert(Orders);
        }
    }
}
