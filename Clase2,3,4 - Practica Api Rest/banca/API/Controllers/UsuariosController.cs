using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;
using System.Threading.Tasks;
using System;
using AutoMapper;
using API.Dtos;
using API.Errors;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IBancaRepository _repo;
        private readonly IGenericRepository<Usuario> _genrepo;
        private readonly IMapper _mapper;
        private ApiResponse _response;

        public UsuariosController(IBancaRepository repo,
                                IGenericRepository<Usuario> genrepo,
                                IMapper mapper ){
            _mapper = mapper;
            _genrepo = genrepo;
            _repo = repo;
            _response = new ApiResponse();
        }

        //GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Usuario>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _repo.GetUsuariosAsync();
                _response.Result =_mapper. Map<IReadOnlyList<Usuario>,IReadOnlyList<UsuarioToReturnDto>>(usuarios);
                _response.DisplayMessage = "Listado de Usuarios";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        //Get: api/Usuarios/1
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioToReturnDto>> GetUsuarioById(int id){
            var usuario =  await _repo.GetUsuarioByIdAsync(id);
            if(usuario==null){
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario No Existe";
                return NotFound(_response);
            }

            _response.Result = _mapper.Map<Usuario,UsuarioToReturnDto>(usuario);
            _response.DisplayMessage = "Informacion de Usuario";
            return Ok(_response);
        }

        //Put: api/Usuarios/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            try
            {
                var user = await _genrepo.CreateUpdateAsync(usuario);
                _response.Result = _mapper.Map<Usuario,UsuarioToReturnDto>(user);
                return Ok(_response);
            } 
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al Actualizar el Usuario";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        //Post:api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            try
            {
                var user = await _genrepo.CreateUpdateAsync(usuario);
                var userDto = _mapper.Map<Usuario,UsuarioToReturnDto>(user);
                _response.Result = userDto;
                return CreatedAtAction("GetUsuarioById",new {id = userDto.Id}, _response);
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al guardar el usuario";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        //Delete: api/Usuarios/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                bool isDeleted = await _genrepo.DeteleAsync(id);
                if(isDeleted)
                {
                    _response.Result = isDeleted;
                    _response.DisplayMessage = "Usuario Eliminado con 'Exito";
                    return Ok(_response);
                }
                else
                {
                     _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al Eliminar Usuario";
                    return BadRequest(_response);
                }
        
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}