using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace A2.sql
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Favourites>().Wait();
        }

        public Task<List<Favourites>> GetPeopleAsync()
        {
            return _database.Table<Favourites>().ToListAsync();
        }

        public Task<Favourites> GetPersonByName(string name)
        {
            return _database.Table<Favourites>().Where(i => i.summonerName == name).FirstOrDefaultAsync();
        }

        public Task<int> RemovePersonAsync(Favourites name)
        {
            return _database.DeleteAsync(name);
        }

        public Task<int> SavePersonAsync(Favourites person)
        {
            return _database.InsertAsync(person);
        }
    }
}
