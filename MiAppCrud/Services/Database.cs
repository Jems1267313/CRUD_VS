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
            _database.CreateTableAsync<Proveedor>().Wait();  // Nueva tabla de proveedores
            _database.CreateTableAsync<Orden>().Wait();      // Nueva tabla de órdenes

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

        // Métodos para proveedores
        public Task<List<Proveedor>> GetAllProveedoresAsync() => _database.Table<Proveedor>().ToListAsync();
        public Task<int> SaveProveedorAsync(Proveedor proveedor) => proveedor.Id != 0 ? _database.UpdateAsync(proveedor) : _database.InsertAsync(proveedor);
        public Task<int> DeleteProveedorAsync(int id) => _database.DeleteAsync<Proveedor>(id);

        // Métodos para órdenes
        public Task<List<Orden>> GetAllOrdenesAsync() => _database.Table<Orden>().ToListAsync();
        public Task<int> SaveOrdenAsync(Orden orden) => orden.Id != 0 ? _database.UpdateAsync(orden) : _database.InsertAsync(orden);
        public Task<int> DeleteOrdenAsync(int id) => _database.DeleteAsync<Orden>(id);

    }

}
