using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Products
    {
        public static async Task<DTO.Response_API> enviarProducts(string token, List<DTO.Product> products)
        {
            try
            {
                var retorno = new DTO.Response_API();

                // Create a request using a URL that can receive a post.
                WebRequest request = WebRequest.Create("http://Itapua.unous.com.br/StageContent/api/Product/Post/");

                // Set the Method property of the request to POST.
                request.Method = "POST";
                request.Timeout = 300000;

                string postData = JsonConvert.SerializeObject(products);
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/json";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;

                request.Headers.Add("Authorization", "bearer " + token);

                // Get the request stream.
                Stream dataStream = await request.GetRequestStreamAsync();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();

                // Get the response.
                WebResponse response = await request.GetResponseAsync();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                Console.WriteLine(((HttpWebResponse)response).StatusCode);

                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.

                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseFromServer = reader.ReadToEnd();

                retorno.statusCode          = ((HttpWebResponse)response).StatusCode.ToString();
                retorno.statusDescription   = ((HttpWebResponse)response).StatusDescription;
                retorno.contentType         = response.ContentType;
                retorno.responseUri         = response.ResponseUri.ToString();
                retorno.responseFromServer  = responseFromServer;

                // Close the response.
                response.Close();

                return retorno;
            }
            catch (WebException ex)
            {
                string sEx = "";

                //string responseFromServer = "";

                sEx += "Message : " + ex.Message + Environment.NewLine;
                sEx += "Status : " + ex.Status.ToString() + Environment.NewLine;

                //using (var stream = ex.Response.GetResponseStream())
                //using (var reader = new StreamReader(stream))
                //{
                //    responseFromServer = reader.ReadToEnd();
                //
                //    Console.WriteLine("WebException ---> " + responseFromServer);
                //    Console.WriteLine("WebException ---> " + ex.ToString());
                //}

                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
