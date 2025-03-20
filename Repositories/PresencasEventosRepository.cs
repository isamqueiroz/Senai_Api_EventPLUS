using Event_plus.Context;
using Event_plus.Domains;
using Event_plus.interfaces;

namespace Event_plus.Repositories
{
    public class PresencasEventosRepository : IPresencasEventosRepository
    {
        private readonly EventoContext _context;

       
        public void Atualizar(Guid id, PresencasEventos PresencasEventoAtualizado)
        {
            PresencasEventos PresencaBuscada = _context.PresencasEventos.Find(id)!;

            if (PresencaBuscada != null)
            {
               PresencaBuscada.IdPresencaEvento = PresencasEventoAtualizado.IdPresencaEvento;
               PresencaBuscada.Situacao = PresencasEventoAtualizado.Situacao;
               PresencaBuscada.IdUsuario = PresencasEventoAtualizado.IdUsuario;
               PresencaBuscada.IdEvento = PresencasEventoAtualizado.IdEvento;
               PresencaBuscada.Evento = PresencasEventoAtualizado.Evento;
               PresencaBuscada.Usuario = PresencasEventoAtualizado.Usuario;
                
                
            }
            _context.SaveChanges();
        }

        public PresencasEventos BuscarPorId(Guid id)
        {
            return _context.PresencasEventos.Find(id)!;
        }

        public void Deletar(Guid id)
        {
            var PresencaBuscada = _context.PresencasEventos.Find(id);
            if (PresencaBuscada != null)
            {
                _context.PresencasEventos.Remove(PresencaBuscada);
                _context.SaveChanges();
            }
            
        }

        public void Inscrever(PresencasEventos inscricao)
        {
            var eventoExistente = _context.Eventos.Any(e => e.IdEvento == inscricao.IdEvento);
            var usuarioInscrito = _context.PresencasEventos.Any(p => p.IdUsuario == inscricao.IdUsuario && p.IdEvento == inscricao.IdEvento);

            if (eventoExistente && !usuarioInscrito)
            {
                _context.PresencasEventos.Add(inscricao);
                _context.SaveChanges();
            }
        }

        public List<PresencasEventos> Listar()
        {
            return _context.PresencasEventos.ToList();
        }

        public List<PresencasEventos> ListarMinhasPresencas(Guid id)
        {
            return _context.PresencasEventos.ToList();
        }
    }
}
