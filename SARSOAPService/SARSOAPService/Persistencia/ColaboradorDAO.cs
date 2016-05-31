using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SARSOAPService.Dominio;
using System.Data.SqlClient;
using System.Configuration;

namespace SARSOAPService.Persistencia
{
    public class ColaboradorDAO
    {
        public Colaborador Crear(Colaborador colaboradorCrear)
        {
            Colaborador colaboradorCreado = null;
            string sql = "INSERT INTO T_COLABORADOR (COD_COLABORADOR, NOM_COLABORADOR, FEC_NACIMIENTO, FEC_INGRESO, CAR_COLABORADOR) VALUES (@cod_col, @nom_col, @fec_nac, @fec_col, @car_col)";
            using (SqlConnection conexion = new SqlConnection(new Util().CadenaConexión))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@cod_col", colaboradorCrear.codigo));
                    comando.Parameters.Add(new SqlParameter("@nom_col", colaboradorCrear.nombre));
                    comando.Parameters.Add(new SqlParameter("@fec_nac", colaboradorCrear.fechanacimiento));
                    comando.Parameters.Add(new SqlParameter("@fec_col", colaboradorCrear.ingreso));
                    comando.Parameters.Add(new SqlParameter("@car_col", colaboradorCrear.cargo));
                    comando.ExecuteNonQuery();
                }
            }
            colaboradorCreado = obtener(colaboradorCrear.codigo);
            return colaboradorCreado;
        }

        public Colaborador Modificar(Colaborador colaboradorModificar)
        {

            Colaborador colaboradormodificado = null;
            string sql = "UPDATE T_COLABORADOR Set  NOM_COLABORADOR=@nom_col, FEC_NACIMIENTO=@fec_nac, FEC_INGRESO=@fec_col, CAR_COLABORADOR=@car_col where COD_COLABORADOR=@cod_col";
            using (SqlConnection conexion = new SqlConnection(new Util().CadenaConexión))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@cod_col", colaboradorModificar.codigo));
                    comando.Parameters.Add(new SqlParameter("@nom_col", colaboradorModificar.nombre));
                    comando.Parameters.Add(new SqlParameter("@fec_nac", colaboradorModificar.fechanacimiento));
                    comando.Parameters.Add(new SqlParameter("@fec_col", colaboradorModificar.ingreso));
                    comando.Parameters.Add(new SqlParameter("@car_col", colaboradorModificar.cargo));
                    comando.ExecuteNonQuery();
                }
            }
            colaboradormodificado = obtener(colaboradorModificar.codigo);
            return colaboradormodificado;
        }

        public void eliminar(int codigocolaborador)
        {

            string sql = "UPDATE T_COLABORADOR SET ESTADO='Inaptivo' WHERE COD_COLABORADOR=@cod_col";

            using (SqlConnection conexion = new SqlConnection(new Util().CadenaConexión))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@cod_col", codigocolaborador));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public Colaborador obtener(int codigocolaborador)
        {
            Colaborador colaboradorEncontrado = null;
            string sql = "Select * from T_COLABORADOR where COD_COLABORADOR=@cod_col";

            using (SqlConnection conexion = new SqlConnection(new Util().CadenaConexión))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@cod_col", codigocolaborador));

                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            colaboradorEncontrado = new Colaborador()
                            {
                                codigo = (int)resultado["COD_COLABORADOR"],
                                nombre = (string)resultado["NOM_COLABORADOR"],
                                fechanacimiento = (DateTime)resultado["FEC_NACIMIENTO"],
                                ingreso = (DateTime)resultado["FEC_INGRESO"],
                                cargo = (string)resultado["CAR_COLABORADOR"]
                            };
                        }
                    }
                }
                return colaboradorEncontrado;
            }
        }


        public List<Colaborador> listar()
        {

            List<Colaborador> colaboradoresEncontradas = new List<Colaborador>();

            Colaborador colaboradorEncontrado = null;
            string sql = "Select COD_COLABORADOR, NOM_COLABORADOR, FEC_NACIMIENTO, FEC_INGRESO, CAR_COLABORADOR from T_COLABORADOR WHERE ESTADO='Activo'";

            using (SqlConnection conexion = new SqlConnection(new Util().CadenaConexión))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {

                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            colaboradorEncontrado = new Colaborador()
                            {
                                codigo = (int)resultado["COD_COLABORADOR"],
                                nombre = (string)resultado["NOM_COLABORADOR"],
                                fechanacimiento = (DateTime)resultado["FEC_NACIMIENTO"],
                                ingreso = (DateTime)resultado["FEC_INGRESO"],
                                cargo = (string)resultado["CAR_COLABORADOR"]
                            };
                            colaboradoresEncontradas.Add(colaboradorEncontrado);
                        }
                    }
                }
                return colaboradoresEncontradas;
            }

        }

        //public static bool Existe(int id)
        //{
        //    using (SqlConnection conexion = new SqlConnection(new Util().CadenaConexión))
        //    {
        //        string query = "SELECT COUNT(*) FROM T_COLABORADOR WHERE COD_COLABORADOR=@Id";
        //        SqlCommand cmd = new SqlCommand(query, conexion);
        //        cmd.Parameters.AddWithValue("COD_COLABORADOR", id);
        //        conexion.Open();

        //        int count = Convert.ToInt32(cmd.ExecuteScalar());
        //        if (count == 0)
        //            return false;
        //        else
        //            return true;
        //    }
        //}

    }
}