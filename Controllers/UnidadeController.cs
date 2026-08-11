using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedeAurora.Applications.Services;
using RedeAurora.DTOs.SetorDto;
using RedeAurora.DTOs.UnidadeDto;

namespace RedeAurora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        private readonly UnidadeService _service;

        public UnidadeController(UnidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ListarUnidadeDto>> Listar()
        {
            try
            {
                var unidades = _service.Listar();
                return Ok(unidades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ListarUnidadeDto> ListarPorId(int id)
        {
            try
            {
                var unidade = _service.ListarPorID(id);
                if (unidade == null)
                {
                    return NotFound();
                }
                return Ok(unidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ListarUnidadeDto> Adicionar(CriarUnidadeDto dto)
        {
            try
            {
                _service.Adicionar(dto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ListarUnidadeDto> Atualizar(int id, CriarUnidadeDto dto)
        {
            try
            {
                _service.Atualizar(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
