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
		private readonly DBTemporal _DB;

		public PedidosController(DBTemporal DB)
		{
			_DB = DB;
		}

		public IActionResult Index()
		{
			return View(_DB.cadeteria);
		}

		public IActionResult CrearPedido(string nombre, string direccion, double telefono, string observaciones, int idCadete)
		{
			if (nombre != null && direccion != null && observaciones != null)
			{
				Pedido unPedido = new Pedido(_DB.cadeteria.Pedidos.Count() + 1, observaciones, nombre, direccion, telefono);
				_DB.cadeteria.Pedidos.Add(unPedido);
				Cadete unCadete = _DB.cadeteria.Cadetes.Find(a => a.Id == idCadete);
				if (unCadete != null)
				{
					unCadete.Pedidos.Add(unPedido);
				}
				_DB.guardarPedidos(_DB.cadeteria.Pedidos);
				return Redirect("Index");
			}
			return View(_DB.cadeteria.Cadetes);
		}

		public IActionResult AsignarCadeteAPedido(int IdCadete,int IdPedido)
		{
			if (IdCadete != 0 && IdPedido != 0)
			{
				QuitarPedidoACadete(IdPedido);
				Cadete unCadete = _DB.cadeteria.Cadetes.Find(a => a.Id == IdCadete);
				Pedido unPedido = _DB.cadeteria.Pedidos.Find(a => a.Nro == IdPedido);
				if(!unCadete.Pedidos.Exists(a => a.Nro == IdPedido))
				{
					unCadete.Pedidos.Add(unPedido);
				}
			}
			return Redirect("Index");
		}

		private void QuitarPedidoACadete (int IdPedido)
		{
			Cadete CadeteaQuitarPedido = _DB.cadeteria.Cadetes.Find(unCadete => unCadete.Pedidos.Exists(unPedido => unPedido.Nro == IdPedido));
			if(CadeteaQuitarPedido != null)
			{
				CadeteaQuitarPedido.Pedidos.Remove(_DB.cadeteria.Pedidos.Find(unPedido => unPedido.Nro == IdPedido));
			}
		}


	}
}
