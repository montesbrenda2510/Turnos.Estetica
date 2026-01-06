using System;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioClientesAE : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (clientes != null)
            {
                textBoxNombre.Text = clientes.Nombre;
                textBoxApellido.Text = clientes.Apellido;
                textBoxTel.Text = clientes.Telefono;

            }
        }
        private readonly IServicioClientes _servicio;
        public FormularioClientesAE(IServicioClientes servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private Clientes clientes;
        internal Clientes GetClinte()
        {
            return clientes;
        }

        private void FormularioClientesAE_Load(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (clientes == null)
                {
                    clientes = new Clientes();

                }
                clientes.Nombre = textBoxNombre.Text;
                clientes.Apellido = textBoxApellido.Text;
                clientes.Telefono = textBoxTel.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (string.IsNullOrEmpty(textBoxNombre.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxNombre, "Debe colocar un Nombre");
            }
            if (string.IsNullOrEmpty(textBoxApellido.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxApellido, "Debe colocar un Apellido");
            }
            if (string.IsNullOrEmpty(textBoxTel.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxTel, "Debe colocar un Telefono");
            }
            return valido;


        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal void SetCliente(Clientes clientes)
        {
            this.clientes = clientes;
        }

    }
}
