using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    public ObservableCollection<Produto> Produtos { get; set; }
	public ListaProduto()
	{
		InitializeComponent();
        Produtos = new ObservableCollection<Produto>();
        BindingContext = this;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CarregarProdutos();
    }

    private async Task CarregarProdutos()
    {
        var db = ((App)Application.Current).Db;
        var lista = await db.GetAll();

        Produtos.Clear();
        foreach (var produto in lista)
        {
            Produtos.Add(produto);
        }
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