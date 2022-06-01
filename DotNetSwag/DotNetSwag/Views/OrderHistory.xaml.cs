using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DotNetSwag
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderHistory : ContentPage
    {
        public OrderHistory()
        {
            InitializeComponent();
        }
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        DotNetSwagDatabase database = await DotNetSwagDatabase.Instance;
        listView.ItemsSource = await database.GetItemsAsync();
    }

    async void OnOrderAdded(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OrderPage
        {
            BindingContext = new OrderPage()
        });
    }

    async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new OrderPage
            {
                BindingContext = e.SelectedItem as OrderPage
            });
        }
    }
}

