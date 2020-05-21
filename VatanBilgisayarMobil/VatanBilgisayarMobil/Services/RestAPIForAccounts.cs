using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VatanBilgisayarMobil.Models;

namespace VatanBilgisayarMobil.Services
{
    public class RestAPIForAccounts
    {
        public async Task<bool> Register(string email, string password, string name, string lastName, string userName)
        {
            var model = new User()
            {
                Email = email,
                Password = password,
                Name = name,
                LastName = lastName,
                UserName = userName
            };
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(model);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
            var response = await client.PostAsync("https://vatanrestapi.azurewebsites.net/api/users", content);
            return response.IsSuccessStatusCode;
        }
        public async Task LoginAsync(string email, string password)
        {
            var userInfos = new LoginModel() { Email = email, Password = password };
            var jsonObj = JsonConvert.SerializeObject(userInfos);
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(jsonObj.ToString(), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://vatanrestapi.azurewebsites.net/api/login"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                //you can add headers                
                //request.Headers.Add("key", "value");
                var response = await client.SendAsync(request);
                string dataResult = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine(dataResult);
            }

        }

    }
}
