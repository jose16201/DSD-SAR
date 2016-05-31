using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CRUDTestModificar()
        {
            //MODIFICAR VIA HTTP POST
            string putdata = "{\"modelo\":\"CELERON\",\"serie\":\"JWDU0dd\"}";
            byte[] data = Encoding.UTF8.GetBytes(putdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:23298/Equipos.svc/Equipos");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string equipoJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Equipo equipoModificado = js.Deserialize<Equipo>(equipoJson);

            Assert.AreEqual("JWDU0dd", equipoModificado.serie);
            Assert.AreEqual("CELERON", equipoModificado.modelo);

        }
    }
}
