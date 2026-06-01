namespace MauiAppHotel.Views;

public partial class Sobre : ContentPage
{
    public Sobre()
    {
        InitializeComponent();
    }

    private async void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        // Remove a tela atual da pilha de navegação, voltando para a anterior
        await Navigation.PopAsync();
    }
}
