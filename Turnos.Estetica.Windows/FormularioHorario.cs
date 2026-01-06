using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;
using Turnos.Estetica.Servicios.Servicios;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioHorario : Form
    {
        public FormularioHorario()
        {
            InitializeComponent();
            _serviciosHorario = new ServicioHorario();
        }
        readonly private IServicioHorario _serviciosHorario;
        private List<Horario> listaHorario;


        private void FormularioHorario_Load(object sender, EventArgs e)
        {
            try
            {
                listaHorario = _serviciosHorario.GetHorario();
                MostrarDatosenGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void MostrarDatosenGrilla()
        {
            dataGridViewHorario.Rows.Clear();
            foreach (var horario in listaHorario)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, horario);
                AgregarFila(r);
            }
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridViewHorario);
            return r;
        }

        private void SetearFila(DataGridViewRow r, Horario horario)
        {
            r.Cells[ColumnIdHorario.Index].Value=horario.IdHorario.ToString();
            r.Cells[ColumnIngreso.Index].Value = horario.Ingreso;
            r.Cells[ColumnEgreso.Index].Value = horario.Egreso;
            r.Tag = horario;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dataGridViewHorario.Rows.Add(r);
        }

        private void toolStripButtonNuevo_Click(object sender, EventArgs e)
        {
            FormularioHorarioAE formulario = new FormularioHorarioAE(_serviciosHorario);
            DialogResult dr = formulario.ShowDialog();

            if (dr==DialogResult.Cancel)
            {
                return;
            }
            var horario = formulario.GetHorario();
           _serviciosHorario.Guardar(horario);
            //_serviciosHorario.GetCantidad();
            //_serviciosHorario.Existe();
            listaHorario = _serviciosHorario.GetHorario();
            MostrarDatosenGrilla();
            
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewHorario.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dataGridViewHorario.SelectedRows[0];
            Horario horario = (Horario)r.Tag;
            DialogResult rd = MessageBox.Show($"Estas seguro que quiere eliminar este {horario.Ingreso} {horario.Egreso}" +
          $" ??  ", "Esperando confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rd == DialogResult.No)
            {
                return;
            }
            QuitarFila(r);
            _serviciosHorario.Borrar(horario.IdHorario);
            //traigo la lista actualizada
            listaHorario = _serviciosHorario.GetHorario();
            MostrarDatosenGrilla();
        }

        private void QuitarFila(DataGridViewRow r)
        {
            dataGridViewHorario.Rows.Remove(r);
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {

            if (dataGridViewHorario.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dataGridViewHorario.SelectedRows[0];
            Horario horario = (Horario)r.Tag;
            Horario horarioCopia = (Horario)horario.Clone();
            try
            {
                FormularioHorarioAE horarioAE = new FormularioHorarioAE(_serviciosHorario);
                horarioAE.SetHorario(horario);
                DialogResult dr = horarioAE.ShowDialog();
                if (dr == DialogResult.No)
                {
                    return;
                }
                horario = horarioAE.GetHorario();
                //preguntar si exite 
                _serviciosHorario.Guardar(horario);
                SetearFila(r, horario);
                MessageBox.Show($"Se edito el horario {horario.Ingreso} {horario.Egreso}"
          , "Mansaje", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                SetearFila(r, horarioCopia);
                throw;
            }
        }
    }
}
