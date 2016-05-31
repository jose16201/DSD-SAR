using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EquipoService.Dominio;
using System.Data.SqlClient;

namespace EquipoService.Persistencia
{
    public class RegistroDAO
    {
        /*public Registro Crear(Registro equipoACrear)
        {
            Registro equipoCreado = null;
            string sql = "INSERT INTO RENIEC VALUES (@dni, @serie, )";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@dni", equipoACrear.dni));
                    com.Parameters.Add(new SqlParameter("@serie", equipoACrear.nombre));
                    com.Parameters.Add(new SqlParameter("@serie", equipoACrear.nombre));
                    com.ExecuteNonQuery();
                }
            }
            equipoCreado = Obtener(equipoACrear.dni);
            return equipoCreado;
            
        }*/
        public Registro Obtener(string dni)
        {
            Registro equipoEncontrado = null;
            string sql = "SELECT * FROM RENIEC WHERE dni=@dni";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@dni", dni));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            equipoEncontrado = new Registro()
                            {
                                dni = (string)resultado["dni"],
                                nombre = (string)resultado["nombre"],
                                fecha_nacimiento = (string)resultado["fecha_nacimiento"]
                            };
                        }
                    }
                }
            }
            return equipoEncontrado;
        }
     /*   public Equipo Modificar(Equipo equipoAModificar)
        {
            Equipo equipoModificado = null;
            string sql = "UPDATE EQUIPO SET modelo=@modelo where serie=@serie";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {

                    comando.Parameters.Add(new SqlParameter("@modelo", equipoAModificar.modelo));
                    comando.Parameters.Add(new SqlParameter("@serie", equipoAModificar.serie));
                    comando.ExecuteNonQuery();
                }

            
            }

            equipoModificado = Obtener(equipoAModificar.serie);
            return equipoModificado;
        }
        public void Eliminar(string serie)
        {
            string sql = "DELETE FROM EQUIPO  where nu_serie=@serie";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {


                    comando.Parameters.Add(new SqlParameter("@serie", serie));
                    comando.ExecuteNonQuery();
                }


            }
        }
        public List<Equipo> ListarTodos()
        {

            List<Equipo> equiposEncontrados = new List<Equipo>();
            Equipo equipoEncontrado = null;

             string sql = "UPDATE EQUIPO SET modelo=@modelo where nu_serie=@serie";
             using (SqlConnection conexion = new SqlConnection(ConexionUtil.Cadena))
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

                                 serie = (string)resultado["serie"],
                                 modelo = (string)resultado["modelo"]
                             };
                             equiposEncontrados.Add(equipoEncontrado);
                         }
                     
                     }


                 }

             }

             return equiposEncontrados;
        }


        */


    }
}