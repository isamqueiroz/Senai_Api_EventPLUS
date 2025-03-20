using Event_plus.Domains;

namespace Event_plus.interfaces
{
    public interface IComentariosEventosRepository
    {
        //Adicionar/Criar um novo comentario
        void Cadastrar(ComentariosEventos comentarioEvento);
        //Apagar um comentario
        void Deletar(int idComentario);
        //Listar os comentarios
        List<ComentariosEventos> Listar(Guid id);
        //lista comentários POR usuário
        ComentariosEventos BuscarPorIdUsuario(Guid idUsuario, Guid idEvento);
    }
}
