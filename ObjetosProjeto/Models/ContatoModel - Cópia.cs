using System.ComponentModel.DataAnnotations;

namespace ObjetosProjeto.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage = "O celular informado não é válido!")]
        public string Celular { get; set; }
        public int dtn { get; set; }
        [Required(ErrorMessage = "Digite o gênero do contato")]
        public string genero { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }

        public List<ObjetoModel>? Objetos { get; set; }

        public ContatoModel()
        {

        }


    }
}
