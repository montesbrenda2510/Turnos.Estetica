using System;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioHorarioAE : Form
    {
        private readonly IServicioHorario _servicio;
        public FormularioHorarioAE(IServicioHorario servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        
        private Horario horario;
        private bool esEdicion = false;
       
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (horario != null)
            {
                dateTimePickerIngreso.MinDate = DateTime.Now;
                dateTimePickerEgreso.MinDate = DateTime.Now;
                esEdicion = true;
            }
         
        }

        private void FormularioHorarioAE_Load(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
                return;

            if (horario == null)
                horario = new Horario();

            // Cargar datos
            horario.Ingreso = dateTimePickerIngreso.Value;
            horario.Egreso = dateTimePickerEgreso.Value;

            try
            {
                if (!_servicio.Existe(horario))
                {
                    _servicio.Guardar(horario);

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

                        horario = null;
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
            dateTimePickerIngreso.Value = DateTime.Now;
            dateTimePickerEgreso.Value = DateTime.Now;
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;

            if (dateTimePickerEgreso.Value <= dateTimePickerIngreso.Value)
            {
                valido = false;
                errorProvider1.SetError(dateTimePickerEgreso,
                    "El horario de egreso debe ser mayor al ingreso");
            }

            return valido;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Horario GetHorario()
        {
            return horario;
        }
        public Horario SetHorario(Horario horario)
        {
            return horario;
        }
    }
}
