using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void buttonTintes_Click(object sender, EventArgs e)
        {
            FormularioTintes formulario=new FormularioTintes(); 
            formulario.ShowDialog();    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormularioClientes formulario = new FormularioClientes();
            formulario.ShowDialog();    
        }

        private void buttonHorario_Click(object sender, EventArgs e)
        {
            FormularioHorario formulario = new FormularioHorario();
            formulario.ShowDialog();
        }

        private void buttonMdP_Click(object sender, EventArgs e)
        {
            FormularioMetododePago formulario= new FormularioMetododePago();
            formulario.ShowDialog();
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void buttonUñas_Click(object sender, EventArgs e)
        {
            FormularioUnias formulario = new FormularioUnias();
            formulario.ShowDialog();
        }
    }
}
