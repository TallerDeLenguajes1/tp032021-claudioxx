using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Controllers
{
	public class PedidosController : Controller
	{
		private static List<Pedido> pedidos = new List<Pedido>();

		public IActionResult Index()
		{
			return View(pedidos);
		}

		public IActionResult CrearPedido(string nombre, string direccion, double telefono, string observaciones)
		{
			Pedido unPedido = new Pedido(observaciones,nombre,direccion,telefono);
			if (nombre != null && direccion != null && observaciones != null)
			{
				pedidos.Add(unPedido);
				return Redirect("Index");
			}
			return View();
		}
	}
}
