using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AULA002_2
{
    public class ChamadaRestClient
    {
        public static async Task ChamadaGet()
        {
            var client = new RestClient("https://viacep.com.br/ws/13024200/json/");
            var request = new RestRequest();
            var response = await client.ExecuteAsync<ApiResponse>(request);

            if (response.IsSuccessful)
            {
                ApiResponse apiResponse = response.Data;
                Console.WriteLine($"Resposta do RestClient: Logradouro={apiResponse.Logradouro}, Bairro={apiResponse.Bairro}, Localidade={apiResponse.Localidade}");
            }
            else
            {
                Console.WriteLine("Falha ao pegar dados RestClient.");
            }
        }
    }
}
