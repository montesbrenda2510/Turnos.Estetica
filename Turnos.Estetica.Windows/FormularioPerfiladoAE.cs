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
using Turnos.Estetica.Entetidades.EntidadesDto;
using Turnos.Estetica.Servicios.Interfas;
using Turnos.Estetica.Servicios.Servicios;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioPerfiladoAE : Form
    {
        private readonly IServicioPerfilados _servicio;
        private readonly IServiciosTintes _servicioTintes;

        private Perfilado perfilado;
        private bool esEdicion = false;

        public FormularioPerfiladoAE(IServicioPerfilados servicio)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioTintes = new ServiciosTintes();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CargarDatosComboTintes(comboBoxColor);

            if (perfilado != null)
            {
                textBoxTipoSer.Text = perfilado.TipodePerfilado;
                comboBoxColor.SelectedValue = perfilado.IdTinte;
                textBox1.Text = perfilado.Valor.ToString();

                esEdicion = true;
            }
        }
        internal Perfilado GetPerfilado()
        {
            return perfilado;
        }

        internal void SetPerfilado(Perfilado perfilado)
        {
            this.perfilado = perfilado;
        }
        private void CargarDatosComboTintes( ComboBox cbo)
        {
            var lista = _servicioTintes.GetTintes();

            var defaultTinte = new Tintes
            {
                IdTinte = 0,
                Color = "Seleccione un color"
            };

            lista.Insert(0, defaultTinte);

            cbo.DataSource = lista;
            cbo.DisplayMember = "Color";
            cbo.ValueMember = "IdTinte";
            cbo.SelectedIndex = 0;
        }
        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            if (perfilado == null)
                perfilado = new Perfilado();

            perfilado.TipodePerfilado = textBoxTipoSer.Text.Trim();
            perfilado.IdTinte = (int)comboBoxColor.SelectedValue;
            perfilado.Valor = decimal.Parse(textBox1.Text);

            try
            {
                if (!_servicio.Existe(perfilado))
                {
                    _servicio.Guardar(perfilado);

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

                        perfilado = null;
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
            textBoxTipoSer.Clear();
            textBox1.Clear();
            comboBoxColor.SelectedIndex = 0;
            textBoxTipoSer.Focus();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;

            if (string.IsNullOrWhiteSpace(textBoxTipoSer.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxTipoSer, "Debe colocar un tipo de perfilado");
            }

            if ((int)comboBoxColor.SelectedValue == 0)
            {
                valido = false;
                errorProvider1.SetError(comboBoxColor, "Debe seleccionar un color");
            }

            if (!decimal.TryParse(textBox1.Text, out decimal valor) || valor <= 0)
            {
                valido = false;
                errorProvider1.SetError(textBox1, "Debe colocar un valor válido");
            }

            return valido;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
