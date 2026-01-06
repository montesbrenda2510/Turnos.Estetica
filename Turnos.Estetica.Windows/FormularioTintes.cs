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

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewTinte.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dataGridViewTinte.SelectedRows[0];
           Tintes tintes = (Tintes)r.Tag;
            DialogResult rd = MessageBox.Show($"Estas seguro que quiere eliminar este {tintes.Color} " +
          $" ??  ", "Esperando confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rd == DialogResult.No)
            {
                return;
            }
            QuitarFila(r);
            _serviciosTintes.Borrar(tintes.IdTinte);
            //traigo la lista actualizada
            listatintes = _serviciosTintes.GetTintes();
            MostrarDatosenGrilla();
        }

        private void QuitarFila(DataGridViewRow r)
        {
            dataGridViewTinte.Rows.Remove(r);
        }

        private void toolStripButtonNuevo_Click(object sender, EventArgs e)
        {
            FormularioTintesAE formulario = new FormularioTintesAE(_serviciosTintes);
            DialogResult dr = formulario.ShowDialog();

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            //obtener el clientes, se lo pido al formulario
            var tinte = formulario.GetTintes();
            //preguntar si existe 
            _serviciosTintes.Guardar(tinte);
            //preguntar la cantidad
            //_serviciosClientes.GetCantidad();
           listatintes = _serviciosTintes.GetTintes();
            MostrarDatosenGrilla();
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewTinte.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dataGridViewTinte.SelectedRows[0];
            Tintes tintes = (Tintes)r.Tag;
            Tintes tintesCopia = (Tintes)tintes.Clone();
            try
            {
                FormularioTintesAE tintesAE = new FormularioTintesAE(_serviciosTintes);
                tintesAE.SetTintes(tintes);
                DialogResult dr = tintesAE.ShowDialog();
                if (dr == DialogResult.No)
                {
                    return;
                }
                tintes = tintesAE.GetTintes();
                //preguntar si exite 
                _serviciosTintes.Guardar(tintes);
                SetearFila(r,tintes);
                MessageBox.Show($"Se edito el Tinte {tintes.Color}"
          , "Mansaje", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                SetearFila(r, tintesCopia);
                throw;
            }
        }
    }
}
