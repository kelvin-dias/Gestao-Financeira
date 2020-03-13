using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Cartao
    {
        public int CartaoId { get; set; }
        public string Nome { get; set; }
        public string BandeiraCartao { get; set; }
        public decimal Limite { get; set; }
    }
}
