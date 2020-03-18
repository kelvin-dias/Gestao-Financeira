using Persistencia.Context;
using System.Linq;

namespace Persistencia.DAL.Servico
{
    public class TransacaoDAL
    {
        private readonly EFContext _context;

        public TransacaoDAL(EFContext context)
        {
            _context = context;
        }

        public IQueryable ObterTransacoesOrdenadasPorData()
        {
            return _context.Receitas.Select(r => new { r.Valor, r.Pago, r.Descricao, r.DataHora })
                    .Concat(_context.Despesas.Select(d => new { d.Valor, d.Pago, d.Descricao, d.DataHora })
                    .OrderBy(x=> x.DataHora));
        }
    }
}
