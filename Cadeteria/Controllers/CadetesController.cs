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
		private static List<Cadete> cadetes = new List<Cadete>();

		public IActionResult Index()
		{
			return View(cadetes);
		}

		public IActionResult CrearCadete(string nombre, string direccion, double telefono)
		{
			Cadete unCadete = new Cadete(nombre, direccion, telefono);
			if (nombre != null && direccion != null)
			{
				cadetes.Add(unCadete);
				return Redirect("Index");
			}
			return View();
		}
	}
}
