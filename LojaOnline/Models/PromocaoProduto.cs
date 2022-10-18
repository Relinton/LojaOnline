
namespace LojaOnline.Models
{
    public class PromocaoProduto
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int PromocaoId { get; set; }
        public Promocao Promocao { get; set; }

        //Relacionamento muitos-para-muitos (N:N), Tabela responsável por fazer o join.
    }
}
