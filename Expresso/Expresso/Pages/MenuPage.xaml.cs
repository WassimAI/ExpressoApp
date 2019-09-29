using Expresso.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu = Expresso.Models.Menu;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expresso.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public ObservableCollection<Menu> Menus;
        public static bool first = true;
        public MenuPage()
        {
            InitializeComponent();
            Menus = new ObservableCollection<Menu>();
        }

        //Usually this works as a construction but we are using it here to use the async and await
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (first)
            {
                ApiServices apiServices = new ApiServices();
                var menus = await apiServices.GetMenu();
                foreach (var menu in menus)
                {
                    Menus.Add(menu);
                }

                LvMenu.ItemsSource = Menus;
            }

            first = false;
        }

        private void LvMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //To store the selected item as an instance of menu class
            var selectedMenu = e.SelectedItem as Menu;
            Navigation.PushAsync(new SubMenuPage(selectedMenu));
        }
    }
}