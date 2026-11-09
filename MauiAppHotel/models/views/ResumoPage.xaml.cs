namespace MauiAppHotel.Views;

public partial class ResumoPage : ContentPage
{
    public ResumoPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
