using MiAppCrud.Controllers;
using MiAppCrud.Models;

namespace MiAppCrud.Views;

public partial class OrdenEditPage : ContentPage
{
    private Orden _orden;
    private OrdenController _ordenController;

    public OrdenEditPage(Orden orden = null)
    {
        InitializeComponent();
        _orden = orden ?? new Orden();
        _ordenController = new OrdenController();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadProductos();
    }

    private async Task LoadProductos()
    {
        var productoController = new ProductoController();
        var productos = await productoController.GetAllProductos();
        ProductoPicker.ItemsSource = productos;
    }


    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _orden.Fecha = DateTime.Now; 
        _orden.ProductoId = ((Producto)ProductoPicker.SelectedItem).Id;

        if (ProductoPicker.SelectedItem == null)
        {
            await DisplayAlert("Error", "Por favor, selecciona un producto.", "OK");
            return; // Detiene la ejecución si no hay un producto seleccionado
        }

        if (_orden.Id == 0)
            await _ordenController.AddOrden(_orden);
        else
            await _ordenController.UpdateOrden(_orden);

        await Navigation.PopAsync();
    }
}
