using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using Newtonsoft.Json;
using Persistencia.Context;
using Persistencia.DAL.Entidades;

namespace GestaoFinanceira.Controllers
{
    public class ReceitaController : Controller
    {
        private readonly ReceitaDAL receitaDAL;

        public ReceitaController(EFContext context)
        {
            receitaDAL = new ReceitaDAL(context);
        }

        [HttpPost]
        public async Task<string> GravarReceita(Receita objeto)
        {
            try
            {
                await receitaDAL.GravarReceita(objeto);

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

