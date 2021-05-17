using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using SQLite;

namespace LocalDatabase
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Persona>().Wait();
            _database.CreateTableAsync<Bodega>().Wait();
            _database.CreateTableAsync<Categoria>().Wait();
            _database.CreateTableAsync<Perfil>().Wait();
            _database.CreateTableAsync<Producto>().Wait();
        }

        public Task<Persona> GetItemAsync(int id)
        {
            return _database.Table<Persona>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<List<Persona>> UpdateAsyncPersona(int est, int id)
        {
            // SQL queries are also possible
            //return _database.QueryAsync<Persona>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
            return _database.QueryAsync<Persona>("Update Persona set Estado = ? where ID =?",est,id);
        }

        public Task<List<Persona>> GetPeopleAsync()
        {
            return _database.Table<Persona>().ToListAsync();
        }

        public Task<List<Persona>> GetPersona(int Id)
        {
            var query = from cust in _database.Table<Persona>()
                        where cust.ID == Id
                        select cust;
            return query.ToListAsync();
            //return _database.Table<Persona>().ToListAsync();
        }
        public Task<List<Bodega>> GetBodegaAsync()
        {
            return _database.Table<Bodega>().ToListAsync();
        }
        public Task<List<Categoria>> GetCategoriaAsync()
        {
            return _database.Table<Categoria>().ToListAsync();
        }
        public Task<List<Perfil>> GetPerfilAsync()
        {
            return _database.Table<Perfil>().ToListAsync();
        }
        public Task<List<Producto>> GetProductoAsync()
        {
            return _database.Table<Producto>().ToListAsync();
        }
        public Task<int> SavePersonAsync(Persona person)
        {
            return _database.InsertAsync(person);
        }
        public Task<int> UpdatePersonaAsync(Persona person)
        {
            return _database.UpdateAsync(person);        
        }
    }
}
