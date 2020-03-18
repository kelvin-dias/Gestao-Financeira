using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using Persistencia.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.DAL.Entidades
{
    public class ReceitaDAL
    {
        private readonly EFContext _context;

        public ReceitaDAL(EFContext context)
        {
            _context = context;
        }

        public async Task GravarReceita(Receita receita)
        {
            if (receita.Id == null)
            {
                _context.Receitas.Add(receita);
            }
            else
            {
                _context.Update(receita);
            }

            await _context.SaveChangesAsync();
        }

        public decimal ObterSomaReceitaMensal(int mes, int ano)
        {
            return _context.Receitas.Where(x => x.DataHora.Month == mes && x.DataHora.Year == ano).Sum(x => x.Valor);
        }

        public IQueryable<Receita> ObterReceitasOrdenadasPorData(int mes)
        {
            return _context.Receitas
                           .Where(x => x.DataHora.Month == mes && x.DataHora.Year == DateTime.Now.Year)
                           .OrderBy(b => b.DataHora);
        }

        public IQueryable<Receita> ObterReceitasOrdenadasPorData()
        {
            return _context.Receitas.OrderBy(b => b.DataHora);
        }


    }
}
