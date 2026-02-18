using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;
using Turnos.Estetica.Servicios.Interfas;
using Turnos.Estetica.Servicios.Servicios;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioServiciosAE : Form
    {
        private readonly IServicioServicios _servicio;
        private readonly IServicioUnias _servicioUnia;
        private readonly IServicioPestanias _servicioPestania;
        private readonly IServicioPerfilados _servicioPerfilado;

        private Servicio servicio;
        private bool esEdicion = false;

        public FormularioServiciosAE(
            IServicioServicios servicio,
            IServicioPerfilados perfilados,
            IServicioPestanias pestanias,
            IServicioUnias unias)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioPerfilado = perfilados;
            _servicioPestania = pestanias;
            _servicioUnia = unias;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CargarDatosComboPerfilado(comboBoxPerfilado);
            CargarDatosComboPestania(comboBoxUnias);
            CargarDatosComboUnia(comboBoxUnias);

            if (servicio != null)
            {
                comboBoxPerfilado.SelectedValue = servicio.IdPerfilado;
                comboBoxPestania.SelectedValue = servicio.IdPestania;
                comboBoxUnias.SelectedValue = servicio.IdUnia;
                textBox1.Text = servicio.ValoraPagar.ToString();

                esEdicion = true;
            }
        }
        private void CargarDatosComboUnia(ComboBox comboBoxUnias)
        {
            var listaUnias = _servicioUnia.GetComboDto();
            UniasComboDto defaultUnia = new UniasComboDto()
            {
                IdUnia = 0,
                Detalle = "Seleccione el un tipo de servicio Unia"
            };
            listaUnias.Insert(0, defaultUnia);
            comboBoxUnias.DataSource = listaUnias;
            comboBoxUnias.DisplayMember = "Detalle";
            comboBoxUnias.ValueMember = "IdUnia";

            comboBoxUnias.SelectedIndex = 0;
        }

        private void CargarDatosComboPestania(ComboBox cmboxColorPestania)
        {
            var listaPestania = _servicioPestania.GetCombosDto();
            PestaniaComboDto defaultPestania = new PestaniaComboDto()
            {
                IdPestania = 0,
                Detalle = "Seleccione un servicio de Pestania"
            };
            listaPestania.Insert(0, defaultPestania);//Ayudaaa
            comboBoxPestania.DataSource = listaPestania;
            comboBoxPestania.DisplayMember = "Detalle";
            comboBoxPestania.ValueMember = "IdPestania";

            comboBoxPestania.SelectedIndex = 0;
        }

        private void CargarDatosComboPerfilado(ComboBox comboBoxPerfilado)
        {
            List<PerfiladoComboDto> listaPerfilado = new List<PerfiladoComboDto>();

            listaPerfilado = _servicioPerfilado.GetCombosDto();
            PerfiladoComboDto defaultPerfilado = new PerfiladoComboDto()
            {
                IdPerfilado = 0,
                Detalle = "Seleccione un servicio de Pestania"
            };
            listaPerfilado.Insert(0, defaultPerfilado);//Ayudaaa
            comboBoxPerfilado.DataSource = listaPerfilado;
            comboBoxPerfilado.DisplayMember = "Detalle";
            comboBoxPerfilado.ValueMember = "IdPerfilado";

            comboBoxPerfilado.SelectedIndex = 0;
        }




        private void comboBoxPerfilado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPestania_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        internal Servicio GetServicio()
        {
            return servicio;
        }

        internal void SetPerfilado(Servicio servicio1)
        {
            this.servicio = servicio1;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            if (servicio == null)
                servicio = new Servicio();

            servicio.IdUnia = (int)comboBoxUnias.SelectedValue;
            servicio.IdPerfilado = (int)comboBoxPerfilado.SelectedValue;
            servicio.IdPestania = (int)comboBoxPestania.SelectedValue;
            servicio.ValoraPagar = decimal.Parse(textBox1.Text);

            try
            {
                if (!_servicio.Existe(servicio))
                {
                    _servicio.Guardar(servicio);

                    if (!esEdicion)
                    {
                        MessageBox.Show("Registro agregado",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
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

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(comboBoxUnias.Text))
            {
                valido = false;
                errorProvider1.SetError(comboBoxUnias, "Debe colocar un Tipo de Unia");
            }
            if (string.IsNullOrEmpty(comboBoxPestania.Text))
            {
                valido = false;
                errorProvider1.SetError(comboBoxPestania, "Debe seleccionar un pestania");
            }
            if (string.IsNullOrEmpty(comboBoxPerfilado.Text))
            {
                valido = false;
                errorProvider1.SetError(comboBoxPerfilado, "Debe colocar un Valor al perfilado");
            }
            return valido;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormularioServiciosAE_Load(object sender, EventArgs e)
        {

        }
    }
}
