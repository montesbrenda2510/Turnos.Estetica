using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;
using Turnos.Estetica.Servicios.Servicios;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioTintes : Form
    {
        public FormularioTintes()
        {
            InitializeComponent();
            _serviciosTintes = new ServiciosTintes();
        }
        readonly private IServiciosTintes _serviciosTintes;
        private List<Tintes> listatintes;

        private void FormularioTintes_Load(object sender, EventArgs e)
        {
            try
            {
                listatintes = _serviciosTintes.GetTintes();
                MostrarDatosenGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosenGrilla()
        {
            dataGridViewTinte.Rows.Clear();
            foreach (var tintes in listatintes)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tintes);
                AgregarFila(r);
            }
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridViewTinte);
            return r;
        }

        private void SetearFila(DataGridViewRow r, Tintes tintes)
        {
            r.Cells[ColumnColor.Index].Value = tintes.Color;
            r.Tag = tintes;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dataGridViewTinte.Rows.Add(r);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
