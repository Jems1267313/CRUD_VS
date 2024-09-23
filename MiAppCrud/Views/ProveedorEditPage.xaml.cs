using MiAppCrud.Controllers;
using MiAppCrud.Models;

namespace MiAppCrud.Views;

public partial class ProveedorEditPage : ContentPage
{
    private Proveedor _proveedor;
    private ProveedorController _proveedorController;

    public ProveedorEditPage(Proveedor proveedor = null)
    {
        InitializeComponent();
        _proveedor = proveedor ?? new Proveedor();
        _proveedorController = new ProveedorController();

        if (_proveedor.Id != 0)
        {
            NombreEntry.Text = _proveedor.Nombre;
            TelefonoEntry.Text = _proveedor.Telefono;
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _proveedor.Nombre = NombreEntry.Text;
        _proveedor.Telefono = TelefonoEntry.Text;

        if (_proveedor.Id == 0)
            await _proveedorController.AddProveedor(_proveedor);
        else
            await _proveedorController.UpdateProveedor(_proveedor);

        await Navigation.PopAsync();
    }
}
