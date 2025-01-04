using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AULA002_2
{
    public class ApiResponse
    {
        [JsonPropertyName("logradouro")]
        public string ? Logradouro { get; set; }

        [JsonPropertyName("bairro")]
        public string ? Bairro { get; set; }

        [JsonPropertyName("localidade")]
        public string ? Localidade { get; set; }
    }
}
