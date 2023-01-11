using Proiect_Aplicatie_Medii_lasttry.Models;

namespace Proiect_Aplicatie_Medii_lasttry;

public partial class InchirierePage : ContentPage
{
	public InchirierePage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Inchiriere)BindingContext;
        slist.Data = DateTime.UtcNow;
        await App.Database.SaveInchiriereAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Inchiriere)BindingContext;
        await App.Database.DeleteInchiriereAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MasiniPage((Inchiriere)
       this.BindingContext)
        {
            BindingContext = new Masina()
        });
    }
        protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (Inchiriere)BindingContext;

        listView.ItemsSource = await App.Database.GetListaMasiniAsync(shopl.ID);
    }

}
