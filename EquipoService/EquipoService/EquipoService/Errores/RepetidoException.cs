﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EquipoService.Errores
{
    public class RepetidoException
    {
        [DataMember]

        public string Codigo{get; set;}
          [DataMember]
        public string Descripcion { get; set; }
    }
}