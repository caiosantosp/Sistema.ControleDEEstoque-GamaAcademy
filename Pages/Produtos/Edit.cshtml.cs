using ControleDeEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ControleDeEstoque.Pages.Produtos
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Produto Produto { get; set; }
        string baseUrl = "https://localhost:44338";
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/ErroID/ErroID");
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Produto/" + id);

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    Produto = JsonConvert.DeserializeObject<Produto>(result);
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            using (var client = new HttpClient())
            {
                Produto.ativo = true;
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PutAsJsonAsync("api/Produto", Produto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Index");
                } else
                {
                    return Page();
                }
            }
        }
    }
}
