using RedeAurora.Domains;
using RedeAurora.DTOs.ItemDto;

namespace RedeAurora.Interfaces
{
    public interface IItemRepository
    {
        public List<ListarItemDto> Listar();
        public ListarItemDto? ListarPorID(int id);
        public void Adicionar(ItemInventario item);
        public void Deletar (int id);
        public List<QTDItensPorSetorDto> QuantidadePorSetor();
        public List<ItensPorSetorDto> ItensPorSetor(int id);
    }
}
