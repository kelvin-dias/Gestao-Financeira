using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Receita
    {
        public long? ReceitaId { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public bool Pago { get; set; }
        public bool ReceitaFixa { get; set; }
        public bool ReceitaParcelada { get; set; }
        public int? QtdParcelas { get; set; }
        public string Observacao { get; set; }
        public DateTime DhReceita { get; set; }
    }
}
