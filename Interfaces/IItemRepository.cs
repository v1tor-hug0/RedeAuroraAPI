using RedeAurora.Domains;
using RedeAurora.DTOs.ItemDto;

namespace RedeAurora.Interfaces
{
    public interface IItemRepository
    {
        public List<ListarItemDto> Listar();
        public ItemInventario ListarPorID(int id);
        public void Adicionar(ItemInventario item);
        public void Deletar (ItemInventario item);
        public List<QTDItensPorSetorDto> QuantidadePorSetor();
        public List<ItensPorSetorDto> ItensPorSetor(int id);
    }
}
