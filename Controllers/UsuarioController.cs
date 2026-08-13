using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedeAurora.Applications.Services;
using RedeAurora.Domains;
using RedeAurora.DTOs.UsuarioDto;
using RedeAurora.Exceptions;

namespace RedeAurora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;
        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<ListarUsuarioDto> usuarios = _service.Listar();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorID(Guid id)
        {
            try
            {
                ListarUsuarioDto usuario = _service.ListarPorID(id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("email/{email}")]
        public IActionResult ListarPorEmail(string email)
        {
            try
            {
                ListarUsuarioDto usuario = _service.ListarPorEmail(email);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ListarUsuarioDto> Adicionar(CriarUsuarioDto usuarioDto)
        {
            try
            {
                ListarUsuarioDto usuarioCriado = _service.Adicionar(usuarioDto);

                return StatusCode(201, usuarioCriado);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ListarUsuarioDto> Atualizar(Guid id, CriarUsuarioDto usuarioDto)
        {
            try
            {
                ListarUsuarioDto usuarioAtualizado = _service.Atualizar(id, usuarioDto);

                return StatusCode(200, usuarioAtualizado);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(Guid id)
        {
            try
            {
                _service.Deletar(id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
