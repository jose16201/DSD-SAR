using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EquipoService.Persistencia
{
    public class ConexionUtil
    {
        public static string Cadena
        {
            get
            {
                return "Data Source=(local);Initial Catalog=SAR;Integrated Security=SSPI;";
            }
        }
    }
}