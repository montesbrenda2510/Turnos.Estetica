using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;
using Turnos.Estetica.Servicios.Servicios;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioMetododePago : Form
    {
        public FormularioMetododePago()
        {
            InitializeComponent();
            _serviciosMetododePago = new ServicioMetododePago();
        }
        
        readonly private IServicioMetododePago _serviciosMetododePago;
        private List<MetododePago> listaMetododePago;
        private void FormularioMetododePago_Load(object sender, EventArgs e)
        {
            try
            {
                listaMetododePago = _serviciosMetododePago.GetMetododePago();
                MostrarDatosenGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void MostrarDatosenGrilla()
        {
            dataGridViewMetododePago.Rows.Clear();
            foreach (var metododepago in listaMetododePago)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, metododepago);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dataGridViewMetododePago.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, MetododePago metododepago)
        {
            r.Cells[ColumnIdMetododepago.Index].Value = metododepago.IdMetododePago.ToString();
            r.Cells[ColumnTipodePago.Index].Value = metododepago.Tipodepago;
            r.Tag = metododepago;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridViewMetododePago);
            return r;
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewMetododePago.SelectedRows.Count == 0)
            {
                return;
            }

            var r =dataGridViewMetododePago.SelectedRows[0];
            MetododePago metododePago = (MetododePago)r.Tag;
            DialogResult rd = MessageBox.Show($"Estas seguro que quiere eliminar este {metododePago.Tipodepago}" +
          $" ??  ", "Esperando confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rd == DialogResult.No)
            {
                return;
            }
            QuitarFila(r);
            _serviciosMetododePago.Borrar(metododePago.IdMetododePago);
            //traigo la lista actualizada
            listaMetododePago = _serviciosMetododePago.GetMetododePago();
            MostrarDatosenGrilla();
        }
        private void QuitarFila(DataGridViewRow r)
        {
            dataGridViewMetododePago.Rows.Remove(r);
        }
        private void toolStripButtonNuevo_Click(object sender, EventArgs e)
        {
            FormularioMetododePagoAE formulario = new FormularioMetododePagoAE(_serviciosMetododePago);
            DialogResult dr = formulario.ShowDialog();

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            //obtener el clientes, se lo pido al formulario
            var metododePago = formulario.GetMetododepago();
            //preguntar si existe 
            _serviciosMetododePago.Guardar(metododePago);
            //preguntar la cantidad
            //_serviciosClientes.GetCantidad();
            listaMetododePago = _serviciosMetododePago.GetMetododePago();
            MostrarDatosenGrilla();
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {

            if (dataGridViewMetododePago.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dataGridViewMetododePago.SelectedRows[0];
            MetododePago metododePago = (MetododePago)r.Tag;
            MetododePago metodoCopia = (MetododePago)metododePago.Clone();
            try
            {
               FormularioMetododePagoAE metododePagoAE = new FormularioMetododePagoAE(_serviciosMetododePago);
                metododePagoAE.SetMetododePago(metododePago);
                DialogResult dr = metododePagoAE.ShowDialog();
                if (dr == DialogResult.No)
                {
                    return;
                }
                metododePago = metododePagoAE.GetMetododepago();
                //preguntar si exite 
                _serviciosMetododePago.Guardar(metododePago);
                SetearFila(r, metododePago);
                MessageBox.Show($"Se edito el metodo de pago {metododePago.Tipodepago} "
          , "Mansaje", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                SetearFila(r, metodoCopia);
                throw;
            }
        }
    }
}
