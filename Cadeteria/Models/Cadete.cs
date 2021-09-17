using System;
using System.Collections.Generic;
using System.Text;

namespace Cadeteria.Models
{
	public class Cadete
	{
		private static int id_cadete = 0;
		private int id;
		private string nombre;
		private string direccion;
		private double telefono;
		private List<Pedido> pedidos;
		private double jornal;

		public Cadete(string nombre, string direccion, double telefono)
		{
			this.id = id_cadete + 1;
			this.nombre = nombre;
			this.direccion = direccion;
			this.telefono = telefono;
			this.pedidos = new List<Pedido>();
		}

		public int Id { get => id; set => id = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public string Direccion { get => direccion; set => direccion = value; }
		public double Telefono { get => telefono; set => telefono = value; }
		internal List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

		public void agregarPedido(Pedido unPedido)
		{
			pedidos.Add(unPedido);
		}

		public void mostrar()
		{
			Console.WriteLine("ID: " + this.id);
			Console.WriteLine("Nombre: " +this.nombre);
			Console.WriteLine("Pedidos entregados: " + cantPedidoEntregado());
			Console.WriteLine("Jornal: $" +calcularJornal()+ "\n");
		}

		public int cantPedidoEntregado()
		{
			int cantEntregado=0;
			foreach (Pedido unpedido in pedidos)
			{
				if(unpedido.Estado == Estado.Entregado)
				{
					cantEntregado++;
				}
			}
			return cantEntregado;
		}

		public double calcularJornal()
		{
			this.jornal = 100 * cantPedidoEntregado();
			return this.jornal;
		}

	}
}
