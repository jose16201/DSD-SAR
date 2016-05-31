using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SARSOAPService.Persistencia
{
    public class Util
    {
        public string CadenaConexión { get; set; }
        public Util()
        {
            CadenaConexión = @"Data Source=(local); Initial Catalog=SAR; Integrated Security=SSPI";
        }
    }
}