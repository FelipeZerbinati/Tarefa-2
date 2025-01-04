using RestSharp;
using System.Text.Json;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace AULA002_2
{
    public class ChamadaHttpClient
    {
        public static async Task ChamadaGet()
        {
            var url = "https://viacep.com.br/ws/13024200/json/";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var jsonDeserialized = JsonSerializer.Deserialize<ApiResponse>(result);

                if (jsonDeserialized != null)
                {
                    Console.WriteLine($"Logradouro = {jsonDeserialized.Logradouro}, Bairro = {jsonDeserialized.Bairro}, Localidade = {jsonDeserialized.Localidade}");
                }
                else
                {
                    Console.WriteLine("Falha em recuperar dados da API.");
                }
            }

        }
    }
}
