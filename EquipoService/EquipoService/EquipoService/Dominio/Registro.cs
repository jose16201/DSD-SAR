using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EquipoService.Dominio
{
    [DataContract]
    public class Registro
    {

        [DataMember]

        public string dni{get; set;}

        
        [DataMember]

        public string nombre { get; set; }
          [DataMember]
        public string fecha_nacimiento { get; set; }
    }
}