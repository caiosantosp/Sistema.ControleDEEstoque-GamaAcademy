using ControleDeEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ControleDeEstoque.Pages
{
    public class IndexModel : PageModel
    {
        public List<Produto> Produtos { get; private set; }
        public List<Produto> MaisVenda { get; private set; }
        public List<Venda> MaisVendidos { get; private set; }
        public List<Venda> UltimasAtulizacoes { get; private set; }

        [BindProperty]
        public string Usuario { get; set; }

        public int Estoque { get; private set; }
        public int UltimaSaida { get; private set; }

        string baseUrl = "https://localhost:44338";
        public async Task OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("/api/Produto");
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    Produtos = JsonConvert.DeserializeObject<List<Produto>>(result);
                }

                await GetEstoque();
                await GetMaisVendido();
                await GetUltimaSaida();
                await GetUltimasAtulizacoes();
                await GetMaisVendidos();
            }
        }

        public async Task GetEstoque()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Produto/Quantidade-Estoque");
                if (response.IsSuccessStatusCode)
                {
                    string resultEstoque = response.Content.ReadAsStringAsync().Result;
                    Estoque = JsonConvert.DeserializeObject<int>(resultEstoque);
                }
            }
        }

        public async Task GetMaisVendido()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(

                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Venda/Melhor-Venda");

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    MaisVenda = JsonConvert.DeserializeObject<List<Produto>>(result);
                }
            }
        }

        public async Task GetUltimaSaida()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(

                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Venda/Ultima-Saida");
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    UltimaSaida = JsonConvert.DeserializeObject<int>(result);
                }
            }
        }

        public async Task GetUltimasAtulizacoes()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(

                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Venda");
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    UltimasAtulizacoes = JsonConvert.DeserializeObject<List<Venda>>(result);
                }
            }
        }
        public async Task GetMaisVendidos()
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(

                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Venda");
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    MaisVendidos = JsonConvert.DeserializeObject<List<Venda>>(result);
                }
            }
        }
    }
}

