using SARSOAPService.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SARSOAPService.Persistencia
{
    public class EquipoDAO
    {

        private string CadenaConexion = "Data Source=(local);Initial Catalog=SAR; Integrated Security=SSPI;";


        public Equipo Crear(Equipo equipoACrear)
            {
                Equipo equipoCreado = null;
                string sql = "INSERT INTO equipos VALUES (@nu_serie, @modelo, @caracteris, @estado, @fecha_compra)";
                using (SqlConnection conexion = new SqlConnection(CadenaConexion))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand (sql,conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@nu_serie", equipoACrear.Nu_serie));
                        comando.Parameters.Add(new SqlParameter("@modelo", equipoACrear.Modelo));
                        comando.Parameters.Add(new SqlParameter("@caracteris", equipoACrear.Caracteris));
                        comando.Parameters.Add(new SqlParameter("@estado", equipoACrear.Estado));
                        comando.Parameters.Add(new SqlParameter("@fecha_compra", equipoACrear.Fecha_compra));
                        comando.ExecuteNonQuery();
                    }
                }
                equipoCreado = Obtener(equipoACrear.Nu_serie);
                return equipoCreado;

            }
        public Equipo Obtener(string nu_serie)

        {
            Equipo equipoEncontrado = null;
            string sql = "SELECT * FROM equipos where nu_serie=@nu_serie";
            using(SqlConnection conexion= new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql,conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@nu_serie", nu_serie));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                    if (resultado.Read())
                    {
                        equipoEncontrado = new Equipo()
                            {
                                Nu_serie = (string)resultado["nu_serie"],
                                Modelo = (string)resultado["modelo"],
                                Caracteris = (string)resultado["caracteris"],
                                Estado = (string)resultado["estado"],
                                Fecha_compra = (string)resultado["fecha_compra"]

                            };

                    }
                    }

                }
            
            }

            return equipoEncontrado;
        }
        public Equipo Modificar(Equipo equipoAModificar)
        {
            Equipo equipoModificado = null;

            string sql = "UPDATE EQUIPOS SET modelo=@modelo, caracteris=@caracteris, estado=@estado, fecha_compra=@fecha_compra where nu_serie=@nu_serie";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql,conexion))
                {
                    
                    comando.Parameters.Add(new SqlParameter("@modelo", equipoAModificar.Modelo));
                    comando.Parameters.Add(new SqlParameter("@caracteris", equipoAModificar.Caracteris));
                    comando.Parameters.Add(new SqlParameter("@estado", equipoAModificar.Estado));
                    comando.Parameters.Add(new SqlParameter("@fecha_compra", equipoAModificar.Fecha_compra));
                    comando.Parameters.Add(new SqlParameter("@nu_serie", equipoAModificar.Nu_serie));
                    comando.ExecuteNonQuery();
                }
            }

            equipoModificado = Obtener(equipoAModificar.Nu_serie);
            return equipoModificado;
        }

        public void Eliminar(string nu_serie)
        {
            string sql = "DELETE FROM equipos where nu_serie=@nu_serie";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand (sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@nu_serie", nu_serie));
                    comando.ExecuteNonQuery();

                }


            }


        }

        public List<Equipo> Listar()
        {
            List<Equipo> equiposEncontrados = new List<Equipo>();
            Equipo equipoEncontrado = null;

            string sql = "SELECT * from EQUIPOS where ESTADO='STK'";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {

                            equipoEncontrado = new Equipo()

                            {
                                Nu_serie = (string)resultado["nu_serie"],
                                Modelo = (string)resultado["modelo"],
                                Caracteris = (string)resultado["caracteris"],
                                Estado = (string)resultado["estado"],
                                Fecha_compra = (string)resultado["fecha_compra"]


                            };
                            equiposEncontrados.Add(equipoEncontrado);
                        }
                    }
                }

            }
            return equiposEncontrados;
        }

        public List<Equipo> ListarEnStock()
        {
            List<Equipo> equiposEncontrados = new List<Equipo>();
            Equipo equipoEncontrado = null;
           
            string sql = "SELECT * from EQUIPOS where ESTADO='STK'";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql,conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {

                            equipoEncontrado = new Equipo()

                            {
                                Nu_serie = (string)resultado["nu_serie"],
                                Modelo = (string)resultado["modelo"],
                                Caracteris = (string)resultado["caracteris"],
                                Estado = (string)resultado["estado"],
                                Fecha_compra = (string)resultado["fecha_compra"]


                            };
                            equiposEncontrados.Add(equipoEncontrado);
                        }
                    }
                }
                
            }
            return equiposEncontrados; 
        }

    }
}