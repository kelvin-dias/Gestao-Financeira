using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modelo.Entidades;
using Newtonsoft.Json;
using Persistencia.Context;
using Persistencia.DAL.Entidades;

namespace GestaoFinanceira.Controllers
{
    public class DespesaController : Controller
    {
        private readonly DespesaDAL despesaDAL;

        public DespesaController(EFContext context)
        {
            despesaDAL = new DespesaDAL(context);
        }

        [HttpPost]
        public async Task<string> GravarDespesa(Despesa objeto)
        {
            try
            {
                await despesaDAL.GravarDespesa(objeto);
                return JsonConvert.SerializeObject(new
                {
                    OK = "true"
                });
            }
            catch (Exception ex)
            {
                return "[Erro]" + ex.Message;
            }

        }
    }
}