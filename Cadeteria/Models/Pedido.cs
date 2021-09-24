using System;
using System.Collections.Generic;
using System.Text;

namespace Cadeteria.Models
{

	public enum Estado 
	{
		Pendiente = 0,
		Entregado = 1
	}

	public class Pedido
	{
		private int nro;
		private Estado estado;
		private Cliente cliente;
		private string observaciones;

		public int Nro { get => nro; set => nro = value; }
		public Estado Estado { get => estado; set => estado = value; }
		public string Observaciones { get => observaciones; set => observaciones = value; }
		public Cliente Cliente { get => cliente; set => cliente = value; }

		public Pedido(int nro, string observaciones, string nombre, string direccion, double telefono)
		{
			this.nro = nro ;
			this.estado = Estado.Pendiente;
			this.cliente = new Cliente(nombre,direccion,telefono);
			this.observaciones = observaciones;
		}
	}
}
