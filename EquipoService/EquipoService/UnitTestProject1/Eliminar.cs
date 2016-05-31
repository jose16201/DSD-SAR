using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;

namespace UnitTestProject1
{
    /// <summary>
    /// Summary description for Eliminar
    /// </summary>
    [TestClass]
    public class Eliminar
    {


        [TestMethod]
        public void CRUDTestEliminar()
        {
            //MODIFICAR VIA HTTP POST
            string deletedata = "{\"serie\":\"JWDU0dd\"}";
            byte[] data = Encoding.UTF8.GetBytes(deletedata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:23298/Equipos.svc/Equipos/");
            req.Method = "DELETE";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string equipoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();

            Equipo equipoEliminado = js.Deserialize<Equipo>(equipoJson);

            Assert.AreNotEqual("JWDU0dd", equipoEliminado.serie);


        }

    }
}
