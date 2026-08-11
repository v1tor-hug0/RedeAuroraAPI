using RedeAurora.Domains;

namespace RedeAurora.Interfaces
{
    public interface IUnidadeRepository
    {
        List<Unidade> Listar();
        Unidade ListarPorId(int id);
        Unidade BuscarPorNome(string nome);
        void Adicionar(Unidade unidade);
        void Atualizar(Unidade unidade);
    }
}
