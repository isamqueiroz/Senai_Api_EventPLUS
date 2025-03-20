using Event_plus.Context;
using Event_plus.Domains;
using Event_plus.interfaces;

namespace Event_plus.Repositories
{
    public class TipoUsuarioRepository : ITiposUsuariosRepository
    {
        private readonly EventoContext _context;

        public TipoUsuarioRepository(EventoContext context)
        {
            _context = context;
        }

        public List<TiposUsuarios> Listar()
        {
            return _context.TiposUsuario.ToList();
        }

        public TiposUsuarios BuscarPorId(Guid id)
        {
            return _context.TiposUsuario.Find(id)!;
        }

        public void Cadastrar(TiposUsuarios tipoUsuario)
        {
            _context.TiposUsuario.Add(tipoUsuario);
            _context.SaveChanges();
        }
        public void Atualizar(Guid id, TiposUsuarios tiposUsuarioAtualizado)
        {
            TiposUsuarios tipoBuscado = _context.TiposUsuario.Find(id)!;

            if (tipoBuscado != null)
            {
                tipoBuscado.IdTipoUsuario = tiposUsuarioAtualizado.IdTipoUsuario;
                tipoBuscado.TituloTipoUsuario = tiposUsuarioAtualizado.TituloTipoUsuario;
               
            }
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposUsuarios tipoBuscado = _context.TiposUsuario.Find(id)!;
            if (tipoBuscado != null)
            {
                _context.TiposUsuario.Remove(tipoBuscado);
                _context.SaveChanges();
            }


        }

       
    }
}

