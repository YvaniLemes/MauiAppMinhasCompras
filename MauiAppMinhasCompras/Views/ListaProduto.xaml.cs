namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    public ListaProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Navegação para a página NovoProduto
            await Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {
            // Exibindo mensagem de erro com método atualizado
            await DisplayAlertAsync("Ops", ex.Message, "Ok");
        }

    }
}