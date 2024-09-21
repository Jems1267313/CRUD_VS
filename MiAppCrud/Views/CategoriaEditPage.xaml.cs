using MiAppCrud.Controllers;
using MiAppCrud.Models;
using Microsoft.Maui.Controls;

namespace MiAppCrud.Views
{
    public partial class CategoriaEditPage : ContentPage
    {
        private Categoria _categoria;

        public CategoriaEditPage(Categoria categoria = null)
        {
            InitializeComponent();
            _categoria = categoria ?? new Categoria(); // Si no se pasa producto, creamos uno nuevo
            if (_categoria.Id != 0)
            {
                NombreEntry.Text = _categoria.Nombre;
                DescriptionEntry.Text = _categoria.Descripcion;

            }
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            // Guardamos el producto al hacer clic en "Guardar"
            _categoria.Nombre = NombreEntry.Text;
            _categoria.Descripcion = DescriptionEntry.Text;
            var controller = new CategoriaController();
            await controller.DeleteCategoria(_categoria.Id);
            await Navigation.PopAsync();

        }
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Guardamos el producto al hacer clic en "Guardar"
            _categoria.Nombre = NombreEntry.Text;
            _categoria.Descripcion = DescriptionEntry.Text;

            var controller = new CategoriaController();
            if (_categoria.Id == 0)
                controller.AddCategoria(_categoria);  // Crea un nuevo producto
            else
                controller.UpdateCategoria(_categoria);  // Actualiza el producto existente

            await Navigation.PopAsync();  // Vuelve a la lista de productos
        }
    }

}