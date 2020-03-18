using Modelo.Entidades;
using Persistencia.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.DAL.Entidades
{
    public class DespesaDAL
    {
        private readonly EFContext _context;

        public DespesaDAL(EFContext context)
        {
            _context = context;
        }

        public async Task GravarDespesa(Despesa despesa)
        {
            if (despesa.Id == null)
            {
                _context.Despesas.Add(despesa);
            }
            else
            {
                _context.Update(despesa);
            }

            await _context.SaveChangesAsync();
        }

        public decimal ObterSomaDespesaMensal(int mes, int ano)
        {
            return _context.Despesas.Where(x => x.DataHora.Month == mes && x.DataHora.Year == ano).Sum(x => x.Valor);
        }

        public IQueryable<Despesa> ObterDespesasOrdenadasPorData(int mes)
        {
            return _context.Despesas
                           .Where(x => x.DataHora.Month == mes && x.DataHora.Year == DateTime.Now.Year)
                           .OrderBy(b => b.DataHora);
        }

        public IQueryable<Despesa> ObterDespesasOrdenadasPorData()
        {
            return _context.Despesas.OrderBy(b => b.DataHora);
        }
    }
}
