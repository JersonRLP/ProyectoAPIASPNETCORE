using ClienteWebAPICL3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace ClienteWebAPICL3.Controllers
{
    public class ArticulosController : Controller
    {
        // GET: ArticulosController
        public async Task<ActionResult> ListarArticulosNo()
        {
            var listado = new List<Articulos>();

            using (var httpcliente = new HttpClient())
            {
                var respuesta = 
                    await httpcliente.GetAsync("http://192.168.1.16:7184/api/Articulos/GetListaArticulosNo");
                string respuestaAPI = await respuesta.Content.ReadAsStringAsync();

                listado = JsonConvert.DeserializeObject<List<Articulos>>(respuestaAPI);
            }

            
            return View(listado);
        }

        public async Task<ActionResult> ListarArticulosCodigo(string codart)
        {
            var listado = new List<Articulos>();

            using (var httpcliente = new HttpClient())
            {
                var respuesta =
                    await httpcliente.GetAsync($"http://192.168.1.16:7184/api/Articulos/GetListarArticulosCodigo/{codart}");
                string respuestaAPI = await respuesta.Content.ReadAsStringAsync();

                listado = JsonConvert.DeserializeObject<List<Articulos>>(respuestaAPI);
            }
            ViewBag.cantidad = listado.Count;
            return View(listado);
        }

        public async Task<ActionResult> ListarArticulosNombre(string nomart)
        {

            var lista_nombre = new List<Articulos>();

            if (nomart != null)
            {
                
                using (var httpcliente = new HttpClient())
                {
                    var respuesta =
                        await httpcliente.GetAsync($"http://192.168.1.16:7184/api/Articulos/GetListarFiltroArticulosNombre/{nomart}");
                    string respuestaAPI = await respuesta.Content.ReadAsStringAsync();

                    lista_nombre = JsonConvert.DeserializeObject<List<Articulos>>(respuestaAPI);
                }
            }
            ViewBag.cantidad = lista_nombre?.Count;

            return View(lista_nombre);
        }

        // GET: ArticulosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticulosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticulosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticulosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticulosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticulosController/Delete/5
        public async Task<ActionResult> EliminarArticulo(string cod_art)
        {

            var listado = new List<Articulos>();

            using (var httpcliente = new HttpClient())
            {
                var respuesta =
                    await httpcliente.GetAsync($"http://192.168.1.16:7184/api/Articulos/GetListarArticulosCodigo/{cod_art}");
                string respuestaAPI = await respuesta.Content.ReadAsStringAsync();

                listado = JsonConvert.DeserializeObject<List<Articulos>>(respuestaAPI);
            }

             
            Articulos? articulo = listado.Find(a => a.cod_art.Equals(cod_art));

            return View(articulo);
        }

        // POST: ArticulosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EliminarArticulos(string cod_art)
        {
            try
            {

                using ( var httpcliente = new HttpClient())
                {
                    var respuesta = await httpcliente.DeleteAsync($"http://192.168.1.16:7184/api/Articulos/LiquidacionArticulo/{cod_art}");
                    //
                    string respuestaAPI = await respuesta.Content.ReadAsStringAsync();
                    ViewBag.Mensaje = respuestaAPI;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }

            return RedirectToAction("ListarArticulosNombre");
        }
    }
}
