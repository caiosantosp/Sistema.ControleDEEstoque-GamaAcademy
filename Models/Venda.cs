namespace ControleDeEstoque.Models
{
    public class Venda
    {
        public int ID { get; set; }
        public double total { get; set; }
        public int quantidade { get; set; }
        public double precoUnitario { get; set; }
        public string data { get; set; }
        public Produto Produto { get; set; }
    }
}
