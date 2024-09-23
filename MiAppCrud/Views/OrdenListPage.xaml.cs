using MiAppCrud.Models;
using MiAppCrud.Controllers;

namespace MiAppCrud.Views;

public partial class OrdenListPage : ContentPage
{
    private OrdenController _ordenController;

    public OrdenListPage()
    {
        InitializeComponent();
        _ordenController = new OrdenController();
        LoadOrdenes(); // Implementar este método
    }

    private async void LoadOrdenes()
    {
        var ordenes = await _ordenController.GetAllOrdenes();
        OrdenesListView.ItemsSource = ordenes;
    }

    private async void OnAddOrderClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OrdenEditPage());
    }

    private async void OnOrderTapped(object sender, ItemTappedEventArgs e)
    {
        var orden = (Orden)e.Item;
        await Navigation.PushAsync(new OrdenEditPage(orden));
    }
}
