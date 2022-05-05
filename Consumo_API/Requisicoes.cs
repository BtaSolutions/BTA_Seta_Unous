using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Consumo_API
{
    public class Requisicoes
    {
        public static async Task<DTO.Token_Out> requisitaToken(DTO.Token_In _In)
        {
            try
            {
                var token_Out = new DTO.Token_Out();

                var client = new HttpClient();

                Uri uri = new Uri("http://Itapua.unous.com.br/Auth/Token");

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(_In);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                
                response = await client.PostAsync(uri, content);

                Console.WriteLine("StatusCode --> " + response.StatusCode);

                Console.WriteLine("IsSuccessStatusCode --> " + response.IsSuccessStatusCode);

                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine("responseBody --> " + responseBody);

                return token_Out;


                //MessageBox.Show(Encoding.UTF8.GetString(wc.UploadValues("http://Itapua.unous.com.br/Auth/Token", values)));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
