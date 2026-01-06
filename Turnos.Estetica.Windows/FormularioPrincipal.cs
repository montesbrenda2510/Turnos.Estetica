using System;
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
            FormularioTintes formulario = new FormularioTintes();
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
            FormularioMetododePago formulario = new FormularioMetododePago();
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

        private void Perfiladobtn_Click(object sender, EventArgs e)
        {
            FormularioPerfilados formulario = new FormularioPerfilados();
            formulario.ShowDialog();

        }

        private void Pestaniasbtn_Click(object sender, EventArgs e)
        {
            FormularioPestanias formulario = new FormularioPestanias();
            formulario.ShowDialog();
        }

        private void Generalbtn_Click(object sender, EventArgs e)
        {
            FormularioGeneral formulario = new FormularioGeneral();
            formulario.ShowDialog();
        }

        private void Serviciosbtn_Click(object sender, EventArgs e)
        {
            FormularioServicios formulario = new FormularioServicios();
            formulario.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
