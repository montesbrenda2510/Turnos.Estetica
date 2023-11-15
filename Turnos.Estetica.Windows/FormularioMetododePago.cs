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


    }
}
