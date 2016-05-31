using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SARSOAPService.Dominio
{
    [DataContract]
    public class Colaborador
    {
        [DataMember]
        public int codigo { get; set; }
        [DataMember]
        public string nombre { get; set; }

        public string estado { get; set; }
        [DataMember]
        public DateTime ingreso { get; set; }
        [DataMember]
        public DateTime fechanacimiento { get; set; }
        [DataMember]
        public string cargo { get; set; }
    }
}