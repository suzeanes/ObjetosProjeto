using ObjetosProjeto.Models;

namespace ObjetosProjeto.Repositorio
{
    public interface IUsuarioRepositorio
    {
        ContatoModel BuscarPorLogin(string login);
        ContatoModel BuscarPorEmailELogin(string email, string login);
        List<ContatoModel> BuscarTodos();
        ContatoModel BuscarPorID(int id);
        ContatoModel Adicionar(ContatoModel usuario);
        ContatoModel Atualizar(ContatoModel usuario);
       
        bool Apagar(int id);
        ContatoModel BuscarporLogin(string login);
    }
}

