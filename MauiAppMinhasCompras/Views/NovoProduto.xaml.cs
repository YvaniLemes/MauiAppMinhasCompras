using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
        // Inicializa a tela, conectando o XAML com esta classe (x:Class)
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Cria um novo objeto Produto com os dados digitados nos campos (Create do CRUD)
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            // Insere o produto no banco SQLite (Create)
            await App.Db.Insert(p);

            // Exibe mensagem de sucesso
            await DisplayAlertAsync("Sucesso", "Registro inserido", "Ok");
        }
        catch (Exception ex)
        {
            // Exibe mensagem de erro caso algo dê errado
            await DisplayAlertAsync("Ops", ex.Message, "Ok");
        }
    }
}

