using System;
using System.Collections.Generic;
using System.Text;

namespace Cadeteria.Models
{
	public class Cliente
	{
		private static int id_cliente = 0;
		private int id;
		private string nombre;
		private string direccion;
		private double Telefono;


		public Cliente(string nombre, string direccion, double telefono)
		{
				this.id = id_cliente + 1;
				this.Nombre = nombre;
				this.Direccion = direccion;
				this.Telefono1 = telefono;
		}

		public int Id { get => id; set => id = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public string Direccion { get => direccion; set => direccion = value; }
		public double Telefono1 { get => Telefono; set => Telefono = value; }
	}
}
