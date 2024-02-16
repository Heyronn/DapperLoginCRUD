using DapperLoginCRUD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperLoginCRUD.Controllers
{
    public class VideoJuegosController : Controller
    {
        private readonly IServicioUsuario servicioUsuario;
        private readonly IRepositorioVideoJuegos repositorioVideoJuegos;

        public VideoJuegosController(IServicioUsuario servicioUsuario, IRepositorioVideoJuegos repositorioVideoJuegos) {
            this.servicioUsuario = servicioUsuario;
            this.repositorioVideoJuegos = repositorioVideoJuegos;
        }

        // GET: VideoJuegosController
        public async Task<ActionResult> Index()
        {
            var idUsuario = servicioUsuario.ObtenerUsuarioId();
            var conjuntoVideojuegos = await repositorioVideoJuegos.Obtener(idUsuario);

            return View(conjuntoVideojuegos);
        }

        //// GET: VideoJuegosController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: VideoJuegosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoJuegosController/Create
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

        // GET: VideoJuegosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VideoJuegosController/Edit/5
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

        // GET: VideoJuegosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VideoJuegosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
