using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EquipoService.Persistencia;
using System.ServiceModel.Web;
using EquipoService.Errores;
using System.Net;

namespace EquipoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Equipo" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Equipo.svc or Equipo.svc.cs at the Solution Explorer and start debugging.
    public class Registros : IRegistros
    {
        private RegistroDAO dao = new RegistroDAO();
        /*public Dominio.Registro CrearEquipo(Dominio.Registro equipoACrear)
        {
            if (RegistroDAO.Obtener(equipoACrear.dni) != null) 
            
            {
                throw new WebFaultException<RepetidoException>(

                    new RepetidoException() { 
                    Codigo="101",Descripcion="El Equipo ya existe"
                    
                    },
                    HttpStatusCode.Conflict
                    ); 



            }
            
            return dao.Crear(equipoACrear);
        }*/

        public Dominio.Registro ObtenerEquipo(string dni)
        {
            return dao.Obtener(dni);
        }
/*
        public Dominio.Registro ModificarEquipo(Dominio.Registro equipoAModificar)
        {
            return dao.Modificar(equipoAModificar);
        }

        public void EliminarEquipo(string serie)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Registro> ListarEquipos()
        {
            return dao.ListarTodos();
        }*/
    }
}
