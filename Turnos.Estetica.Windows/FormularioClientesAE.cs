using System;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioClientesAE : Form
    {
        private readonly IServicioClientes _servicio;
        public FormularioClientesAE(IServicioClientes servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private Clientes clientes;
        private bool esEdicion = false;
        protected override void OnLoad(EventArgs e)
        {
            if (true)
            {
                if (clientes != null)
                {
                    textBoxNombre.Text = clientes.Nombre;
                    textBoxApellido.Text = clientes.Apellido;
                    textBoxTel.Text = clientes.Telefono;

                    esEdicion = true;

                }

            }
           
        }
       
        internal Clientes GetClinte()
        {
            return clientes;
        }

        private void FormularioClientesAE_Load(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

            if (!ValidarDatos())
                return;

            // PRIMERO crear el objeto
            if (clientes == null)
                clientes = new Clientes();

            // DESPUÉS cargar los datos
            clientes.Nombre = textBoxNombre.Text.Trim();
            clientes.Apellido = textBoxApellido.Text.Trim();
            clientes.Telefono = textBoxTel.Text.Trim();

            try
            {
                if (!_servicio.Existe(clientes))
                {
                    _servicio.Guardar(clientes);

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
                        clientes = null;
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
           
          
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            textBoxTel.Clear();
            textBoxNombre.Focus();
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

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
