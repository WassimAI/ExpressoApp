using Expresso.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Expresso.Services
{
    public class ApiServices
    {
        /*
         json to Csharp = deserialize
         Csharp to json = Serialize
             */
        public async Task<List<Menu>> GetMenu()
        {
            var client = new HttpClient();
            //The json date will come from getstringasync method and get stored in response variable
            var response = await client.GetStringAsync("http://wassimexpressoapi.azurewebsites.net/api/menus");
            //We have to deserialize the json object to be used in xamarin forms
            //This will also map the menu to the data in json
            return JsonConvert.DeserializeObject<List<Menu>>(response);
        }

        public async Task<bool> ReserveTable(Reservation reservation)
        {
            var client = new HttpClient();
            var jsonResponse = JsonConvert.SerializeObject(reservation);
            var content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");

            //Now we post the request along with the content
            var response = await client.PostAsync("http://wassimexpressoapi.azurewebsites.net/api/reservations", content);

            return response.IsSuccessStatusCode;
        }
    }
}
