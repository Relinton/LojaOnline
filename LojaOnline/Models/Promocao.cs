
using System;
using System.Collections.Generic;

namespace LojaOnline.Models
{
    public class Promocao
    {
        public Promocao()
        {
            this.Produtos = new List<PromocaoProduto>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }


        //Relacionamento muitos-para-muitos (N:N)
        public IList<PromocaoProduto> Produtos { get; set; }
    }
}
