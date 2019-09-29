using Expresso.Models;
using Expresso.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Expresso.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        public ReservationPage()
        {
            InitializeComponent();
        }

        private async void BtnBookTable_Clicked(object sender, EventArgs e)
        {
            var apiServices = new ApiServices();
            Reservation reservation = new Reservation()
            {
                Name = entName.Text,
                Email = entEmail.Text,
                TotalPeople = entTotalPeople.Text,
                Phone = entPhone.Text,
                date = dbBookingDate.Date.ToString(),
                Time = tpBookingTime.Time.ToString()
            };

            bool response = await apiServices.ReserveTable(reservation);
            if (!response)
            {
                await DisplayAlert("Oops", "Something went wrong", "mmm OK");
            }
            else
            {
                await DisplayAlert("Yes!", "Your table has been reserved successfully", "Alright");
            }
        }
    }
}