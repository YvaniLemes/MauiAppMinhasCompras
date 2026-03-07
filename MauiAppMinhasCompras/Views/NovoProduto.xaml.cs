using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent(); // funciona porque o x:Class no XAML bate com esta classe
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            await App.Db.Insert(p);

            await DisplayAlertAsync("Sucesso", "Registro inserido", "Ok");
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "Ok");
        }
    }
}

