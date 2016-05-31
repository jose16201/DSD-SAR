using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SARSOAPService.Dominio
{
    [DataContract]
    public class Equipo
    {
        [DataMember]
        public string Nu_serie{ get; set; }

        [DataMember]
        public string Modelo { get; set; }

        [DataMember]
        public string Caracteris { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public string Fecha_compra { get; set; }

    }
}