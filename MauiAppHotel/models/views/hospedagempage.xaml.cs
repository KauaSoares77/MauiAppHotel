using System;
using System.Collections.Generic;
using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class HospedagemPage : ContentPage
{
    private readonly List<Quarto> quartos = new()
    {
        new Quarto { Descricao = "Standard", ValorDiaria = 180.00 },
        new Quarto { Descricao = "Superior", ValorDiaria = 260.00 },
        new Quarto { Descricao = "Suíte Master", ValorDiaria = 420.00 }
    };

    public HospedagemPage()
    {
        InitializeComponent();

        pck_quarto.ItemsSource = quartos;

        dtpck_checkin.MinimumDate = DateTime.Today;
        dtpck_checkin.MaximumDate = DateTime.Today.AddYears(1);

        dtpck_checkout.MinimumDate = DateTime.Today.AddDays(1);
        dtpck_checkout.MaximumDate = DateTime.Today.AddYears(1).AddDays(30);
        dtpck_checkout.Date = DateTime.Today.AddDays(1);
    }

    private void dtpck_checkin_DateSelected(object? sender, DateChangedEventArgs e)
    {
        DateTime checkin = e.NewDate ?? DateTime.Today;

        dtpck_checkout.MinimumDate = checkin.AddDays(1);

        if ((dtpck_checkout.Date ?? DateTime.Today) < checkin.AddDays(1))
            dtpck_checkout.Date = checkin.AddDays(1);
    }

    private void stp_adultos_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        lbl_adultos.Text = e.NewValue.ToString("0");
    }

    private void stp_criancas_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        lbl_criancas.Text = e.NewValue.ToString("0");
    }

    private async void Button_Clicked(object? sender, EventArgs e)
    {
        try
        {
            if (pck_quarto.SelectedItem is not Quarto quarto)
            {
                await DisplayAlertAsync("Atenção", "Selecione o tipo de quarto.", "OK");
                return;
            }

            DateTime dataCheckIn = dtpck_checkin.Date ?? DateTime.Today;
            DateTime dataCheckOut = dtpck_checkout.Date ?? DateTime.Today.AddDays(1);

            if (dataCheckOut.Date <= dataCheckIn.Date)
            {
                await DisplayAlertAsync(
                    "Datas inválidas",
                    "O check-out deve ser depois do check-in.",
                    "OK");

                return;
            }

            Hospedagem hospedagem = new()
            {
                QuartoSelecionado = quarto,
                QtdAdultos = Convert.ToInt32(stp_adultos.Value),
                QtdCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = dataCheckIn,
                DataCheckOut = dataCheckOut
            };

            await Navigation.PushAsync(new ResumoPage
            {
                BindingContext = hospedagem
            });
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }
}