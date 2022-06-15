using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaRepository _repo;
        private readonly IGenericRepository<Cuenta> _genrepo;
        private readonly IMapper _mapper;

        public CuentasController(ICuentaRepository repo,
                             IGenericRepository<Cuenta> genrepo,
                             IMapper mapper){
            _mapper = mapper;
            _genrepo = genrepo;
            _repo = repo;
        }

        //GET: api/Cuentas
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CuentaToReturnDto>>> GetCuentas()
        {
            var cuentas = await _repo.GetCuentasAsync();
            return Ok(_mapper.
                Map<IReadOnlyList<Cuenta>,IReadOnlyList<CuentaToReturnDto>>(cuentas));
        }

        //Get: api/Cuentas/1
        [HttpGet("{id}")]
        public async Task<ActionResult<CuentaToReturnDto>> GetCuentaById(int id){
            var cuenta =  await _repo.GetCuentaByIdAsync(id);
            if(cuenta==null){
                return NotFound(false);
            }else
            {
                return _mapper.Map<Cuenta,CuentaToReturnDto>(cuenta);
                //return cuenta;
            }
        }

        // //Put: api/Cuentas/1
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutCuenta(int id, Cuenta cuenta)
        // {
        //     try{
        //         await _genrepo.CreateUpdateAsync(cuenta);
        //         return Ok(cuenta);
        //     }
        //     catch(Exception ex)
        //     {
        //         return BadRequest(false);
        //     }
        // }

        //Post:api/Cuentas
        [HttpPost]
        public async Task<ActionResult<Cuenta>> PostCuenta(Cuenta cuenta)
        {
            try{
                var account = await _genrepo.CreateUpdateAsync(cuenta);
                return CreatedAtAction("GetCuentaById",new {id = account.Id}, account);
            }
            catch(Exception ex)
            {
                return BadRequest(false);
            }
        }

        //Delete: api/Cuentas/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuenta(int id)
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

        //Post:api/Cuentas/1/1/20
        [HttpPut("{transaccion}/{idCuenta}/{cantidad}")]
        public async Task<IActionResult> Transaccion(int transaccion, int id, decimal cantidad){
            bool result = false;
            switch (transaccion)
            {
                case 1:
                    if(id> 0 && cantidad>0){
                        result = await _repo.Deposit(id,cantidad);
                    }
                break;
                case 2:
                    if(id> 0 && cantidad>0){
                        result = await _repo.Removal(id,cantidad);
                    }
                break;
            }
            if(result)
            {
                return Ok(result);
            }
            {
                return BadRequest(result);
            }
        }

        
    }
}