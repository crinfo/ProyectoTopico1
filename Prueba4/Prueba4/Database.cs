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

        public Task<List<Persona>> UpdateAsyncPersona(int est, int id)
        {
            // SQL queries are also possible
            //return _database.QueryAsync<Persona>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
            return _database.QueryAsync<Persona>("Update Persona set Estado = ? where ID =?",est,id);
        }
        public Task<List<Categoria>> leerCategoria()
        {
            // SQL queries are also possible
            return _database.QueryAsync<Categoria>("select distinct nombre from Categoria");
        }
        public Task<List<Persona>> leeUsuario(string usr, string pass)
        {
            // SQL queries are also possible
            return _database.QueryAsync<Persona>("select * from Persona where Nombre = ? and Pass =?", usr, pass);
        }

        public Task<List<Producto>> leerProducto()
        {
            // SQL queries are also possible
            return _database.QueryAsync<Producto>("select * from Producto");
        }
        public Task<List<Producto>> leerProductoCant(string prd)
        {
            // SQL queries are also possible
            return _database.QueryAsync<Producto>("select * from Producto where Nombre = ?",prd);
        }

        public Task<List<Producto>> leerProductoModInv(string prod, string cat)
        {
            // SQL queries are also possible
            return _database.QueryAsync<Producto>("select * from Producto where Nombre = ? and Categoria = ?",prod, cat);
        }
        public Task<List<Producto>> UpdateCantProd(string cat, string prod, int tot)
        {
            // SQL queries are also possible
            //return _database.QueryAsync<Persona>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
            return _database.QueryAsync<Producto>("Update Producto set Cantidad = ? where Nombre =? and Categoria = ?", tot, prod, cat);
        }

        public Task<List<Persona>> GetPeopleAsync()
        {
            return _database.Table<Persona>().ToListAsync();
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
        public Task<int> SaveBodegaAsync(Bodega bodega)
        {
            return _database.InsertAsync(bodega);
        }
        public Task<int> SaveCategoriaAsync(Categoria categoria)
        {
            return _database.InsertAsync(categoria);
        }
        public Task<int> SaveProductoAsync(Producto producto)
        {
            return _database.InsertAsync(producto);
        }
        public Task<int> UpdatePersonaAsync(Persona person)
        {
            return _database.UpdateAsync(person);        
        }
    }
}
