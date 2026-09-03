using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedeAurora.Applications.Services;
using RedeAurora.DTOs.ItemDto;

namespace RedeAurora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _service;

        public ItemController(ItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Listar()
        {
            try
            {
                List<ListarItemDto> itens = _service.Listar();
                return Ok(itens);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult ListarPorID(int id)
        {
            try
            {
                ListarItemDto item = _service.ListarPorID(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Quantidade-por-Setor")]
        public ActionResult<QTDItensPorSetorDto> QuantidadePorUnidade(int id)
        {
            try
            {
                var resultado = _service.QuantidadePorSetor(id);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Itens-por-setor/{id}")]
        public ActionResult<ItensPorSetorDto> itensPorSetor(int id)
        {
            try
            {
                var resultado = _service.ItensPorSetor(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Adicionar(CriarItemDto itemDto)
        {
            try
            {
                ListarItemDto item = _service.Adicionar(itemDto);
                return StatusCode(201, item);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    erro = ex.Message,
                    innerException = ex.InnerException?.Message
                });
            }
        }

        [HttpDelete]
        public ActionResult Deletar (int id)
        {
            try
            {
                _service.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
