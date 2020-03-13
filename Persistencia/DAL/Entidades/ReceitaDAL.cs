using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using Persistencia.Context;
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
            if (receita.ReceitaId == null)
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
            return _context.Receitas.Where(x => x.DhReceita.Month == mes && x.DhReceita.Year == ano).Sum(x => x.Valor);
        }

    }
}
