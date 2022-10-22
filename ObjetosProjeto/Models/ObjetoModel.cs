using ObjetosProjeto.Models.Enums;

namespace ObjetosProjeto.Models
{
    public class ObjetoModel
    {

        public int Id { get; set; }

        public string Objeto { get; set; }
        public string Modelo { get; set; }
        public string Detalhes { get; set; }
        public string Localizacao { get; set; }

        public AchadoPerdido AchadoPerdido { get; set; }


        public ContatoModel? Contato { get; set; }

        public int ContatoId { get; set; }

        public ObjetoModel()
        {

        }

        public ObjetoModel(string objeto, string modelo, string detalhes, string localizacao, AchadoPerdido achadoPerdido, ContatoModel? contato, int contatoId)
        {
            Objeto = objeto;
            Modelo = modelo;
            Detalhes = detalhes;
            Localizacao = localizacao;
            AchadoPerdido = achadoPerdido;
            Contato = contato;
            ContatoId = contatoId;
        }
    }
}
