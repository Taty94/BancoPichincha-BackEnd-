using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefautMessageForStatusCode(statusCode);
        }
        public int StatusCode {get; set;}
        public string Message {get; set;}

        private string GetDefautMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Una mala peticion fue hecha",
                401 => "No estas autorizado",
                404 => "El recurso no fue encontrado",
                500 => "Error en el servidor",
                _ => null
            };
        }
    }
}