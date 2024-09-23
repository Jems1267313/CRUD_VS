using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiAppCrud.Services;

namespace MiAppCrud.Controllers
{
    public class OrdenController
    {
        private readonly OrdenService _ordenService;

        public OrdenController()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "productos.db3");
            _ordenService = new OrdenService(dbPath);
        }

        public Task<List<Orden>> GetAllOrdenes() => _ordenService.GetAll();
        public Task AddOrden(Orden orden) => _ordenService.Add(orden);
        public Task UpdateOrden(Orden orden) => _ordenService.Update(orden);
        public Task DeleteOrden(int id) => _ordenService.Delete(id);
    }

}
