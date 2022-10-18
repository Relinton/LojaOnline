
namespace LojaOnline.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }


        //Relacionamento um-para-muitos (tblProduto: tblCompra) 1:N
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

    }
}
