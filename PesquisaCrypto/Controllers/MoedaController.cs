using Microsoft.AspNetCore.Mvc;
using PesquisaCrypto.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisaCrypto.Controllers
{
    public class MoedaController : Controller
    {
        public IActionResult Index()
        {
            return View(Moeda.GetAll().AsEnumerable());
        }

        [HttpGet]
        public IActionResult InserirMoeda()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InserirMoeda(Moeda moeda)
        {
            if (ModelState.IsValid)
            {
                Moeda.InsertUpdate(moeda);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EscolhaMoedas(List<Moeda> moedas)
        {
            if (moedas != null)
            {
                foreach (var item in moedas)
                {
                    if (item.CheckBoxMarcado)
                    {
                        item.Quantidade++;
                        Moeda.InsertUpdate(item);
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult DadosGrafico()
        {
            return Json(Moeda.GetAll().Select(x => new { x.Nome, x.Quantidade }));
        }
    }
}
