using System;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioUñasAE : Form
    {
        private readonly IServicioUnias _servicio;
        private Unias unias;
        private bool esEdicion = false;

        public FormularioUñasAE(IServicioUnias servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (unias != null)
            {
                textBoxServicio.Text = unias.TipodeServicioUnia;
                textBoxValor.Text = unias.Valor.ToString();
                esEdicion = true;
            }
        }

        private void FormularioUñasAE_Load(object sender, EventArgs e)
        {

        }
        public Unias GetUnia()
        {
            return unias;
        }
        public void SetTintes(Unias unias)
        {
            this.unias= unias;  
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            if (unias == null)
                unias = new Unias();

            unias.TipodeServicioUnia = textBoxServicio.Text.Trim();
            unias.Valor = decimal.Parse(textBoxValor.Text);

            try
            {
                if (!_servicio.Existe(unias))
                {
                    _servicio.Guardar(unias);

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

                        // Limpiar para nuevo registro
                        unias = null;
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

                    // Opcional: limpiar el objeto para no guardar datos viejos erróneos
                    unias = null;
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

            textBoxServicio.Clear();
            textBoxValor.Clear();
            textBoxServicio.Focus();
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;

            if (string.IsNullOrWhiteSpace(textBoxServicio.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxServicio, "Debe colocar un tipo de servicio");
            }

            if (string.IsNullOrWhiteSpace(textBoxValor.Text) || !decimal.TryParse(textBoxValor.Text, out _))
            {
                valido = false;
                errorProvider1.SetError(textBoxValor, "Debe colocar un valor válido");
            }

            return valido;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
