using Event_plus.Domains;

namespace Event_plus.interfaces
{
    public interface ITiposUsuariosRepository
    {
        void Cadastrar(TiposUsuarios tipoUsuario);
        void Deletar(Guid id);
        List<TiposUsuarios> Listar();
        TiposUsuarios BuscarPorId(Guid id);
        void Atualizar(Guid id, TiposUsuarios tipoUsuario);
    }
}
