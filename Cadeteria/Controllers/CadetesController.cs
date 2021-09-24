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

		public CadetesController(DBTemporal DB)
		{
			_DB = DB;
		}

		public IActionResult Index()
		{
			return View(_DB.cadeteria.Cadetes);
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
	}
}
