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

        public List<QTDItensPorSetorDto> QuantidadePorUnidade()
        {
            return _context.Setor.Select(setor => new QTDItensPorSetorDto
                {
                    id_setor = setor.id_setor,
                    nome_setor = setor.nome,
                    quantidade_itens = setor.ItemInventario.Count(),
                }).ToList();
        }

        public List<ItensPorSetorDto> ItensPorSetor()
        {
            return _context.Setor
                .SelectMany(setor => setor.ItemInventario.Select(item => new ItensPorSetorDto
                {
                    id_setor = setor.id_setor,
                    nome_setor = setor.nome,
                    id_item = item.id_item,
                    nome_item = item.nome,
                    codigo_patrimonio = item.codigo_patrimonio,
                })).ToList();
        }

    }
}
