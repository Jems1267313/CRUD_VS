using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using MiAppCrud.Models;

namespace MiAppCrud.Services
{

    public class Database
    {
        private SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Producto>().Wait();
            _database.CreateTableAsync<Categoria>().Wait();
        }

        // Métodos para productos
        public Task<List<Producto>> GetAllProductosAsync() => _database.Table<Producto>().ToListAsync();
        public Task<Producto> GetProductoAsync(int id) => _database.Table<Producto>().FirstOrDefaultAsync(p => p.Id == id);
        public Task<int> SaveProductoAsync(Producto producto) => producto.Id != 0 ? _database.UpdateAsync(producto) : _database.InsertAsync(producto);
        public Task<int> DeleteProductoAsync(int id) => _database.DeleteAsync<Producto>(id);

        // Métodos para categorías
        public Task<List<Categoria>> GetAllCategoriasAsync() => _database.Table<Categoria>().ToListAsync();
        public Task<int> SaveCategoriaAsync(Categoria categoria) => categoria.Id != 0 ? _database.UpdateAsync(categoria) : _database.InsertAsync(categoria);
        public Task<int> DeleteCategoriaAsync(int id) => _database.DeleteAsync<Categoria>(id);
    }

}
