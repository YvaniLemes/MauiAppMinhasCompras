namespace MauiAppMinhasCompras.Views;
// Organiza o código. Aqui estamos na pasta Views (interface gráfica).




public partial class ListaProduto : ContentPage
// Classe da página ListaProduto. Herdando de ContentPage (página visual do MAUI).


{
    public ListaProduto()
    {
        InitializeComponent();
        // Construtor: carrega o layout definido no arquivo ListaProduto.xaml.
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Navegação para a página NovoProduto (Crud)
            await Navigation.PushAsync(new Views.NovoProduto());
        }
        catch (Exception ex)
        {
            // Exibindo mensagem de erro com método atualizado
            await DisplayAlertAsync("Ops", ex.Message, "Ok");
        }

    }
}