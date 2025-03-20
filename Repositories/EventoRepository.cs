using Event_plus.Context;
using Event_plus.Domains;
using Event_plus.interfaces;

namespace Event_plus.Repositories
{
    public class EventoRepository : IEventosRepository
    {
        private readonly EventoContext _context;

        public EventoRepository(EventoContext context)
        {
            _context = context;
        }


        public List<Eventos> Listar()
        {
            return _context.Eventos.ToList();
        }
        //Desenvolver os metodos que foram
        //criados na minha interface
        // Método para buscar um tipo de evento pelo ID
        public Eventos BuscarPorId(Guid id)
        {
            return _context.Eventos.Find(id)!;
        }

        // Método para cadastrar um novo tipo de evento
        public void Cadastrar(Eventos evento)
        {
            _context.Eventos.Add(evento);
            _context.SaveChanges();
        }

        // Método para atualizar um tipo de evento existente
        public void Atualizar(Guid id, Eventos eventoAtualizado)
        {
            Eventos eventoBuscado = _context.Eventos.Find(id)!;

            if (eventoBuscado != null)
            {
                _context.SaveChanges();
                eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento; 
                eventoBuscado.Descricao = eventoAtualizado.Descricao;

                _context.Eventos.Update(eventoBuscado);
            }
        }


        public void Deletar(Guid id)
        {
            Eventos eventoBuscado = _context.Eventos.Find(id)!;
            if (eventoBuscado != null)
            {
                _context.Eventos.Remove(eventoBuscado);
                _context.SaveChanges();
            }
        }


        public List<Eventos> ListarPorId(Guid id)
        {
            return _context.Eventos.ToList();
        }

        public List<Eventos> ProximosEventos()
        {
            return _context.Eventos.ToList(); ;
        }
    }


}
