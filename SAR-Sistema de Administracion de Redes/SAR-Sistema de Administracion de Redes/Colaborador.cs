



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EquipoService;
using EquipoService.Dominio;

namespace SAR_Sistema_de_Administracion_de_Redes
{
    public partial class Colaborador : Form
    {

        ServiceColaborador.ColaboradoresClient obj = new ServiceColaborador.ColaboradoresClient();
        //ServiceColaborador.RepetidoExcepcion obj2 = new ServiceColaborador.RepetidoExcepcion();
        public Colaborador()
        {
            InitializeComponent();
            ListarColaboradores();
        }

        private void ListarColaboradores() 
        {
            //DataSet ds = new DataSet();
            dataGridView1.DataSource = obj.ListarColaborador();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                try
                {
                    ServiceColaborador.Colaborador objcolaborador = new ServiceColaborador.Colaborador();

                    objcolaborador.codigo = int.Parse(textBox1.Text);
                    objcolaborador.nombre = textBox4.Text;
                    objcolaborador.ingreso = Convert.ToDateTime(maskedTextBox1.Text);
                    objcolaborador.fechanacimiento = Convert.ToDateTime(maskedTextBox2.Text);
                    objcolaborador.cargo = comboBox1.Text;
                    //objcolaborador.estado = textBox2.Text;

                    obj.CrearColaborador(objcolaborador);
                    MessageBox.Show("Colaborador creado correctamente");
                    ListarColaboradores();
                    limpiar1();
                }
                catch (FaultException<ServiceColaborador.RepetidoException> error)
                {
                    string codigo = error.Detail.Codigo;
                    string descripcion = error.Detail.Descripcion;
                    if (MessageBox.Show(descripcion, codigo, MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        limpiar1();
                    }
                    //MessageBox.Show(mensaje);
                    //MessageBox.ReferenceEquals("Error al crear", error.Reason.ToString());
                    //MessageBox.ReferenceEquals(error.Detail.Codigo, "101");
                    //MessageBox.ReferenceEquals(error.Detail.Descripcion, "El colaborador ya existe");
                    //MessageBox.Show("El colaborador ya existe");
                }
            }
            else
            {
                if (MessageBox.Show("Debe elegir un cargo al colaborador", "Cargo Colaborador",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
                {
                    comboBox1.Focus();
                }
            }
                
        }

        public void limpiar1(){
            textBox1.Text="";
            textBox4.Text="";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text="";
            textBox1.Focus();
        }


        private void Colaborador_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServiceColaborador.Colaborador objcolaborador = new ServiceColaborador.Colaborador();

            objcolaborador.codigo = int.Parse(textBox1.Text);
            objcolaborador.nombre = textBox4.Text;
            objcolaborador.ingreso = Convert.ToDateTime(maskedTextBox1.Text);
            objcolaborador.fechanacimiento = Convert.ToDateTime(maskedTextBox2.Text);
            objcolaborador.cargo = comboBox1.Text;
            //objcolaborador.estado = textBox2.Text;

            obj.ModificarColaborador(objcolaborador);
            MessageBox.Show("Colaborador modificado correctamente");
            ListarColaboradores();
            limpiar1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceColaborador.Colaborador objcolaborador = new ServiceColaborador.Colaborador();

            obj.EliminarColaborador(int.Parse(textBox1.Text));
            MessageBox.Show("Colaborador eliminado correctamente");
            ListarColaboradores();
            limpiar1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            //if (textBox1.Text.Trim() == ""){
                
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
{
            if (comboBox1.Text != "")
            {
                try
                {
                    ServiceColaborador.Colaborador objcolaborador = new ServiceColaborador.Colaborador();

                    objcolaborador.codigo = int.Parse(textBox1.Text);
                    objcolaborador.nombre = textBox4.Text;
                    objcolaborador.ingreso = Convert.ToDateTime(maskedTextBox1.Text);
                    objcolaborador.fechanacimiento = Convert.ToDateTime(maskedTextBox2.Text);
                    objcolaborador.cargo = comboBox1.Text;
                    //objcolaborador.estado = textBox2.Text;

                    obj.CrearColaborador(objcolaborador);
                    MessageBox.Show("Colaborador creado correctamente");
                    ListarColaboradores();
                    limpiar1();
                }
                catch (FaultException<ServiceColaborador.RepetidoException> error)
                {
                    string codigo = error.Detail.Codigo;
                    string descripcion = error.Detail.Descripcion;
                    if (MessageBox.Show(descripcion, codigo, MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        limpiar1();
                    }
                    //MessageBox.Show(mensaje);
                    //MessageBox.ReferenceEquals("Error al crear", error.Reason.ToString());
                    //MessageBox.ReferenceEquals(error.Detail.Codigo, "101");
                    //MessageBox.ReferenceEquals(error.Detail.Descripcion, "El colaborador ya existe");
                    //MessageBox.Show("El colaborador ya existe");
                }
            }
            else
            {
                if (MessageBox.Show("Debe elegir un cargo al colaborador", "Cargo Colaborador",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
                {
                    comboBox1.Focus();
                }
            }
                
        }

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ServiceColaborador.Colaborador objcolaborador = new ServiceColaborador.Colaborador();

            objcolaborador.codigo = int.Parse(textBox1.Text);
            objcolaborador.nombre = textBox4.Text;
            objcolaborador.ingreso = Convert.ToDateTime(maskedTextBox1.Text);
            objcolaborador.fechanacimiento = Convert.ToDateTime(maskedTextBox2.Text);
            objcolaborador.cargo = comboBox1.Text;
            //objcolaborador.estado = textBox2.Text;

            obj.ModificarColaborador(objcolaborador);
            MessageBox.Show("Colaborador modificado correctamente");
            ListarColaboradores();
            limpiar1();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ServiceColaborador.Colaborador objcolaborador = new ServiceColaborador.Colaborador();

            obj.EliminarColaborador(int.Parse(textBox1.Text));
            MessageBox.Show("Colaborador eliminado correctamente");
            ListarColaboradores();
            limpiar1();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WebClient proxy = new WebClient();
            string serviceURL = string.Format("http://localhost:23298/Registros.svc/GET/{0}", textBox1.Text);
            byte[] data = proxy.DownloadData(serviceURL);
            Stream stream = new MemoryStream(data);
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(Registro));
            Registro registro = obj.ReadObject(stream) as Registro;

            textBox4.Text = registro.nombre;
            maskedTextBox2.Text = registro.fecha_nacimiento;
          
        } 
    }
}
