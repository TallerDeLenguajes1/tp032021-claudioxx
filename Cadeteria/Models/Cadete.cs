using System;
using System.Collections.Generic;
using System.Text;

namespace Cadeteria.Models
{
	public class Cadete
	{
		private int id;
		private string nombre;
		private string direccion;
		private double telefono;
		private List<Pedido> pedidos;
		private double jornal;

		public Cadete(int id, string nombre, string direccion, double telefono)
		{
			this.id = id;
			this.nombre = nombre;
			this.direccion = direccion;
			this.telefono = telefono;
			this.Pedidos = new List<Pedido>();
		}

		public int Id { get => id; set => id = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public string Direccion { get => direccion; set => direccion = value; }
		public double Telefono { get => telefono; set => telefono = value; }
		public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

		public void agregarPedido(Pedido unPedido)
		{
			Pedidos.Add(unPedido);
		}

		public void mostrar()
		{
			Console.WriteLine("ID: " + this.id);
			Console.WriteLine("Nombre: " +this.nombre);
			Console.WriteLine("Pedidos entregados: " + cantidadPedidosEntregado());
			Console.WriteLine("Jornal: $" +calcularJornal()+ "\n");
		}

		public int cantidadPedidosEntregado()
		{
			int cantEntregado=0;
			foreach (Pedido unpedido in Pedidos)
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
			this.jornal = 100 * cantidadPedidosEntregado();
			return this.jornal;
		}

	}
}
