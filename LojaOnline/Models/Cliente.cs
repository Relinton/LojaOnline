
namespace LojaOnline.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }


        //Relacionamento um-para-um (1:1)
        public Endereco EnderecoDeEntrega { get; set; }
    }
}
