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
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboTintes(ref comboBoxColor);
            if (perfilado.IdPerfilado!=0)
            {
                textBoxTipoSer.Text = perfilado.TipodePerfilado;
                comboBoxColor.SelectedValue = perfilado.IdTinte;
                textBox1.Text = perfilado.Valor.ToString();
            }
        }
        private readonly IServicioPerfilados _servicio;
        private Perfilado perfilado;
        //private List<Perfilado> perfilados;
        private readonly IServiciosTintes _servicioTintes;
        public FormularioPerfiladoAE(IServicioPerfilados servicio)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioTintes = new ServiciosTintes();
        }
        internal Perfilado GetPerfilado()
        {
            return perfilado;
        }

        internal void SetPerfilado(Perfilado perfilado)
        {
            this.perfilado = perfilado;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (perfilado == null)
                {
                   perfilado = new Perfilado();

                }
                perfilado.TipodePerfilado = textBoxTipoSer.Text;
                perfilado.IdTinte = (int)comboBoxColor.SelectedValue;
                perfilado.Valor = decimal.Parse(textBox1.Text);

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(textBoxTipoSer.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxTipoSer, "Debe colocar un Tipo de servicio");
            }
            if (string.IsNullOrEmpty(comboBoxColor.Text))
            {
                valido = false;
                errorProvider1.SetError(comboBoxColor, "Debe seleccionar un color");
            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                valido = false;
                errorProvider1.SetError(textBox1, "Debe colocar un valor al sevicio");
            }
            return valido;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
