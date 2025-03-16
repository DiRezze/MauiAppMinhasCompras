using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    public ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
    public ListaProduto()
	{
		InitializeComponent();
        Produtos.ItemsSource = lista;
    }

    protected override async void OnAppearing()
    {
        lista.Clear();

        List<Produto> tmp = await ((App)Application.Current).Db.GetAll();

        tmp.ForEach(i=>lista.Add(i));
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoProduto());

        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        string q = e.NewTextValue;

        lista.Clear();

        List<Produto> tmp = await ((App)Application.Current).Db.Search(q);

        tmp.ForEach(i => lista.Add(i));

    }

}
