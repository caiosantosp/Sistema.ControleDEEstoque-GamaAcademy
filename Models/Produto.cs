namespace ControleDeEstoque.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public string modelo { get; set; }
        public int quantidade { get; set; }
        public string descricao { get; set; }
        public string tamanho { get; set; }
        public double preco { get; set; }
        public string imagem { get; set; }
        public bool ativo { get; set; }
        public Categoria Categoria { get; set; }
    }
}
