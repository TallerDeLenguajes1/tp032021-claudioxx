using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cadeteria.Models
{
	public class DBTemporal
	{

		public Cadeteria cadeteria { get; set; }

		public DBTemporal()
		{
			cadeteria = new Cadeteria();
			if (cargarCadetes() != null) 
			{
				cadeteria.Cadetes = cargarCadetes();
			}
			if (cargarPedidos() != null)
			{
				cadeteria.Pedidos = cargarPedidos();
			}
		}

		public void guardarCadetes(List<Cadete> cadetes)
		{
			try
			{
				string _path = @"Cadetes";
				string cadetesJson = JsonSerializer.Serialize(cadetes,new JsonSerializerOptions { WriteIndented = true });
				using (FileStream miArchivo = new FileStream(_path, FileMode.Create))
				{
					using (StreamWriter strWriter = new StreamWriter(miArchivo))
					{
						strWriter.WriteLine(cadetesJson);
						strWriter.Close();
						strWriter.Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public List<Cadete> cargarCadetes()
		{
			List<Cadete> cadetesJson = null;
			try
			{ 
				string _path = @"Cadetes";
				if (File.Exists(_path))
				{
					using (FileStream miArchivo = new FileStream(_path,FileMode.Open))
					{
						using (StreamReader strReader = new StreamReader(miArchivo))
						{
							string strCadetes = strReader.ReadToEnd();
							
							cadetesJson = JsonSerializer.Deserialize<List<Cadete>>(strCadetes);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return (cadetesJson);
		}

		public void guardarPedidos(List<Pedido> pedidos)
		{
			try
			{
				string _path = @"Pedidos";
				string pedidosJson = JsonSerializer.Serialize(pedidos,new JsonSerializerOptions { WriteIndented = true });
				using (FileStream miArchivo = new FileStream(_path, FileMode.OpenOrCreate))
				{
					using (StreamWriter strWriter = new StreamWriter(miArchivo))
					{
						strWriter.WriteLine(pedidosJson);
						strWriter.Close();
						strWriter.Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public List<Pedido> cargarPedidos()
		{
			List<Pedido> pedidosJson = null;
			try
			{
				string _path = @"Pedidos";
				if (File.Exists(_path))
				{
					using (FileStream miArchivo = new FileStream(_path, FileMode.Open))
					{
						using (StreamReader strReader = new StreamReader(miArchivo))
						{
							string strPedidos = strReader.ReadToEnd();

							pedidosJson = JsonSerializer.Deserialize<List<Pedido>>(strPedidos);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return (pedidosJson);
		}	
	}
}
