using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedeAurora.Applications.Services;
using RedeAurora.DTOs.SetorDto;

namespace RedeAurora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly SetorService _service;

        public SetorController(SetorService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ListarSetorDto>> Listar() 
        {
            try
            {
                var setores = _service.Listar();
                return Ok(setores);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ListarSetorDto> ListarPorId(int id)
        {   
            try
            {
                var setor = _service.ListarPorID(id);
                if (setor == null)
                {
                    return NotFound();
                }
                return Ok(setor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ListarSetorDto> Adicionar (CriarSetorDto dto)
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
        public ActionResult<ListarSetorDto> Atualizar(int id, CriarSetorDto dto)
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
