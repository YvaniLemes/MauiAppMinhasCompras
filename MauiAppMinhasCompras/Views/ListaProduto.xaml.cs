using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;
// Organiza o código. Aqui estamos na pasta Views (interface gráfica).



public partial class ListaProduto : ContentPage
// Classe da página ListaProduto. Herdando de ContentPage (página visual do MAUI).
{
    ObservableCollection<Produto> Lista = new ObservableCollection<Produto>(); // fonte de dados (Copilot Ag04 Fichario)


    public ListaProduto()
    {
        InitializeComponent();
        // Construtor: carrega o layout definido no arquivo ListaProduto.xaml.

        lst_produtos.ItemsSource = Lista;
    }

    protected async override void OnAppearing() // Metodo que que carrega os produtos do banco (Copilot Ag04 Fichario)
    {
        List<Produto> tmp = await App.Db.GetAll(); 
        tmp.ForEach(x => Lista.Add(x));
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

    private async  void txt_search_TextChanged(object sender, TextChangedEventArgs e) // Metodo que faz a busca dinamica
    {                                               // chamando App.Db.Search(q) e atualizando a coleção
                                                    // Copilot Ag 04 - Fichario
        string q = e.NewTextValue;

        Lista.Clear();

        List<Produto> tmp = await App.Db.Search(q);

        tmp.ForEach(x => Lista.Add(x));


    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        double soma = Lista.Sum(i => i.Total);

        string msg = $"O total é{soma:C}";

        DisplayAlert("Total dos produtos", msg, "Ok");
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
} // Isso já cobre o uso do Search com o TextChanged e a filtragem em tempo real. Copilot Ag 04 - Fichario.