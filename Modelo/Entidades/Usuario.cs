using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
		public string Login { get; set; }
		public string Senha { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public DateTime? DhTimestamp { get; set; }
		public bool? Status { get; set; }
	}
}
