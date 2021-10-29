using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Cadeteria.Models
{
    public class RepositorioCadete
    {

        private readonly string connectionString;
        private readonly SQLiteConnection conexion;

        public RepositorioCadete(string connectionString){
            this.connectionString = connectionString;
        }

        public List<Cadete> ConseguiRCadetes(){
            List<Cadete> Cadetes = new List<Cadete>();
            using(SQLiteConnection conexion = new SQLiteConnection(connectionString)){
                conexion.Open();
                var SQLQuery = "SELECt * FROM Cadetes";
                SQLiteCommand command = new SQLiteCommand(SQLQuery,conexion);
                using (SQLiteDataReader dreader = command.ExecuteReader()){
                    while(dreader.Read()){
                        Cadete unCadete = new Cadete();
                        unCadete.Id = Convert.ToInt32(dreader["cadeteID"]);
                        unCadete.Nombre = dreader["cadeteNombre"].ToString();
                        unCadete.Telefono = Convert.ToDouble(dreader["cadeteTelefono"]);
                        unCadete.Direccion = dreader["cadeteDireccion"].ToString();
                        Cadetes.Add(unCadete);
                    }
                }
                conexion.Close();
            }
            return Cadetes;
        }
    }
}