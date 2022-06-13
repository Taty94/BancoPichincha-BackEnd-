using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;
using System.Threading.Tasks;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IBancaRepository _repo;
        private readonly IGenericRepository<Usuario> _genrepo;

        public UsuariosController(IBancaRepository repo, IGenericRepository<Usuario> genrepo){
            _genrepo = genrepo;
            _repo = repo;
        }

        //GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            //var usuarios = await _genrepo.ListAllAsync();
            var usuarios = await _repo.GetUsuariosAsync();
            return Ok(usuarios);
        }

        //Get: api/Usuarios/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id){
            var usuario =  await _genrepo.GetByIdAsync(id);
            if(usuario==null){
                return NotFound(false);
            }else
            {
                return usuario;
            }
        }

        //Put: api/Usuarios/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            try{
                await _genrepo.CreateUpdateAsync(usuario);
                return Ok(usuario);
            }
            catch(Exception ex)
            {
                return BadRequest(false);
            }
        }

        //Post:api/Usuarios
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            try{
                var user = await _genrepo.CreateUpdateAsync(usuario);
                return CreatedAtAction("GetUsuarioById",new {id = user.Id}, user);
            }
            catch(Exception ex)
            {
                return BadRequest(false);
            }
        }

        //Delete: api/Usuarios/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                bool estaEliminado = await _genrepo.DeteleAsync(id);
                if(estaEliminado)
                {
                    return Ok(estaEliminado);
                }
                else
                {
                    return BadRequest(false);
                }
        
            }
            catch(Exception ex)
            {
                return BadRequest(false);
            }
        }
    }
}