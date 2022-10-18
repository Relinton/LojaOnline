
namespace LojaOnline.Models
{
    public class Endereco
    {
        //No relacionamento um-para-um não preciso explicitar na tabela secundária no caso endereço
        //o id dela, isso será feito no contexto implicitamente para a regra do negócio, usando o conceito de 
        //state shadow (estado escondido)...
        public int Numero { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }


        //Relacionamento um-para-um (1:1)
        public Cliente Cliente { get; set; }
    }
}
