using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using RedeAurora.Domains;
using RedeAurora.DTOs.ItemDto;
using RedeAurora.Exceptions;
using RedeAurora.Interfaces;
using System.Security.Claims;

namespace RedeAurora.Applications.Services
{
    public class ItemService
    {
        private readonly IItemRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ItemService(IItemRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        private static ListarItemDto lerDto (ItemInventario item)
        {
            return new ListarItemDto
            {
                id_item = item.id_item,
                nome = item.nome,
                codigo_patrimonio = item.codigo_patrimonio,
                descricao = item.descricao,
                id_setor = item.id_setor,
                condicao = item.condicao,
                data = item.data_hora,
                id_usuario = item.id_usuario ?? Guid.Empty,
            };
        }

        public List<ListarItemDto> Listar()
        {
            return _repository.Listar();
        }

        public ListarItemDto ListarPorID(int id)
        {
            var item = _repository.ListarPorID(id);

            if (item == null)
            {
                throw new DomainException("Item não encontrado.");
            }

            return item;
        }

        public ListarItemDto Adicionar(CriarItemDto itemDto)
        {
            var userId = GetCurrentUserId();

            ItemInventario item = new ItemInventario
            {
                nome = itemDto.nome,
                codigo_patrimonio = itemDto.codigo_patrimonio,
                descricao = itemDto.descricao,
                id_setor = itemDto.id_setor,
                condicao = itemDto.condicao,
                data_hora = DateTime.Now,
                id_usuario = userId
            };
            _repository.Adicionar(item);
            return lerDto(item);
        }

        private Guid? GetCurrentUserId()
        {
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user == null) throw new UnauthorizedAccessException("Usuário não autenticado.");

            var claim = user.FindFirst(ClaimTypes.NameIdentifier) ?? user.FindFirst("sub") ?? user.FindFirst("id");
            if (claim == null) throw new UnauthorizedAccessException("ID do usuário não encontrado.");

            if (Guid.TryParse(claim.Value, out var guid)) return guid;
            return null;
        }

        public void Deletar(int id)
        {
            _repository.Deletar(id);
        }

        public List<QTDItensPorSetorDto> QuantidadePorSetor()
        {
            return _repository.QuantidadePorSetor();
        }

        public List<ItensPorSetorDto> ItensPorSetor(int id)
        {
            return _repository.ItensPorSetor(id);
        }


    }
}
