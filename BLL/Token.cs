using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Token
    {

        public static async Task<DTO.Token_Out> retornaToken()
        {
            try
            {
                var retorno = new DTO.Token_Out();

                var client      = new RestClient("http://Itapua.unous.com.br/Auth/Token");
                var request     = new RestRequest();

                request.Method  = Method.Post;
                
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                var unous_credentials = DAL.Credentials.retornaCredenciais(Config_Sessao.config);

                request.AddParameter("grant_type",  unous_credentials.grant_type);
                request.AddParameter("username",    unous_credentials.username);
                request.AddParameter("password",    unous_credentials.password);
                request.AddParameter("client_id",   unous_credentials.client_id);

                var response = await client.ExecuteAsync(request);

                if (response.StatusDescription == "OK")
                {
                    retorno = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO.Token_Out>(response.Content);
                }

                return retorno;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
