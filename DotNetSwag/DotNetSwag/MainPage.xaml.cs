using DotNetSwag.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DotNetSwag
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var order = new Orders();
            BindingContext = order;        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var order = (Orders)BindingContext;
            DotNetSwagDatabase database = await DotNetSwagDatabase.Instance;
            await database.SaveItemAsync(order);
            await Navigation.PushAsync( new OrderHistory());
        }

        private async void OnOrderClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderHistory());

        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {

            var order = (Orders)BindingContext;
            DotNetSwagDatabase database = await DotNetSwagDatabase.Instance;
            await database.DeleteItemAsync(order);
            await Navigation.PushAsync(new OrderHistory());
        }

    }
}

