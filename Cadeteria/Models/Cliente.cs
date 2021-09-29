using System;
using System.Collections.Generic;
using System.Text;

namespace Cadeteria.Models
{
	public class Cliente
	{
		//private static int id_cliente = 0;
		private int id;
		private string nombre;
		private string direccion;
		private double telefono;


		public int Id { get => id; set => id = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public string Direccion { get => direccion; set => direccion = value; }
		public double Telefono { get => telefono; set => telefono = value; }

		public Cliente(int id, string nombre, string direccion, double telefono)
		{
				this.Id = id;
				this.Nombre = nombre;
				this.Direccion = direccion;
				this.Telefono = telefono;
		}

		public Cliente() { }
	}
}
