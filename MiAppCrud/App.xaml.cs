using MiAppCrud.Views;


namespace MiAppCrud
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }

}
