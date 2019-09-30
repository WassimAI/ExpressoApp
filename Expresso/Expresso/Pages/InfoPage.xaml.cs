using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expresso.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        private void TapFacebook_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.facebook.com/instaclassme"));
        }

        private void TabInstagram_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.instagram.com/instaclassme"));
        }

        private void TapTwitter_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.twitter.com/instaclassme"));
        }

        private void TapYoutube_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.youtube.com/channel/UCmb7mFxNtEeIPWaej2ZNy9g"));
        }

        private void TapCall_Tapped(object sender, EventArgs e)
        {
            PhoneDialer.Open("00971501417553");
        }
    }
}