using RedeAurora.Domains;
using RedeAurora.DTOs.ItemDto;

namespace RedeAurora.Interfaces
{
    public interface IItemRepository
    {
        public List<ItemInventario> Listar();
        public ItemInventario ListarPorID(int id);
        public void Adicionar(ItemInventario item);
        public void Deletar (ItemInventario item);
        public List<QTDItensPorSetorDto> QuantidadePorUnidade(int id);
        public List<ItensPorSetorDto> ItensPorSetor(int id);
    }
}
