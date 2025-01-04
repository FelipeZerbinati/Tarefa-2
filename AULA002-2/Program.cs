using System;
using System.Text.Json;
using AutoMapper;
using RestSharp;

namespace AULA002_2
{
    public class Program
    {
        #region Serialização
        public static string SerializeToJson()
        {
            var carro = new Carro()
            {
                Nome = "Honda",
                Modelo = "Civic",
                Ano = 2020
            };

            string jsonString = JsonSerializer.Serialize(carro);

            return jsonString;
        }
        #endregion

        #region Deserialização
        public static Carro DeserializeFromJson(string jsonString) 
        {
            Carro ? carro = JsonSerializer.Deserialize<Carro>(jsonString);
            Console.WriteLine($"Carro deserializado: Nome = {carro.Nome}, Modelo = {carro.Modelo}, Ano = {carro.Ano}");
            return carro;
        }
        #endregion

        #region DTO e AutoMapper
        static void InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Carro, CarroDto>();
            });
            IMapper mapper = config.CreateMapper();

            var carro = new Carro()
            {
                Nome = "Fiat",
                Modelo = "Uno",
                Ano = 2024

            };
            var map = mapper.Map<Carro, CarroDto>(carro);

            Console.WriteLine(map.Nome);
            Console.WriteLine(map.Modelo);
            Console.WriteLine(map.Ano);
        }
        #endregion

        #region Chamada RestClient

        

        #endregion

        #region DateTime
        public static void ExibirData()
        {
            DateTime agora = DateTime.Now;
            string agoraFormatado = agora.ToString("dd@yyyy@MM#HH#mm");
            Console.WriteLine(agoraFormatado);
            
        }

        public static void CalculosData()
        {
            DateTime momento = DateTime.Now;
            DateTime futuro = momento.AddDays(45);
            double subtracaoDasDatas = (futuro - momento).TotalSeconds;
            Console.WriteLine($"Diferença em Segundos: {subtracaoDasDatas}");
        }

        #endregion

        public static async Task Main(string[] args) 
        {
            Console.WriteLine("Serialização: ");
            Console.WriteLine(SerializeToJson());
            Console.WriteLine("Deserialização: ");
            DeserializeFromJson(SerializeToJson());
            Console.WriteLine("DTO e AutoMapper: ");
            InitializeAutomapper();
            Console.WriteLine("Chamada Rest HttpClient");
            await ChamadaHttpClient.ChamadaGet();
            Console.WriteLine("Chamada RestClient");
            await ChamadaRestClient.ChamadaGet();
            Console.WriteLine("Conversão de data:");
            ExibirData();
            Console.WriteLine("Cálculos data:");
            CalculosData();
        }
    }
}
