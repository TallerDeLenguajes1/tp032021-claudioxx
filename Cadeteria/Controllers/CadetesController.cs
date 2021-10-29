using Cadeteria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadeteria.Controllers
{
	public class CadetesController : Controller
	{
		private readonly DBTemporal _DB;
		private readonly List<Cadete> _RepoCadetes;

		public CadetesController(DBTemporal DB,List<Cadete> RepoCadetes)
		{
			_DB = DB;
			_RepoCadetes = RepoCadetes;
		}

		public IActionResult Index()
		{
			return View(_RepoCadetes);
		}

		public IActionResult CrearCadete(string nombre, string direccion, double telefono)
		{
			if (nombre != null && direccion != null)
			{
				Cadete unCadete = new Cadete(_DB.cadeteria.Cadetes.Count()+1, nombre, direccion, telefono);
				_DB.cadeteria.Cadetes.Add(unCadete);
				_DB.guardarCadetes(_DB.cadeteria.Cadetes);
				return Redirect("Index");
			}
			return View();
		}

		public IActionResult SelectCadeteAEditar(int IdCadete)
		{
			Cadete unCadete = _DB.cadeteria.Cadetes.Find(unCadete => unCadete.Id == IdCadete);
			return View(unCadete);
		}

		public IActionResult EditarCadete(string nombre, string direccion, double telefono,int IdCadete)
		{
			Cadete CadeteAModificar = _DB.cadeteria.Cadetes.Find(unCadete => unCadete.Id == IdCadete);

			if (nombre != null && direccion != null && CadeteAModificar != null)
			{
				CadeteAModificar.Nombre = nombre;
				CadeteAModificar.Direccion = direccion;
				CadeteAModificar.Telefono = telefono;
				_DB.guardarCadetes(_DB.cadeteria.Cadetes);
			}
			return Redirect("Index");
		}

		public IActionResult EliminarCadete(int IdCadete)
		{
			Cadete unCadete = _DB.cadeteria.Cadetes.Find(unCadete => unCadete.Id == IdCadete);
			if (unCadete != null)
			{
				_DB.cadeteria.Cadetes.Remove(unCadete);
				_DB.guardarCadetes(_DB.cadeteria.Cadetes);
			}
			return Redirect("Index");
		}
	}
}
