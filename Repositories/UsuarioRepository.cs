using System.Linq;
using RedeAurora.Contexts;
using RedeAurora.Domains;
using RedeAurora.Interfaces;

namespace RedeAurora.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly RedeAuroraContext _context;

        public UsuarioRepository(RedeAuroraContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public void Atualizar(Usuario usuario)
        {
            if(usuario == null) return;

            var usuarioExistente = _context.Usuario.Find(usuario.id_usuario);

            if(usuarioExistente == null) return;

            usuarioExistente.nome = usuario.nome;
            usuarioExistente.email = usuario.email;
            usuarioExistente.senha = usuario.senha;
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var usuario = _context.Usuario.Find(id);
            if(usuario == null) return;

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
        }

        public bool EmailExiste(string email)
        {
            return _context.Usuario.Any(u => u.email == email);
        }

        public List<Usuario> Listar()
        {
            return _context.Usuario.OrderBy(u => u.id_usuario).ToList();
        }

        public Usuario ListarPorEmail(string email)
        {
            return _context.Usuario.FirstOrDefault(u => u.email == email);
        }

        public Usuario ListarPorID(Guid id)
        {
            return _context.Usuario.Find(id);
        }

        public Usuario ListarPorNome(string email)
        {
            return _context.Usuario.FirstOrDefault(u => u.email == email);
        }

    }
}
    