using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using COAChallenge.Datos.Repositorios;
using COAChallenge.Dtos;
using COAChallenge.Entidades;

namespace COAChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IMapper _mapper;

        public UsuariosController(IRepositorioUsuario repositorioUsuario, IMapper mapper)
        {
            _repositorioUsuario = repositorioUsuario;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var usuarios = await _repositorioUsuario.GetAll();
            return Ok(_mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioToReturnDto>>(usuarios));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var usuario = await _repositorioUsuario.GetById(id);
            if (usuario == null) return BadRequest(new { message = "No se encontro al usuario" });
            return Ok(_mapper.Map<Usuario,UsuarioToReturnDto>(usuario));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UsuarioDto usuarioDto)
        {
            var usuario = await _repositorioUsuario.Add(_mapper.Map<UsuarioDto, Usuario>(usuarioDto));

            if (usuario == null) return BadRequest(new { message = "No se pudo agregar el usuario" });

            return Ok(_mapper.Map<Usuario, UsuarioToReturnDto>(usuario));
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UsuarioDto usuarioDto)
        {
            var usuarioAActualizar = await _repositorioUsuario.Update(_mapper.Map<UsuarioDto,Usuario>(usuarioDto));
            if (usuarioAActualizar == null) return BadRequest("No se pudo actualizar el usuario");

            return Ok(_mapper.Map<Usuario,UsuarioToReturnDto>(usuarioAActualizar));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuarioAEliminar = await _repositorioUsuario.Delete(id);

            if(usuarioAEliminar==null) return BadRequest("No se pudo eliminar el usuario");

            return Ok(_mapper.Map<Usuario,UsuarioToReturnDto>(usuarioAEliminar));
        }
        
    }
}
