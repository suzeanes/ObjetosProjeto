using Microsoft.EntityFrameworkCore;
using ObjetosProjeto.Models;

namespace ObjetosProjeto.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DbContext _context;

        public UsuarioRepositorio(DbContext context)
        {
            this._context = context;
        }

        public ContatoModel Adicionar(ContatoModel usuario)
        {
            throw new NotImplementedException();
        }

        public bool Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public ContatoModel Atualizar(ContatoModel usuario)
        {
            throw new NotImplementedException();
        }

        public ContatoModel BuscarPorEmailELogin(string email, string login)
        {
            throw new NotImplementedException();
        }

        public ContatoModel BuscarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public ContatoModel BuscarPorLogin(string login)
        {
            throw new NotImplementedException();
        }

        public ContatoModel BuscarporLogin(string login)
        {
            throw new NotImplementedException();
        }

        public List<ContatoModel> BuscarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
