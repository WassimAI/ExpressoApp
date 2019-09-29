using Expresso.Models;
using Expresso.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Menu = Expresso.Models.Menu;

namespace Expresso.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubMenuPage : ContentPage
    {
        public ObservableCollection<SubMenu> subMenus;
        public SubMenuPage(Menu menu)
        {
            InitializeComponent();
            subMenus = new ObservableCollection<SubMenu>();
            //Getting all submenus from that specific menu
            foreach (var submenu in menu.SubMenus)
            {
                subMenus.Add(submenu);
            }

            LvSubMenu.ItemsSource = subMenus;
        }
    }
}