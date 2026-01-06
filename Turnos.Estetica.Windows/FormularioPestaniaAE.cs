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
using Turnos.Estetica.Servicios.Servicios;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioPestaniaAE : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboTintes(ref comboBoxColor);
            if (pestania != null)
            {
               textBoxTipoS.Text = pestania.tipodePestania;
                comboBoxColor.SelectedValue = pestania.IdTinte;
                textBox1.Text = pestania.Valor.ToString();
            }
        }
        private readonly IServicioPestanias _servicio;
        private Pestanias pestania;
      
        private readonly IServiciosTintes _servicioTintes;
        public FormularioPestaniaAE(IServicioPestanias servicio)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioTintes = new ServiciosTintes();
        }
        private void CargarDatosComboTintes(ref ComboBox cbo)
        {
            var listatintes = _servicioTintes.GetTintes();
            Tintes defaultTintes = new Tintes()
            {
                IdTinte = 0,
                Color = "Seleccione el color del Tinte"
            };
            listatintes.Insert(0, defaultTintes);
            cbo.DataSource = listatintes;
            cbo.DisplayMember = "Color";
            cbo.ValueMember = "IdTinte";

            cbo.SelectedIndex = 0;
        }
        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormularioPestaniaAE_Load(object sender, EventArgs e)
        {

        }

        internal Pestanias GetPestania()
        {
            return pestania;
        }

        internal void SetPerfilado(Pestanias pestania)
        {
            this.pestania=pestania;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (pestania == null)
                {
                    pestania = new Pestanias();

                }
                pestania.tipodePestania = textBoxTipoS.Text;
                pestania.IdTinte = (int)comboBoxColor.SelectedValue;
                pestania.Valor = decimal.Parse(textBox1.Text);

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(textBoxTipoS.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxTipoS, "Debe colocar un Tipo de servicio");
            }
            if (string.IsNullOrEmpty(comboBoxColor.Text))
            {
                valido = false;
                errorProvider1.SetError(comboBoxColor, "Debe seleccionar un color");
            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                valido = false;
                errorProvider1.SetError(textBox1, "Debe colocar un Valor al servicio");
            }
            return valido;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
