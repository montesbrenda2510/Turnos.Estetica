using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;
using Turnos.Estetica.Servicios.Interfas;
using Turnos.Estetica.Servicios.Servicios;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioPestanias : Form
    {
        public FormularioPestanias()
        {
            InitializeComponent();
            _servicioPestania = new ServicioPestanias();
        }
        readonly private IServicioPestanias _servicioPestania;
        private List<PestaniasDto> listaPestanias;

        private void FormularioPestanias_Load(object sender, EventArgs e)
        {
            try
            {
                InicializarGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void InicializarGrilla()
        {
            listaPestanias = _servicioPestania.GetPestaniasDto();
            MostrarDatosenGrilla();
        }

        private void MostrarDatosenGrilla()
        {
            dataGridViewCliente.Rows.Clear();
            foreach (var pestanias in listaPestanias)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, pestanias);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dataGridViewCliente.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, PestaniasDto pestanias)
        {
            r.Cells[Columntipo.Index].Value = pestanias.TipodePestania.ToString();
            r.Cells[ColumnTinte.Index].Value = pestanias.Color;
            r.Cells[ColumnTotal.Index].Value = pestanias.Valor;
            r.Tag = pestanias;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridViewCliente);
            return r;
        }

        private void toolStripButtonNuevo_Click(object sender, EventArgs e)
        {
            FormularioPestaniaAE formulario = new FormularioPestaniaAE(_servicioPestania);
            DialogResult dr = formulario.ShowDialog();

            if (dr == DialogResult.No)
            {
                return;
            }
            //obtener el clientes, se lo pido al formulario
           var pestania= formulario.GetPestania();
            //preguntar si existe 

            _servicioPestania.Guardar(pestania);
            //preguntar la cantidad
            //_serviciosClientes.GetCantidad();
            listaPestanias = _servicioPestania.GetPestaniasDto();
            MostrarDatosenGrilla();
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {

            if (dataGridViewCliente.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dataGridViewCliente.SelectedRows[0];
            PestaniasDto pestania = (PestaniasDto)r.Tag;
            DialogResult rd = MessageBox.Show($"Estas seguro que quiere eliminar este {pestania.TipodePestania}" +
          $" ??  ", "Esperando confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rd == DialogResult.No)
            {
                return;
            }
            QuitarFila(r);
            _servicioPestania.Borrar(pestania.IdPestania);
            //traigo la lista actualizada
            listaPestanias = _servicioPestania.GetPestaniasDto();
            MostrarDatosenGrilla();
        }
        //saca la fila
        private void QuitarFila(DataGridViewRow r)
        {
            dataGridViewCliente.Rows.Remove(r);
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCliente.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dataGridViewCliente.SelectedRows[0];
            PestaniasDto pestanias = (PestaniasDto)r.Tag;
            PestaniasDto pestaniaCopia = (PestaniasDto)pestanias.Clone();
            Pestanias pestania1 = _servicioPestania.GetPerfiladPorId(pestanias.IdPestania);

            try
            {
                FormularioPestaniaAE pestaniaAE = new FormularioPestaniaAE(_servicioPestania);
                pestaniaAE.SetPerfilado(pestania1);
                DialogResult dr = pestaniaAE.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                var pestania2 = pestaniaAE.GetPestania();
                //preguntar si exite 
               _servicioPestania.Guardar(pestania2);
                InicializarGrilla();
                MessageBox.Show($"Se edito el servicio Pestañia {pestanias.TipodePestania} "
          , "Mansaje", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                SetearFila(r, pestaniaCopia);
                throw;
            }
        }
    }
}
