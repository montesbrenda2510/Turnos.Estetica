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
    }
}
