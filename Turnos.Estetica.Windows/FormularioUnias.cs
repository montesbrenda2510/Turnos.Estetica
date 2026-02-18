using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;
using Turnos.Estetica.Servicios.Servicios;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioUnias : Form
    {
        public FormularioUnias()
        {
            InitializeComponent();
            _serviciosUnias = new ServicioUnias();
        }

        readonly private IServicioUnias _serviciosUnias;
        private List<Unias> listaUnias;

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FormularioUñas_Load(object sender, EventArgs e)
        {
            try
            {
                listaUnias = _serviciosUnias.GetUnia();
                MostrarDatosenGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosenGrilla()
        {
            dataGridViewUnia.Rows.Clear();
            foreach (var unias in listaUnias)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, unias);
                AgregarFila(r);
            }

        }

        private void AgregarFila(DataGridViewRow r)
        {
            dataGridViewUnia.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Unias unias)
        {
            r.Cells[ColumnIdUña.Index].Value = unias.IdUnia;
            r.Cells[ColumnServicio.Index].Value = unias.TipodeServicioUnia;
            r.Cells[ColumnValor.Index].Value = unias.Valor;
            r.Tag = unias;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridViewUnia);
            return r;
        }

        private void toolStripButtonNuevo_Click(object sender, EventArgs e)
        {
            FormularioUñasAE formulario = new FormularioUñasAE(_serviciosUnias);
            DialogResult dr = formulario.ShowDialog();

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            //obtener el clientes, se lo pido al formulario
            var unia = formulario.GetUnia();
            //preguntar si existe 
            _serviciosUnias.Guardar(unia);
            //preguntar la cantidad
            //_serviciosClientes.GetCantidad();
            listaUnias = _serviciosUnias.GetUnia();
            MostrarDatosenGrilla();
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewUnia.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dataGridViewUnia.SelectedRows[0];
           Unias unias = (Unias)r.Tag;
            DialogResult rd = MessageBox.Show($"Estas seguro que quiere eliminar este servicio {unias.TipodeServicioUnia} " +
          $" ??  ", "Esperando confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rd == DialogResult.No)
            {
                return;
            }
            QuitarFila(r);
            _serviciosUnias.Borrar(unias.IdUnia);
            //traigo la lista actualizada
            listaUnias = _serviciosUnias.GetUnia();
            MostrarDatosenGrilla();
        }

        private void QuitarFila(DataGridViewRow r)
        {
            dataGridViewUnia.Rows.Remove(r);
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewUnia.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dataGridViewUnia.SelectedRows[0];
            Unias unias = (Unias)r.Tag;
            Unias uniaCopia = (Unias)unias.Clone();
            try
            {
                FormularioUñasAE uniasAE = new FormularioUñasAE(_serviciosUnias);
                uniasAE.SetTintes(unias);
                DialogResult dr = uniasAE.ShowDialog();
                if (dr == DialogResult.No)
                {
                    return;
                }
                unias= uniasAE.GetUnia();
                //preguntar si exite 
                _serviciosUnias.Guardar(unias);
                SetearFila(r, unias);
                MessageBox.Show($"Se edito el sevicio uña {unias.TipodeServicioUnia} " +
                    $"con un valor de {unias.Valor}"
          ,         "Mansaje", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                SetearFila(r, uniaCopia);
                throw;
            }
        }

        private void dataGridViewUnia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
