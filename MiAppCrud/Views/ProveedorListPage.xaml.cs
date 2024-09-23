using MiAppCrud.Controllers;

namespace MiAppCrud.Views;

public partial class ProveedorListPage : ContentPage
{
    private ProveedorController _proveedorController;

    public ProveedorListPage()
    {
        InitializeComponent();
        _proveedorController = new ProveedorController();
        LoadProveedores();
    }

    private async void LoadProveedores()
    {
        var proveedores = await _proveedorController.GetAllProveedores();
        ProveedoresListView.ItemsSource = proveedores;
    }

    private async void OnAddProviderClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProveedorEditPage());
    }

    private async void OnProviderTapped(object sender, ItemTappedEventArgs e)
    {
        var proveedor = (Proveedor)e.Item;
        await Navigation.PushAsync(new ProveedorEditPage(proveedor));
    }
}
