using Event_plus.Context;
using Event_plus.Domains;
using Event_plus.interfaces;

namespace Event_plus.Repositories
{
    public class TipoEventoRepository : ITiposEventosRepository
    {

        //Variavel que armazena o context
        private readonly EventoContext _context;
        //Metodo construtor
        public TipoEventoRepository(EventoContext context)
        {
            _context = context;
        }

        //Desenvolver os metodos que foram
        //criados na minha interface
        // Método para buscar um tipo de evento pelo ID
        public TiposEventos BuscarPorId(Guid id)
        {
            return _context.TiposEventos.Find(id)!;
        }

        // Método para cadastrar um novo tipo de evento
        public void Cadastrar(TiposEventos tipoEvento)
        {
            try
            {
                tipoEvento.IdTipoEvento = Guid.NewGuid();

                _context.TiposEventos.Add(tipoEvento);

                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        // Método para atualizar um tipo de evento existente
        public void Atualizar(Guid id, TiposEventos tipoEventoAtualizado)
        {
            TiposEventos tipoBuscado = _context.TiposEventos.Find(id)!;

            if (tipoBuscado != null)
            {
                tipoBuscado.Titulo = tipoEventoAtualizado.Titulo;
                _context.TiposEventos.Update(tipoBuscado);
                _context.SaveChanges();
            }
        }

        // Método para deletar um tipo de evento
        public void Deletar(Guid id)
        {
            try
            {
                   TiposEventos tipoBuscado = _context.TiposEventos.Find(id)!;

            if (tipoBuscado != null)
            {
                _context.TiposEventos.Remove(tipoBuscado);
            }

            

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TiposEventos> Listar()
        {
            try
            {
                return _context.TiposEventos.OrderBy(tp => tp.Titulo).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
