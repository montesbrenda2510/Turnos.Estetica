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
        private readonly IServicioPestanias _servicio;
        private readonly IServiciosTintes _servicioTintes;

        private Pestanias pestania;
        private bool esEdicion = false;

        public FormularioPestaniaAE(IServicioPestanias servicio)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioTintes = new ServiciosTintes();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboTintes(comboBoxColor);

            if (pestania != null)
            {
                textBoxTipoS.Text = pestania.tipodePestania;
                comboBoxColor.SelectedValue = pestania.IdTinte;
                textBox1.Text = pestania.Valor.ToString();
                esEdicion = true;
            }
        }

        private void CargarDatosComboTintes( ComboBox cbo)
        {
            var lista = _servicioTintes.GetTintes();

            var defecto = new Tintes
            {
                IdTinte = 0,
                Color = "Seleccione el color del Tinte"
            };

            lista.Insert(0, defecto);

            cbo.DataSource = lista;
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

        public void SetPestania(Pestanias pestania)
        {
            this.pestania=pestania;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            if (pestania == null)
                pestania = new Pestanias();

            pestania.tipodePestania = textBoxTipoS.Text.Trim();
            pestania.IdTinte = (int)comboBoxColor.SelectedValue;
            pestania.Valor = decimal.Parse(textBox1.Text);

            try
            {
                if (!_servicio.Existe(pestania))
                {
                    _servicio.Guardar(pestania);

                    if (!esEdicion)
                    {
                        MessageBox.Show("Registro agregado",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        DialogResult dr = MessageBox.Show(
                            "¿Desea agregar otro registro?",
                            "Pregunta",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2);

                        if (dr == DialogResult.No)
                        {
                            DialogResult = DialogResult.OK;
                            return;
                        }

                        // limpiar para nuevo registro
                        pestania = null;
                        InicializarControles();
                    }
                    else
                    {
                        MessageBox.Show("Registro editado",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                    }
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
            textBoxTipoS.Clear();
            comboBoxColor.SelectedIndex = 0;
            textBox1.Clear();
            textBoxTipoS.Focus();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;

            if (string.IsNullOrWhiteSpace(textBoxTipoS.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxTipoS, "Debe colocar un Tipo de servicio");
            }

            if ((int)comboBoxColor.SelectedValue == 0)
            {
                valido = false;
                errorProvider1.SetError(comboBoxColor, "Debe seleccionar un color");
            }

            if (!decimal.TryParse(textBox1.Text, out decimal valor))
            {
                valido = false;
                errorProvider1.SetError(textBox1, "Debe colocar un valor numérico válido");
            }
            else if (valor <= 0)
            {
                valido = false;
                errorProvider1.SetError(textBox1, "El valor debe ser mayor a 0");
            }

            return valido;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
