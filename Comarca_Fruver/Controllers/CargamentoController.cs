using Comarca_Fruver.Data;
using Comarca_Fruver.Models;
using Microsoft.AspNetCore.Mvc;

namespace Comarca_Fruver.Controllers
{
    public class CargamentoController : Controller
    {
        private readonly AppDbContext _context;

        public CargamentoController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Listado()
        {
            IEnumerable<Cargamento> ListaCargamento = _context.cargamentos;
            return View(ListaCargamento);
        }


        public int Existencia(int NumeroPedido)
        {
            int Coincidencia = 0;

            IEnumerable<Cargamento> ListaCargamento = _context.cargamentos;

            foreach (var item in ListaCargamento)
            {
                if (item.NumeroPedido == NumeroPedido)
                {
                    Coincidencia += 1;
                }
            }

            return Coincidencia;
        }

        public IActionResult Creacion()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creacion(Cargamento Carga)
        {
            int NumeroPedid = Carga.NumeroPedido;
            int Coincidencia = Existencia(NumeroPedid);

            if (ModelState.IsValid && Coincidencia < 1)
            {
                _context.cargamentos.Add(Carga);
                _context.SaveChanges();
                TempData["mensaje"] = "Nuevo cargamento registrado";
                return RedirectToAction("Listado");
            }
            else
            {
                TempData["mensaje"] = "El número de pedido "+NumeroPedid+" ya existe";
                return RedirectToAction("Listado");
            }

        }

        public IActionResult Edicion(int? id)
        {

            if (id == null || id == 0)
            {
                TempData["mensaje"] = "Este item no fue encontrado en los registros";
                return RedirectToAction("Listado");
            }

            var CargamentoPrevio = _context.cargamentos.Find(id);

            if (CargamentoPrevio == null)
            {
                return NotFound();
            }

            return View(CargamentoPrevio);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edicion(Cargamento Carga)
        {

            if (ModelState.IsValid)
            {
                _context.cargamentos.Update(Carga);
                _context.SaveChanges();
                TempData["mensaje"] = "Cargamento Modificado";
                return RedirectToAction("Listado");
            }
            else
            {
                TempData["mensaje"] = "Problema en la transmisión de la información hacía la nube ";
                return RedirectToAction("Listado");
            }

        }

        public IActionResult Elimina(int? id)
        {
            var Cargamento = _context.cargamentos.Find(id);

            TempData["mensaje"] = "El registro con número de pedido " + Cargamento.NumeroPedido + " fue eliminado";
            _context.Remove(Cargamento);           
            _context.SaveChanges();
            return RedirectToAction("Listado");
        }



    }

}

