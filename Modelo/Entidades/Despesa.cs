using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Despesa
    {
        public long? Id { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public bool Pago { get; set; }
        public bool DespesaFixa { get; set; }
        public bool DespesaParcelada { get; set; }
        public int? QtdParcelas { get; set; }
        public string Observacao { get; set; }
        public DateTime DataHora { get; set; }
    }
}
