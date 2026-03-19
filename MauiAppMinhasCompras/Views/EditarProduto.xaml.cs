using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
    public EditarProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto produto_anexado = BindingContext as Produto;


            // Cria um novo objeto Produto com os dados digitados nos campos (Create do CRUD)
            Produto p = new Produto
            {
                Id = produto_anexado.Id,
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            await App.Db.Update(p);  
            await DisplayAlertAsync("Sucesso", "Registro Atualizado", "Ok"); // Exibe mensagem de sucesso
            await Navigation.PopAsync(); //Retorna a pagina principal
        }
        catch (Exception ex)
        {
            // Exibe mensagem de erro caso algo dê errado
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}

