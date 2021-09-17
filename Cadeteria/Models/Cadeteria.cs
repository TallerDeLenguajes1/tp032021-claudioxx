using System;
using System.Collections.Generic;
using System.Text;

namespace Cadeteria.Models
{ 
	class Cadeteria
	{
		private string nombre;
		private List<Cadete> cadetes;

		public Cadeteria(string nombre)
		{
			this.nombre = nombre;
			this.cadetes = new List<Cadete>();
		}

		public string Nombre { get => nombre; set => nombre = value; }
		internal List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }

		public void mostrarCadetes()
		{
			int cont = 1;
			Console.WriteLine("****CADETES****");
			foreach(Cadete unCadete in cadetes)
			{	
				Console.WriteLine(cont+": ");
				unCadete.mostrar();
				cont++;
			}
		}
	}
}
