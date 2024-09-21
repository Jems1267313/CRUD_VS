using Microsoft.Maui.Controls;
using MiAppCrud.Controllers;
using MiAppCrud.Models;

namespace MiAppCrud.Views
{
    public partial class ProductoListPage : ContentPage
    {
        private ProductoController _controller;

        public ProductoListPage()
        {
            InitializeComponent();
            _controller = new ProductoController();
            LoadProductos();
        }

        private async void LoadProductos()
        {
            ProductosListView.ItemsSource = await _controller.GetAllProductos();
        }

        private async void OnProductTapped(object sender, ItemTappedEventArgs e)
        {
            var producto = (Producto)e.Item;
            await Navigation.PushAsync(new ProductoEditPage(producto));
        }

        private async void OnAddProductClicked(object sender, EventArgs e)
        {
            // Redirige a la vista para agregar un nuevo producto
            await Navigation.PushAsync(new ProductoEditPage());
        }
    }
}
