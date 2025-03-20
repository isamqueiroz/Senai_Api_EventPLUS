using Event_plus.Domains;

namespace Event_plus.interfaces
{
    public interface IUsuariosRepository
    {
        void Cadastrar(Usuarios usuario);

        Usuarios BuscarPorId(Guid id);

        Usuarios BuscarPorEmailESenha(string email, string senha);
    }
}
