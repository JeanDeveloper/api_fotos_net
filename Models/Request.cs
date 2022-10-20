using Microsoft.AspNetCore.Http;

namespace ApiSolgisFotos.Models
{
    public class Request
    {

        public IFormFile file { get; set; }

        public int cod_movimiento { get; set; }
        
        public string creado_por { get; set; }

        public int datoAcceso { get; set; }


    }
}
