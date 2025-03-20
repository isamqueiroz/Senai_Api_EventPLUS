using Event_plus.Domains;

namespace Event_plus.interfaces
{
    public interface IPresencasEventosRepository
    {
    
            //Inscrever no evento/Se cadastrar no evento
            void Inscrever(PresencasEventos inscricao);

            //Deletar a presença
            void Deletar(Guid id);

            //Atualizar a nossa presença no evento
            void Atualizar(Guid id, PresencasEventos presenca);

            //Listar as presencas
            List<PresencasEventos> Listar();

            //Listar as presencas por Usuario(id)
            List<PresencasEventos> ListarMinhasPresencas(Guid id);

            //Buscar a presença por ID
            PresencasEventos BuscarPorId(Guid id);
        
    }
}
