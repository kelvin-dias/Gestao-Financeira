using Microsoft.AspNetCore.Mvc;
using Persistencia.Context;
using Persistencia.DAL.Entidades;
using Servico.Entidades;
using System;

namespace GestaoFinanceira.Controllers
{
    public class TransacoesController : Controller
    {
        private readonly TransacoesServico transacaoServico;

        public TransacoesController(EFContext context)
        {
            transacaoServico = new TransacoesServico(context);
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ObterTransacoes(string tipo)
        {
            try
            {
                switch (tipo)
                {
                    case "receita":
                        var receitas = transacaoServico.ObterReceitasOrdenadasPorData();
                        return Json(receitas);

                    case "despesa":
                        var despesas = transacaoServico.ObterDespesasOrdenadasPorData();

                        return Json(despesas);

                    case "transacoes":
                        var transacoes = transacaoServico.ObterTransacoesOrdenadasPorData();

                        return Json(transacoes);

                    default:
                        return Json("[Erro]" + "Ocorreu um erro Interno!");
                }

            }
            catch (Exception ex)
            {
                return Json("[Erro]" + ex.Message);
            }

        }
    }
}