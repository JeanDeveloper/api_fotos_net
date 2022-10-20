using ApiSolgisFotos.Models;
using ApiSolgisFotos.Utilidades;
using System;
using Dapper;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace ApiSolgisFotos.Repositorio
{
    public class FotoRepository
    {

      public static int InsertToDb(string cod_movimiento, string nombre, string extension, int datoAcceso, double tamanio, string ubicacion, string creado_por)
        {
            try
            {
                var parameters = new
                {
                    cod_movimiento = cod_movimiento,
                    nombre = nombre,
                    extension = extension,
                    datoAcceso = datoAcceso,
                    tamanio = tamanio,
                    ubicacion = ubicacion,
                    creado_por = creado_por
                };
                const string query =
                    "EXECUTE CONTROLCLIENTES2018.dbo.AppSolgis_Insertar_foto @cod_movimiento, @nombre, @extension, @tipo_datos_acceso, @tamanio, @ubicacion, @creado_por;";

                using (var connection = BdConnection.GetConnection())
                {
                    connection.Query(query, parameters);
                    
                }

                return Response.Save;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return Response.Error;
            }
        }




    }
}
