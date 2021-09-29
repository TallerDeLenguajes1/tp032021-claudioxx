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

		public Pedido(int nro, string observaciones,int id,string nombre,string direccion,double telefono)
		{
			this.Nro = nro ;
			this.Estado = Estado.Pendiente;
			this.Cliente = new Cliente(id,nombre,direccion,telefono);
			this.Observaciones = observaciones;
		}

		public Pedido() { }
	}
}
