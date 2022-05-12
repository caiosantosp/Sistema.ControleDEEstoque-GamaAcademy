using ControleDeEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ControleDeEstoque.Pages.Produtos
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Produto Produto { get; set; }

        string baseUrl = "https://localhost:44338";

        // Metodo Post para criar Produto
        public async Task<IActionResult> OnPostAsync()
        {
            using (var client = new HttpClient())
            {
                Produto.ativo = true;
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client
                    .PostAsJsonAsync("api/Produto", Produto);

                if (response.IsSuccessStatusCode)
                {
                    //Produtos/Index
                    return RedirectToPage("/Inicio");
                } else
                {
                    return Page();
                }
            }
        }
    }
}
