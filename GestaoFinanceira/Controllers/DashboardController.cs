using Microsoft.AspNetCore.Mvc;
using Persistencia.Context;
using Persistencia.DAL.Entidades;
using Servico.Entidades;

namespace GestaoFinanceira.Controllers
{
    public class DashboardController : Controller
    {

        private readonly ReceitaDAL _receita;

        public DashboardController(EFContext context)
        {
            _receita = new ReceitaDAL(context);
        }

        public IActionResult Index()
        {
            int mes = 3;
            int ano = 2020;
            ViewBag.somaReceitaMensal = _receita.ObterSomaReceitaMensal(mes, ano);
            return View();
        }
    }
}