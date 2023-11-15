using System;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioHorarioAE : Form
    {
        public FormularioHorarioAE()
        {
            InitializeComponent();
        }
        private Horario horario;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (horario != null)
            {
                dateTimePickerIngreso.Value = DateTime.Today.Add(horario.Ingreso);
                dateTimePickerEgreso.Value=DateTime.Today.Add(horario.Egreso);  
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
            horario.Egreso = new TimeSpan(dateTimePickerEgreso.Value.Hour, dateTimePickerEgreso.Value.Minute, dateTimePickerEgreso.Value.Second);

            horario.Ingreso = new TimeSpan(dateTimePickerIngreso.Value.Hour, dateTimePickerIngreso.Value.Minute, dateTimePickerIngreso.Value.Second);
            DialogResult = DialogResult.OK; 
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
