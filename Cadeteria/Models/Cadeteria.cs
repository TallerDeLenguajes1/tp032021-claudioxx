using System;
using System.Collections.Generic;
using System.Text;

namespace Cadeteria.Models
{ 
	public class Cadeteria
	{
		private List<Pedido> pedidos;
		private List<Cadete> cadetes;

		public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }
		public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }

		public Cadeteria()
		{
			Pedidos = new List<Pedido>();
			Cadetes = new List<Cadete>();
		}

	}
}
