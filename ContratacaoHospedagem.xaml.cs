using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel.Views
{
    public partial class ContratacaoHospedagem : ContentPage
    {
        public ContratacaoHospedagem()
        {
            InitializeComponent();
            
            // Configura a data mínima de check-in para o dia de hoje
            dtp_checkin.MinimumDate = DateTime.Now;
            dtp_checkout.MinimumDate = DateTime.Now.AddDays(1);

            // Vincula o evento do Stepper para atualizar o texto na tela
            stp_adultos.ValueChanged += (s, e) => {
                lbl_adultos.Text = $"{e.NewValue} Adulto(s)";
            };
        }

        private async void BtnCalcular_Clicked(object sender, EventArgs e)
        {
            if (pck_quarto.SelectedIndex == -1)
            {
                await DisplayAlert("Erro", "Por favor, selecione um tipo de acomodação.", "OK");
                return;
            }

            // Calcula o total de diárias
            DateTime checkin = dtp_checkin.Date;
            DateTime checkout = dtp_checkout.Date;

            if (checkout <= checkin)
            {
                await DisplayAlert("Aviso", "A data de check-out deve ser posterior à data de check-in.", "OK");
                return;
            }

            int diarias = (checkout - checkin).Days;
            double valorDiaria = 0;

            // Define o preço com base na seleção do Picker
            switch (pck_quarto.SelectedIndex)
            {
                case 0: valorDiaria = 350.00; break; // Luxo
                case 1: valorDiaria = 250.00; break; // Master
                case 2: valorDiaria = 150.00; break; // Standard
            }

            double valorTotal = diarias * valorDiaria * stp_adultos.Value;

            // Exibe o resultado customizado na tela
            await DisplayAlert("Resumo da Hospedagem", 
                $"Total de Diárias: {diarias}\n" +
                $"Valor por Diária: R$ {valorDiaria:F2}\n" +
                $"Valor Total Estimado: R$ {valorTotal:F2}", 
                "Confirmar");
        }

        /// <summary>
        /// Atende a diretriz da Agenda 14 de inserção de novas telas no fluxo do app.
        /// </summary>
        private async void BtnSobre_Clicked(object sender, EventArgs e)
        {
            // Executa a transição empilhando a tela Sobre na árvore de navegação
            await Navigation.PushAsync(new MauiAppHotel.Views.Sobre());
        }
    }
}
