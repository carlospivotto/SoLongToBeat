using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SoLongToBeat.MVC.ApiClientHelper
{
    public class ApiClient
    {
        public HttpClient Client { get; set; }
        public ApiClient()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://solongtobeatapi20201109085031.azurewebsites.net");
        }
    }
}
