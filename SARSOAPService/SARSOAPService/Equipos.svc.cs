using SARSOAPService.Dominio;
using SARSOAPService.Persistencia;
using SARSOAPService.Errores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SARSOAPService
{
    
   public class Equipos : IEquipos
    {
       private EquipoDAO equipoDAO = new EquipoDAO();
       public Equipo CrearEquipo(Equipo equipoACrear)
        {
            if (equipoDAO.Obtener(equipoACrear.Nu_serie)!= null)
            {
           throw new FaultException<RepetidoException>(
                   new RepetidoException(){
                       Codigo= "101", 
                       Descripcion ="El equipo ya existe"
            
                },
                new FaultReason ("Error al intentar creacion"));
            }
            return equipoDAO.Crear(equipoACrear);
        }

        public Equipo ObtenerEquipo(string nu_serie)
        {
            return equipoDAO.Obtener(nu_serie);
        }

        public Equipo ModificarEquipo(Equipo equipoAModificar)
        {
            return equipoDAO.Modificar(equipoAModificar);
        }

        public void EliminarEquipos(string nu_serie)
        {
            equipoDAO.Eliminar(nu_serie);
        }

        public List<Equipo> ListarEquipos()
        {
            return equipoDAO.Listar();
        }

        public List<Dominio.Equipo> ListarEnStock()
        {
            return equipoDAO.ListarEnStock();
        }
       
    }
}
