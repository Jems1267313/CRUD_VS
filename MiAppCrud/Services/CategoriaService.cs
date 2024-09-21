using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiAppCrud.Models;

namespace MiAppCrud.Services
{
    public class CategoriaService
    {
        private Database _database;

        public CategoriaService(string dbPath)
        {
            _database = new Database(dbPath);
        }

        public Task<List<Categoria>> GetAll() => _database.GetAllCategoriasAsync();
        public Task Add(Categoria categoria) => _database.SaveCategoriaAsync(categoria);
        public Task Update(Categoria categoria) => _database.SaveCategoriaAsync(categoria);
        public Task Delete(int id) => _database.DeleteCategoriaAsync(id);
    }

}
