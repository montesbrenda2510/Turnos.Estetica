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
    public partial class FormularioMetododePagoAE : Form
    {
        private readonly IServicioMetododePago _servicio;
        private MetododePago metododePago;
        private bool esEdicion = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (metododePago != null)
            {
                textBoxMetododePago.Text = metododePago.Tipodepago;
                esEdicion = true;
            }
        }
        public FormularioMetododePagoAE(IServicioMetododePago servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
    

        private void FormularioMetododePagoAE_Load(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            // creo el objeto si es null
            if (metododePago == null)
                metododePago = new MetododePago();

            //  le asigno valores
            metododePago.Tipodepago = textBoxMetododePago.Text;

            try
            {
                if (!_servicio.Existe(metododePago))
                {
                    _servicio.Guardar(metododePago);

                    MessageBox.Show("Registro guardado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

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

        private void InicializarControles()
        {
            textBoxMetododePago.Clear();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;

            if (string.IsNullOrWhiteSpace(textBoxMetododePago.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxMetododePago,
                    "Debe ingresar un tipo de pago");
            }
             return valido;
        }
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; 
        }

        public MetododePago GetMetododepago()
        {
            return metododePago;
        }
        public MetododePago SetMetododePago(MetododePago metododePago)
        {
            return metododePago;
        }
    }
}
