using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioTintesAE : Form
    {
        private readonly IServiciosTintes _servicio;
        private Tintes tintes;
        private bool esEdicion = false;

        public FormularioTintesAE(IServiciosTintes servicios)
        {
            InitializeComponent();
            _servicio = servicios;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (tintes != null)
            {
                textBoxColorTinte.Text = tintes.Color;
                esEdicion = true;
            }
        }


        private void labelTintes_Click(object sender, EventArgs e)
        {

        }

        private void FormularioTintesAE_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            if (tintes == null)
                tintes = new Tintes();

            tintes.Color = textBoxColorTinte.Text;

            try
            {
                if (!_servicio.Existe(tintes))
                {
                    _servicio.Guardar(tintes);

                    if (!esEdicion)
                    {
                        MessageBox.Show("Registro agregado",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registro editado",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Registro duplicado",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(textBoxColorTinte.Text))
            {
                MessageBox.Show("Debe ingresar un color",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public Tintes GetTintes()
        {
            return tintes;
        }
        public void SetTintes(Tintes tintes)
        {
            this.tintes = tintes;
        }

      
    }
}
