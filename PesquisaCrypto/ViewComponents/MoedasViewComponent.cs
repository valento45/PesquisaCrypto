using Microsoft.AspNetCore.Mvc;
using PesquisaCrypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PesquisaCrypto.ViewComponents
{
    public class MoedasViewComponent : ViewComponent
    {
        private readonly IEnumerable<Moeda> _moedas;
        public MoedasViewComponent(IEnumerable<Moeda> moedas)
        {
            _moedas = moedas;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(Moeda.GetAll());
        }
    }
}
