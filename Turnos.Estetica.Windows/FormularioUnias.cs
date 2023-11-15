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
            r.Cells[ColumnServicio.Index].Value = unias.TipodeServicio;
            r.Cells[ColumnValor.Index].Value = unias.Valor;
            r.Tag = unias;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridViewUnia);
            return r;
        }
    }
}
