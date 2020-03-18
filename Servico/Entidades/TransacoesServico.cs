using Modelo.Entidades;
using Persistencia.Context;
using Persistencia.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Persistencia.DAL.Servico;

namespace Servico.Entidades
{
    public class TransacoesServico
    {
        private readonly ReceitaDAL receitaDAL;
        private readonly DespesaDAL despesaDAL;
        private readonly TransacaoDAL transacaoDAL;

        public TransacoesServico(EFContext context)
        {
            receitaDAL = new ReceitaDAL(context);
            despesaDAL = new DespesaDAL(context);
            transacaoDAL = new TransacaoDAL(context);
        }

        public IQueryable<Receita> ObterReceitasOrdenadasPorData()
        {
            return receitaDAL.ObterReceitasOrdenadasPorData();
        }

        public IQueryable<Despesa> ObterDespesasOrdenadasPorData()
        {
            return despesaDAL.ObterDespesasOrdenadasPorData();
        }

        public IQueryable ObterTransacoesOrdenadasPorData()
        {
            return transacaoDAL.ObterTransacoesOrdenadasPorData();
        }



    }
}
