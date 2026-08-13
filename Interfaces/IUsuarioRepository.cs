using RedeAurora.Domains;

namespace RedeAurora.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario ListarPorID(Guid id);
        Usuario ListarPorEmail(string email);
        bool EmailExiste(string email);
        void Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Deletar(Guid id);
    }
}
