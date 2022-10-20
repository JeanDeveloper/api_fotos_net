using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using ApiSolgisFotos.Context;
using ApiSolgisFotos.Models;
using ApiSolgisFotos.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ApiSolgisFotos.Controllers
{
    [Route("api/[controller]")]
    public class FotoController : Controller
    {

        public readonly AppDbContext context;

        public FotoController(AppDbContext context)
        {
            this.context = context;
        }


        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.MOVIMIENTOS_FOTOS.ToList());
            }catch(Exception ex)
            {

                Console.WriteLine(ex.InnerException.Message);
                return BadRequest(ex.Message);
            }
        }


        // POST: api/<controller>
        [HttpPost]

        public async Task<Response> Post([FromForm]Request request)
        {

            try
            {

                Fotos foto = new Fotos();


                if (request.file.Length > 0)

                {
                    String filePath = "";

                    if (request.datoAcceso == 1)
                    {
                        filePath = "D:\\net\\ApiSolgisFotos\\ApiSolgisFotos\\Fotos\\Guia\\" + request.file.FileName;
                    }
                    else
                    {
                        filePath = "D:\\net\\ApiSolgisFotos\\ApiSolgisFotos\\Fotos\\Material\\" + request.file.FileName;
                    }


                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await request.file.CopyToAsync(stream);
                        //System.IO.File.Move(filePath, filePathCodMov);
                        stream.Flush();
                    }

                    double tamanio = request.file.Length;
                    tamanio = tamanio / 1000000;
                    tamanio = Math.Round(tamanio, 2);

                    foto.foto_mov_id = request.cod_movimiento;
                    foto.extension = Path.GetExtension(request.file.FileName).Substring(1);
                    foto.nombre = Path.GetFileNameWithoutExtension(request.file.FileName);
                    foto.tamanio = tamanio;
                    foto.ubicacion = filePath;

                    var parameters = new
                    {
                        cod_movimiento = request.cod_movimiento,
                        nombre = foto.nombre,
                        extension = foto.extension,
                        datoAcceso = request.datoAcceso,
                        tamanio = tamanio,
                        ubicacion = foto.ubicacion,
                        creado_por = request.creado_por
                    };
                    const string query =
                        "EXECUTE CONTROLCLIENTES2018.dbo.AppSolgis_Insertar_foto @cod_movimiento, @nombre, @extension, @datoAcceso, @tamanio, @ubicacion, @creado_por;";

                    using (var connection = BdConnection.GetConnection())
                    {
                        connection.Query(query, parameters);

                    }

                }


                return new Response
                {
                    message = "Guardado",
                    status = 1

                };


                //return Ok(foto);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex.InnerException.Message);
                throw;

                // return BadRequest(ex.Message);

                //return BadRequest(ex.Message);
            }

        }


    }



}
