using RedeAurora.Domains;
using RedeAurora.DTOs.SetorDto;

namespace RedeAurora.Interfaces
{
    public interface ISetorRepository
    {
        List<Setor> Listar();
        Setor ListarPorId(int id);
        Setor BuscarPorNome(string nome);
        void Adicionar(Setor setor);
        void Atualizar(Setor setor);
    }
}
