namespace MauiAppHotel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.ContratacaoHospedagem());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 600;

            return window;
        }
    }
}
private async void BtnSobre_Clicked(object sender, EventArgs e)
{
    // Empilha a nova tela na NavigationPage configurada no seu App.xaml.cs
    await Navigation.PushAsync(new Views.Sobre());
}
