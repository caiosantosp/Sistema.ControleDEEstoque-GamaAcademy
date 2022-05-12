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
    public class DeleteModel : PageModel
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/ErroID/ErroID");
            }

            if (Produto.ID != id)
            {
                return RedirectToPage("/ErroID/ErroID");
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.DeleteAsync("api/Produto/" + Produto.ID);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("./Index");
                } else
                {
                    return RedirectToPage("/ErroID/ErroID");
                }
            }
        }
    }
}
