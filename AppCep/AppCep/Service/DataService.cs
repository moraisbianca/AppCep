using AppCep.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

//https://cep.metoda.com.br/endereco/by-cep?cep=17206439

//https://cep.metoda.com.br/logradouro/by-bairro?id_cidade=4874&bairro=Jardim America

//https://cep.metoda.com.br/cep/by-logradouro?logradouro=

//https://cep.metoda.com.br/cidade/by-uf?uf=SP

//https://cep.metoda.com.br/bairro/by-cidade?id=4874


namespace AppCep.Service
{
    public class DataService
    {
        public static async Task<Endereco> GetEnderecoByCep(string CEP)
        {
            Endereco end;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://cep.metoda.com.br/endereco/by-cep?cep=");

                if(response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    end = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else
                    throw new Exception(response.RequestMessage.ToString());

                return end;
            }
        }

        public static async Task<List<Bairro>> GetBairrosByCidade(int id_cidade)
        {
            List<Bairro> arr_bairros = new List<Bairro>();

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://cep.metoda.com.br/bairro/by_cidade?id_cidade=");

                if(response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    arr_bairros = JsonConvert.DeserializeObject<List<Bairro>>(json);
                } 
                else
                    throw new Exception(response.RequestMessage.Content.ToString());

                return arr_bairros;
            }
        }
    }
}
