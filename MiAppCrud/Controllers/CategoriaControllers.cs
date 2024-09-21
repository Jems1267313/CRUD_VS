using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiAppCrud.Services;
using MiAppCrud.Models;

namespace MiAppCrud.Controllers
{
    public class CategoriaController
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");
            _categoriaService = new CategoriaService(dbPath);
        }

        public Task<List<Categoria>> GetAllCategorias() => _categoriaService.GetAll();
        public Task AddCategoria(Categoria categoria) => _categoriaService.Add(categoria);
        public Task UpdateCategoria(Categoria categoria) => _categoriaService.Update(categoria);
        public Task DeleteCategoria(int id) => _categoriaService.Delete(id);
    }

}
