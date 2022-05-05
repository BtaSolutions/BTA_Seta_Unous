using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Locations
    {
        public static async Task<DTO.Response_API> enviarLocations(string token, List<DTO.Location_In> locations)
        {
            try
            {
                var retorno = new DTO.Response_API();

                // Create a request using a URL that can receive a post.
                WebRequest request = WebRequest.Create("http://Itapua.unous.com.br/StageContent/api/Location/Post");

                // Set the Method property of the request to POST.
                request.Method = "POST";
                request.Timeout = 100000;

                string postData 
                    = 
                    JsonConvert.SerializeObject
                    (
                        locations, 
                        Formatting.None, 
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore
                         }
                    );

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

                retorno.statusCode = ((HttpWebResponse)response).StatusCode.ToString();
                retorno.statusDescription = ((HttpWebResponse)response).StatusDescription;
                retorno.contentType = response.ContentType;
                retorno.responseUri = response.ResponseUri.ToString();
                retorno.responseFromServer = responseFromServer;

                // Close the response.
                response.Close();

                return retorno;
            }
            catch (WebException ex)
            {
                string responseFromServer = "";

                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    responseFromServer = reader.ReadToEnd();

                    Console.WriteLine("WebException ---> " + responseFromServer);
                    Console.WriteLine("WebException ---> " + ex.ToString());
                }

                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
