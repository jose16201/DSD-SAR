using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;


namespace UnitTestProject1
{
    /// <summary>
    /// Summary description for Equipo
    /// </summary>
    [TestClass]
    public class EquipoTest
    {
       
        [TestMethod]
        public void CRUDTest()
        {
        //CREAR VIA HTTP POST
            string postdata = "{\"serie\":\"JWDU0dd\",\"modelo\":\"Optiplex\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:23298/Equipos.svc/Equipos");
            req.Method="POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data,0,data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string equipoJson = reader.ReadToEnd();
            JavaScriptSerializer  js = new JavaScriptSerializer();
                Equipo equipoCreado = js.Deserialize<Equipo>(equipoJson);
                Assert.AreEqual("JWDU0dd", equipoCreado.serie);
            Assert.AreEqual("Optiplex",equipoCreado.modelo);
        
        }





    }
}
