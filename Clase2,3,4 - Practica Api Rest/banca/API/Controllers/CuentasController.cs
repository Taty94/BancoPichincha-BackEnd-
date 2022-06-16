using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
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
        private ApiResponse _response;

        public CuentasController(ICuentaRepository repo,IGenericRepository<Cuenta> genrepo,IMapper mapper )
        {
            _mapper = mapper;
            _genrepo = genrepo;
            _repo = repo;
            _response = new ApiResponse();
        }

        //GET: api/Cuentas
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CuentaToReturnDto>>> GetCuentas()
        {
            try
            {
                var cuentas = await _repo.GetCuentasAsync();
                _response.Result = _mapper.Map<IReadOnlyList<Cuenta>,IReadOnlyList<CuentaToReturnDto>>(cuentas);;
                _response.DisplayMessage = "Listado de Cuentas";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        //Get: api/Cuentas/1
        [HttpGet("{id}")]
        public async Task<ActionResult<CuentaToReturnDto>> GetCuentaById(int id){
            var cuenta =  await _repo.GetCuentaByIdAsync(id);
            if(cuenta==null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Cuenta No Existe";
                return NotFound(_response);
            }
            _response.Result = _mapper.Map<Cuenta,CuentaToReturnDto>(cuenta);
            _response.DisplayMessage = "Informacion de Cuenta";
            return Ok(_response);
                
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
            try
            {
                cuenta.GetNumCuenta();
                var account = await _genrepo.CreateUpdateAsync(cuenta);
                var cuentaDto = _mapper.Map<Cuenta,CuentaToReturnDto>(account);
                _response.Result = cuentaDto;
                return CreatedAtAction("GetCuentaById",new {id = cuentaDto.Id}, _response);//me retorna un status 201 de creado
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al guardar la cuenta";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        //Delete: api/Cuentas/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuenta(int id)
        {
            try
            {
                bool isDeleted = await _genrepo.DeteleAsync(id);
                if(isDeleted)
                {
                    _response.Result = isDeleted;
                    _response.DisplayMessage = "Cuenta Eliminada con 'Exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al Eliminar Cuenta";
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

        //Post:api/Cuentas/1/1/20
        [HttpPut("{transaccion}/{idCuenta}/{cantidad}")]
        public async Task<IActionResult> Transaccion(int transaccion, int id, decimal cantidad){
            bool result = false;
            var move = "";
            try {
                switch (transaccion)
                {
                    case 1:
                        move = "Deposito";
                        if(id> 0 && cantidad>0){
                            result = await _repo.Deposit(id,cantidad);
                        }
                    break;
                    case 2:
                        move = "Retiro";
                        if(id> 0 && cantidad>0){
                            result = await _repo.Removal(id,cantidad);
                        }
                    break;
                }
                if(result)
                {
                    _response.Result = result;
                    _response.DisplayMessage = "El " + move + " con 'Exito";
                    return Ok(_response);
                }
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "El " + move + "no se efectuo, intentelo mas tarde";
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