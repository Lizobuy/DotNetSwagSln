using DotNetSwag.Models;
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
    public partial class OrderPage : ContentPage
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var Order = (Orders)BindingContext;
            DotNetSwagDatabase database = await DotNetSwagDatabase.Instance;
            await database.SaveItemAsync(Order);
            await Navigation.PopAsync();
        }
    }
}