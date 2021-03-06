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

		public IActionResult CrearPedido(string nombre, string direccion, double telefono, string observaciones, int idCadete, int dni)
		{
			if (nombre != null && direccion != null && observaciones != null)
			{
				//Cliente unCliente = new Cliente(dni, nombre,direccion,telefono);
				Pedido unPedido = new Pedido(_DB.cadeteria.Pedidos.Count() + 1, observaciones,dni,nombre,direccion,telefono);
				_DB.cadeteria.Pedidos.Add(unPedido);
				Cadete unCadete = _DB.cadeteria.Cadetes.Find(a => a.Id == idCadete);
				if (unCadete != null)
				{
					unCadete.Pedidos.Add(unPedido);
					_DB.guardarCadetes(_DB.cadeteria.Cadetes);
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
					_DB.guardarCadetes(_DB.cadeteria.Cadetes);
				}
			}
			return Redirect("Index");
		}

		private void QuitarPedidoACadete (int IdPedido)
		{
			Cadete CadeteaQuitarPedido = _DB.cadeteria.Cadetes.Find(unCadete => unCadete.Pedidos.Exists(unPedido => unPedido.Nro == IdPedido));
			if(CadeteaQuitarPedido != null)
			{
				Pedido PedidoAQuitar = _DB.cadeteria.Pedidos.Find(unPedido => unPedido.Nro == IdPedido);
				//Al parecer ni el metodo remove ni constains me funcionan luego de los objetos se creen en base al JSON, si o si 
				//debo usar metodos que reciban un predicado. :'/
				CadeteaQuitarPedido.Pedidos.RemoveAll(unPedido => unPedido.Nro == IdPedido);
			}
		}


	}
}
