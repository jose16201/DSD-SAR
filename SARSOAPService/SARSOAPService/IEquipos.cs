using SARSOAPService.Dominio;
using SARSOAPService.Errores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SARSOAPService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEquipos" in both code and config file together.
    [ServiceContract]
    public interface IEquipos
    {
       
        [FaultContract(typeof (RepetidoException))]
        [OperationContract]
        Equipo CrearEquipo(Equipo equipoACrear);

        [OperationContract]
        Equipo ObtenerEquipo(string nu_serie);
        [OperationContract]
        Equipo ModificarEquipo(Equipo equipoAModificar);

        [OperationContract]
        void EliminarEquipos(string nu_serie);

        [OperationContract]

        List<Equipo> ListarEquipos();
        [OperationContract]

        List<Equipo> ListarEnStock();
    }

    
}
