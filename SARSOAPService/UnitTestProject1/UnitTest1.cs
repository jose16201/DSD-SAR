using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        

            [TestMethod]
        public void Test1CrearEquipoOk()

        {
            
            EquiposWS.EquiposClient proxy = new EquiposWS.EquiposClient();
           EquiposWS.Equipo equipoCreado = proxy.CrearEquipo(new EquiposWS.Equipo()
            {

                Nu_serie = "7777770",
                Modelo = "Power Edge 110T",
                Caracteris = "Quadcore RAM 32GB HDD 2TB",
                Estado="STK",
                Fecha_compra="20/05/2016"


            }
            );
           Assert.AreEqual("7777770", equipoCreado.Nu_serie);
           Assert.AreEqual("Power Edge 110T", equipoCreado.Modelo);
           Assert.AreEqual("Quadcore RAM 32GB HDD 2TB", equipoCreado.Caracteris);
           Assert.AreEqual("STK", equipoCreado.Estado);
           Assert.AreEqual("20/05/2016", equipoCreado.Fecha_compra);
        }
        [TestMethod]
        public void Test2CrearEquipoError()
        { 
        
            EquiposWS.EquiposClient proxy = new EquiposWS.EquiposClient();

            try
            {
                EquiposWS.Equipo equipoCreado = proxy.CrearEquipo(new EquiposWS.Equipo()
                 {

                     Nu_serie = "7777770",
                     Modelo = "Power Edge 110T",
                     Caracteris = "Quadcore RAM 32GB HDD 2TB",
                     Estado = "STK",
                     Fecha_compra = "20/05/2016"


                 }
                 );
            }
            catch (FaultException<EquiposWS.RepetidoException> error) 
            {
                Assert.AreEqual("Error al intentar creacion", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "101");
                Assert.AreEqual(error.Detail.Descripcion, "El equipo ya existe");
            }
        }


/*   MODIFICAR*/

        [TestMethod]
        public void Test1ModificarEquipoOk()
        {

            EquiposWS.EquiposClient proxy = new EquiposWS.EquiposClient();
            EquiposWS.Equipo equipoModificado = proxy.ModificarEquipo(new EquiposWS.Equipo()
            {

                Nu_serie = "7777770",
                Modelo = "Power Edge 330T",
                Caracteris = "Intel SixCore RAM 32GB HDD 2TB",
                Estado = "STK",
                Fecha_compra = "20/05/2016"


            }
             );
            Assert.AreEqual("7777770", equipoModificado.Nu_serie);
            Assert.AreEqual("Power Edge 330T", equipoModificado.Modelo);
            Assert.AreEqual("Intel SixCore RAM 32GB HDD 2TB", equipoModificado.Caracteris);
            Assert.AreEqual("STK", equipoModificado.Estado);
            Assert.AreEqual("20/05/2016", equipoModificado.Fecha_compra);
        }
        [TestMethod]
        public void Test2ModificarEquipoError()
        {

            EquiposWS.EquiposClient proxy = new EquiposWS.EquiposClient();

            try
            {
                EquiposWS.Equipo equipoModificado = proxy.ModificarEquipo(new EquiposWS.Equipo()
                {

                    Nu_serie = "1111111",
                    Modelo = "Power Edge 330T",
                    Caracteris = "Intel SixCore RAM 32GB HDD 2TB",
                    Estado = "STK",
                    Fecha_compra = "20/05/2016"


                }
                 );
            }
            catch (FaultException<EquiposWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar creacion", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo, "101");
                Assert.AreEqual(error.Detail.Descripcion, "El equipo no existe");
            }
        }

        [TestMethod]
        public void PruebaCrear()
        {
            ColaboradorService.ColaboradoresClient proxy = new ColaboradorService.ColaboradoresClient();
            ColaboradorService.Colaborador colaboradorCreado = proxy.CrearColaborador(new ColaboradorService.Colaborador()
            {
                codigo = 13,
                nombre = "Roger",
                fechanacimiento = Convert.ToDateTime("20/05/2016 11:50 p.m."),
                ingreso = Convert.ToDateTime("20/05/2016 11:50 p.m."),
                cargo = "Administrador"
            });
            Assert.AreEqual(13, colaboradorCreado.codigo);
            Assert.AreEqual("Roger", colaboradorCreado.nombre);
            Assert.AreEqual(Convert.ToDateTime("20/05/2016 11:50 p.m."), colaboradorCreado.fechanacimiento);
            Assert.AreEqual(Convert.ToDateTime("20/05/2016 11:50 p.m."), colaboradorCreado.ingreso);
            Assert.AreEqual("Administrador", colaboradorCreado.cargo);
        }
        [TestMethod]
        public void PruebaModificar()
        {
            ColaboradorService.ColaboradoresClient proxy = new ColaboradorService.ColaboradoresClient();
            ColaboradorService.Colaborador colaboradorCreado = proxy.ModificarColaborador(new ColaboradorService.Colaborador()
            {
                codigo = 13,
                nombre = "Roger Paucar",
                fechanacimiento = Convert.ToDateTime("20/05/2016 11:50 p.m."),
                ingreso = Convert.ToDateTime("20/05/2016 11:50 p.m."),
                cargo = "Administrador"
            });
            Assert.AreEqual(13, colaboradorCreado.codigo);
            Assert.AreEqual("Roger Paucar", colaboradorCreado.nombre);
            Assert.AreEqual(Convert.ToDateTime("20/05/2016 11:50 p.m."), colaboradorCreado.fechanacimiento);
            Assert.AreEqual(Convert.ToDateTime("20/05/2016 11:50 p.m."), colaboradorCreado.ingreso);
            Assert.AreEqual("Administrador", colaboradorCreado.cargo);
        }

        
    }
}
