using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAR_Sistema_de_Administracion_de_Redes
{
    public partial class Modificar : Form
    {
        EquiposService.EquiposClient obj = new EquiposService.EquiposClient();
        public Modificar(string serie, string modelo, string caracteristica, string estado, string fecha)
        {
            InitializeComponent();
            textBox1.Text = serie;
            textBox3.Text = modelo;
            textBox2.Text = caracteristica;
            if(estado=="STK"){
                comboBox1.Text = "STOCK";
            }
            else if (estado == "ACT")
            {
                comboBox1.Text = "ACTIVO";
            }
            else
            {
                comboBox1.Text = "BAJA";
            }

            dateTimePicker1.Text = fecha;
            /*  dateTimePicker1.Value   = DateTime.ParseExact(fecha + " 00:00:00,000", "dd/MM/yyyy HH:mm:ss,fff",
                                        System.Globalization.CultureInfo.InvariantCulture);
             dateTimePicker1.Focus();*/
        }

        private void Modificar_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modificar.ActiveForm.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EquiposService.Equipo objequipodetail = new EquiposService.Equipo();
            objequipodetail.Nu_serie = textBox1.Text;
            objequipodetail.Modelo = textBox3.Text;
            objequipodetail.Caracteris = textBox2.Text;
            if (comboBox1.Text == "STOCK")
            {
                objequipodetail.Estado = "STK";
            }
            else if (comboBox1.Text == "ACIVO")
            {
                objequipodetail.Estado = "ACT";
            }
            else
            {
                objequipodetail.Estado = "BAJ";
            }

            
            objequipodetail.Fecha_compra = dateTimePicker1.Text;
            obj.ModificarEquipo(objequipodetail);
            Form3 form3 = new Form3();
            form3.ReloadForm();
            form3.Refresh();
            form3.ListarEquipos();
            Form5.ActiveForm.Visible = false;
        }
    }
}
