using System;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioHorarioAE : Form
    {
        public FormularioHorarioAE(IServicioHorario servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private readonly IServicioHorario _servicio;
       
        private Horario horario;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (horario != null)
            {
                dateTimePickerIngreso.Value = horario.Ingreso;
                dateTimePickerEgreso.Value=horario.Egreso;  
            }
        }

        private void FormularioHorarioAE_Load(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (horario == null)
            {
                horario = new Horario();
            }
            horario.Egreso = new DateTime(
                dateTimePickerEgreso.Value.Year,
                dateTimePickerEgreso.Value.Month,
                dateTimePickerEgreso.Value.Day,
                dateTimePickerEgreso.Value.Hour,
                dateTimePickerEgreso.Value.Minute,
                dateTimePickerEgreso.Value.Second
            );

            horario.Ingreso = new DateTime(
                dateTimePickerIngreso.Value.Year,
                dateTimePickerIngreso.Value.Month,
                dateTimePickerIngreso.Value.Day,
                dateTimePickerIngreso.Value.Hour,
                dateTimePickerIngreso.Value.Minute,
                dateTimePickerIngreso.Value.Second
            ); DialogResult = DialogResult.OK; 
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
