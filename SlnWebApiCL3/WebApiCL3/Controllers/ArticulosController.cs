using Microsoft.AspNetCore.Mvc;
using WebApiCL3.DAO;
using WebApiCL3.Entidad;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCL3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {

        private readonly ArticulosDAO artidao;

        public ArticulosController(ArticulosDAO _dao)
        {
            artidao = _dao;
        }
        

        // GET: api/<ArticulosController>
        [HttpGet("GetListaArticulosNo")]
        public List<Articulos> GetListaArticulosNo()
        {
            return artidao.ListarArticulosNo();
        }

        [HttpGet("GetListarArticulosCodigo/{codart}")]
        public List<Articulos> GetListarArticulosCodigo(string codart)
        {
            return artidao.ListarArticulosCodigo(codart);
        }

        [HttpGet("GetListarFiltroArticulosNombre/{nomart}")]
        public List<Articulos> GetListarFiltroArticulosNombre(string nomart)
        {
            return artidao.ListarFiltroArticulosNombre(nomart);
        }

        /*
        // POST api/<ArticulosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        */

        /*
        // PUT api/<ArticulosController>/5
        [HttpPut("LiquidacionArticulo")]
        public string PutLiquidacionArticulo([FromBody] LIQUIDACION_ARTICULO_BAJA obj)
        {
            return artidao.LiquidacionArticulo(obj);
        }
        */
        
        //DELETE api/<ArticulosController>/5
        [HttpDelete("LiquidacionArticulo/{codart}")]
        public string LiquidacionArticulo(string codart)
        {
            return artidao.LiquidacionArticulo(codart);
        }
        
    }
}
