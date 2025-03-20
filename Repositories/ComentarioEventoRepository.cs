using Event_plus.Context;
using Event_plus.Domains;
using Event_plus.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Event_plus.Repositories
{
    public class ComentarioEventoRepository : IComentariosEventosRepository
    {
        private readonly EventoContext _context;
        public ComentariosEventos BuscarPorIdUsuario(Guid idUsuario, Guid idEvento)
        {
            return _context.ComentariosEventos.Find(idUsuario)!;
        }

        public void Cadastrar(ComentariosEventos comentarioEvento)
        {
            _context.ComentariosEventos.Add(comentarioEvento);
            _context.SaveChanges();
        }

        public void Deletar(int idComentario)
        {
            var comentarioBuscado = _context.ComentariosEventos.Find(idComentario);
            if (comentarioBuscado != null)
            {
                _context.ComentariosEventos.Remove(comentarioBuscado);
                _context.SaveChanges();
            }
        }

        

        public List<ComentariosEventos> Listar(Guid id)
        {
            return _context.ComentariosEventos.ToList<ComentariosEventos>();
        }
    }
}
