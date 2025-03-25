using Event_plus.Context;
using Event_plus.Domains;
using Event_plus.interfaces;

namespace Event_plus.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {
        private readonly EventoContext _context;

        public UsuarioRepository(EventoContext context)
        {
            _context = context;
        }
        public List<Usuarios> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuarios BuscarPorId(Guid id)
        {
            return _context.Usuarios.Find(id)!;
        }

        public void Cadastrar(Usuarios usuarioEvento)
        {
            _context.Usuarios.Add(usuarioEvento);
            _context.SaveChanges();
        }

        public void Atualizar(Guid id, Usuarios UsuarioAtualizado)
        {
            Usuarios UsuarioBuscado = _context.Usuarios.Find(id)!;

            if (UsuarioBuscado != null)
            {
                UsuarioBuscado.Nome = UsuarioAtualizado.Nome;
               UsuarioBuscado.Email = UsuarioAtualizado.Email;
                UsuarioBuscado.Senha = UsuarioAtualizado.Senha;
                UsuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;
            }
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Usuarios usuarioBuscado = _context.Usuarios.Find(id)!;
            if (usuarioBuscado != null)
            {
                _context.Usuarios.Remove(usuarioBuscado);
                _context.SaveChanges();
            }
        }

        

        public Usuarios BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios.FirstOrDefault(u => u.Email == email)!;
                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
    }

