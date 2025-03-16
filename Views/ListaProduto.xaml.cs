using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    public ObservableCollection<Produto> produtos = new ObservableCollection<Produto>();
    public ListaProduto()
	{
		InitializeComponent();
        Produtos.ItemsSource = produtos;
    }
    protected override async void OnAppearing()
    {
        List<Produto> tmp = await ((App)Application.Current).Db.GetAll();
        tmp.ForEach(i=>produtos.Add(i));

        base.OnAppearing();
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

}