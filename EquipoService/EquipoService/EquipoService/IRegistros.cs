using EquipoService.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EquipoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEquipo" in both code and config file together.
    [ServiceContract]
    public interface IRegistros
    {
       
          [OperationContract]
          [WebInvoke(Method = "GET", UriTemplate = "GET/{dni}", ResponseFormat = WebMessageFormat.Json)]
        Registro ObtenerEquipo(string dni);
        /*  [OperationContract]
          [WebInvoke(Method = "PUT", UriTemplate = "Registros", ResponseFormat = WebMessageFormat.Json)]
        Registro ModificarEquipo(Registro equipoAModificar);
          [OperationContract]
          [WebInvoke(Method = "DELETE", UriTemplate = "Registros/{serie}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarEquipo(string serie);
          [OperationContract]
        List<Registro> ListarEquipos();

          [OperationContract]
          [WebInvoke(Method = "POST", UriTemplate = "Registros", ResponseFormat = WebMessageFormat.Json)]
          Registro CrearEquipo(Registro equipoACrear);*/
    }
}
