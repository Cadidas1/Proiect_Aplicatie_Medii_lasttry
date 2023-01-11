

using Proiect_Aplicatie_Medii_lasttry.Models;

namespace Proiect_Aplicatie_Medii_lasttry;

public partial class InchiriereEntryPage : ContentPage
{
    public InchiriereEntryPage()
    {
        InitializeComponent();

    }

    public int ID { get; internal set; }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetInchiriereAsync();
    }
    async void OnInchiriereAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InchirierePage
        {
            BindingContext = new Inchiriere()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new InchirierePage
            {
                BindingContext = e.SelectedItem as Inchiriere
            });
        }
    }

}
