using MauiAppMinhasCompras.Helpers;
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
            Produto p_anexo = BindingContext as Produto;

            Produto p = new Produto
            {
                Id = p_anexo.Id,
                Descricao = txt_descricao.Text,
                Quantidade = double.Parse(txt_quantidade.Text),
                Preco = double.Parse(txt_preco.Text)
            };

            await ((App)Application.Current).Db.Update(p);
            await DisplayAlert("Sucesso!", "Registro atualizado", "OK");
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }

    }

}