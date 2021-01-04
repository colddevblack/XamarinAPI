using System;
using System.Collections.Generic;
using System.Text;
using Cadastroweb.Models;
using App99mobileAPI.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Cadastroweb;
using Newtonsoft.Json;

namespace App99mobileAPI.API
{
    public static class APIService
    {
        public const string rooturl = "https://localhost:44332/";
        public static async Task<List<LoginModel>> ObterLogin()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = rooturl + "api/LoginAPI";
                string response = await client.GetStringAsync(url);
                List<LoginModel> login = JsonConvert.DeserializeObject<List<LoginModel>>(response);
                return login;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
