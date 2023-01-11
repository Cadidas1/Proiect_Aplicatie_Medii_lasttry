using Proiect_Aplicatie_Medii_lasttry.Models;

namespace Proiect_Aplicatie_Medii_lasttry;

public partial class MasiniPage : ContentPage
{
    InchiriereEntryPage sl;
	public MasiniPage(InchiriereEntryPage slist)
	{
		InitializeComponent();
        sl = slist;
    }

    public MasiniPage(Inchiriere bindingContext)
    {
        BindingContext = bindingContext;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var product = (Masina)BindingContext;
        await App.Database.SaveMasinaAsync(product);
        listView.ItemsSource = await App.Database.GetMasiniAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var product = (Masina)BindingContext;
        await App.Database.DeleteMasinaAsync(product);
        listView.ItemsSource = await App.Database.GetMasiniAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetMasiniAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Masina p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Masina;
            var lp = new ListaMasina()
            {
                InchiriereID = sl.ID,
                MasinaID = p.ID
            };
            await App.Database.SaveListaMasinaAsync(lp);
            p.ListaMasini = new List<ListaMasina> { lp };
            await Navigation.PopAsync();
        }

    }
    }