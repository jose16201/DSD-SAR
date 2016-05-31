
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SARSOAPService.Dominio;
using SARSOAPService.Errores;
using SARSOAPService.Persistencia;

namespace SARSOAPService
{
    public class Colaboradores : IColaboradores
    {
        private ColaboradorDAO colaboradorDAO = new ColaboradorDAO();

        public Colaborador CrearColaborador(Colaborador colaboradorCrear)
        {

            if (colaboradorDAO.obtener(colaboradorCrear.codigo) != null)
            {
                throw new FaultException<RepetidoException>
                (
                new RepetidoException()
                {
                    Codigo = "101",
                    Descripcion = "El colaborador ya existe"
                },
                new FaultReason("Error al crear"));
            }
            return colaboradorDAO.Crear(colaboradorCrear);
        }

        public Colaborador ModificarColaborador(Colaborador colaboradorModificar)
        {
            return colaboradorDAO.Modificar(colaboradorModificar);
        }

        public void EliminarColaborador(int codigo)
        {
            colaboradorDAO.eliminar(codigo);
        }

        public Colaborador ObtenerColaborador(int codigo)
        {
            return colaboradorDAO.obtener(codigo);
        }

        public List<Dominio.Colaborador> ListarColaborador()
        {
            return colaboradorDAO.listar();
        }

        //public static bool Existe(int id)
        //{
        //    return ColaboradorDAO.Existe(id);
        //}

    }
}

