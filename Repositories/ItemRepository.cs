using RedeAurora.Contexts;
using RedeAurora.Domains;
using RedeAurora.DTOs.ItemDto;
using RedeAurora.Interfaces;

namespace RedeAurora.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly RedeAuroraContext _context;

        public ItemRepository(RedeAuroraContext context) 
        { 
            _context = context;
        }

        public void Adicionar(ItemInventario item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Deletar(ItemInventario item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public List<ItemInventario> Listar()
        {
            return _context.ItemInventario.OrderBy(i => i.id_item).ToList();
        }

        public ItemInventario ListarPorID(int id)
        {
            return _context.ItemInventario.Find(id);
        }

        public List<QTDItensPorUnidadeDto> QuantidadePorUnidade()
        {
            return _context.Unidade.Select(unidade => new QTDItensPorUnidadeDto
                {
                    id_unidade = unidade.id_unidade,
                    nome_unidade = unidade.nome,
                    quantidade_itens = unidade.Setor.SelectMany(setor => setor.ItemInventario).Count(),
                }).ToList();
        }
    }
}
