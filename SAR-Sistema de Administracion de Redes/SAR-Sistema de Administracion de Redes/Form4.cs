﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAR_Sistema_de_Administracion_de_Redes
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        
       if (comboBox1.SelectedIndex == 1)
        {
            panel1.Visible=true;

        } 
       else 
        {
            panel1.Visible=false;

        } 


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 1)
            {
                panel1.Visible = true;

            }
            else
            {
                panel1.Visible = false;

            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6.ActiveForm.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                textBox3.Text = "CONTABILIDAD";

            }
            else if (comboBox2.SelectedIndex == 1)
            {
                textBox3.Text = "RECURSOS HUMANOS";

            }
            else
            {
                textBox3.Text = "ADMINISTRACION";

            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El equipo ha sido asignado correctamente.");

            Form6.ActiveForm.Visible = false;

        }
    }
}
