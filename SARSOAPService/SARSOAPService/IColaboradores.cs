using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SARSOAPService.Dominio;
using SARSOAPService.Errores;

namespace SARSOAPService
{
    [ServiceContract]
    public interface IColaboradores
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Colaborador CrearColaborador(Colaborador colaboradorCrear);

        [OperationContract]
        Colaborador ObtenerColaborador(int codigo);

        [OperationContract]
        Colaborador ModificarColaborador(Colaborador colaboradorModificar);

        [OperationContract]
        void EliminarColaborador(int codigo);

        [OperationContract]
        List<Colaborador> ListarColaborador();

        //[OperationContract]
        //public static bool Existe(int id);
    }
}
