using Microsoft.AspNetCore.Mvc;
using Persistencia.Context;
using Persistencia.DAL.Entidades;

namespace GestaoFinanceira.Controllers
{
    public class DashboardController : Controller
    {

        private readonly ReceitaDAL _receita;
        private readonly DespesaDAL _despesa;

        public DashboardController(EFContext context)
        {
            _receita = new ReceitaDAL(context);
            _despesa = new DespesaDAL(context);
        }

        public IActionResult Index()
        {
            int mes = 3;
            int ano = 2020;
            ViewBag.somaReceitaMensal = _receita.ObterSomaReceitaMensal(mes, ano);
            ViewBag.somaDespesaMensal = _despesa.ObterSomaDespesaMensal(mes, ano);
            return View();
        }
    }
}