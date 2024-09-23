using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Orden
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public DateTime Fecha { get; set; }

    // Relación con Producto
    public int ProductoId { get; set; }
}
