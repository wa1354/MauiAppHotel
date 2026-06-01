using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel.Views
{
    public partial class Sobre : ContentPage
    {
        public Sobre()
        {
            InitializeComponent();
        }

        private async void BtnVoltar_Clicked(object sender, EventArgs e)
        {
            // Comando que remove esta tela e volta para a tela anterior
            await Navigation.PopAsync();
        }
    }
}
