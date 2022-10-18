
using System.Collections.Generic;

namespace LojaOnline.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public double PrecoUnitario { get; set; }
        public string Unidade { get; set; }


        //Relacionamento muitos-para-muitos (N:N)
        public IList<PromocaoProduto> Promocoes { get; set; }
        public IList<Compra> Compras { get; set; }
    }
}
