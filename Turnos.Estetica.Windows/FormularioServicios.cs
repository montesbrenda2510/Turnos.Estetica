using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;
using Turnos.Estetica.Servicios.Interfas;
using Turnos.Estetica.Servicios.Servicios;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioServicios : Form
    {
        public FormularioServicios()
        {
            InitializeComponent();
            _servicioServicio = new ServicioServicios();
            _servicioUnia = new ServicioUnias();
            _servicioPestania = new ServicioPestanias();
            _servicioPerfilado = new ServicioPerfilados();
        }
        readonly private IServicioServicios _servicioServicio;
        private readonly IServicioUnias _servicioUnia;
        private readonly IServicioPestanias _servicioPestania;
        private readonly IServicioPerfilados _servicioPerfilado;
        private List<ServicioDto> listaServicio;

        private void FormularioServicios_Load(object sender, EventArgs e)
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
            listaServicio = _servicioServicio.GetServicioDto();
            MostrarDatosenGrilla();
        }

        private void MostrarDatosenGrilla()
        {
            dataGridViewCliente.Rows.Clear();
            foreach (var servicio in listaServicio)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, servicio);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dataGridViewCliente.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ServicioDto servicio)
        {
            r.Cells[ColumnDetalle.Index].Value = servicio.TipodeServicioUnia;
            r.Cells[ColumnPer.Index].Value = servicio.TipodePerfilado;
            r.Cells[ColumnColorPer.Index].Value = servicio.colorPerfilado;
            //r.Cells[ColumnPestania.Index].Value = servicio.TipodePestenia;
            r.Cells[ColumnColorPes.Index].Value = servicio.ColorPestania;

            r.Cells[ColumnValoraPagar.Index].Value = servicio.ValoraPagar;
            r.Tag = servicio;
        }


        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridViewCliente);
            return r;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButtonNuevo_Click(object sender, EventArgs e)
        {
            FormularioServiciosAE formulario = new FormularioServiciosAE(_servicioServicio, _servicioPerfilado, _servicioPestania, _servicioUnia);
            DialogResult dr = formulario.ShowDialog();

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            //obtener el clientes, se lo pido al formulario
            var servicio = formulario.GetServicio();
            //preguntar si existe 
            _servicioServicio.Guardar(servicio);
            //preguntar la cantidad 
            //_serviciosClientes.GetCantidad();
            InicializarGrilla();
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCliente.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dataGridViewCliente.SelectedRows[0];
            ServicioDto servicio = (ServicioDto)r.Tag;
            DialogResult rd = MessageBox.Show($"Estas seguro que quiere eliminar este {servicio.TipodeServicioUnia}" +
                $"{servicio.TipodePestenia}, {servicio.TipodePerfilado}" +
          $" ??  ", "Esperando confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rd == DialogResult.No)
            {
                return;
            }
            QuitarFila(r);
            _servicioServicio.Borrar(servicio.IdServicio);
            //traigo la lista actualizada
            InicializarGrilla();
        }

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
            ServicioDto servicio = (ServicioDto)r.Tag;
            ServicioDto servicioCopia = (ServicioDto)servicio.Clone();
            Servicio servicio1 = _servicioServicio.GetServicioPorId(servicio.IdServicio);

            try
            {
                FormularioServiciosAE servicioAE = new FormularioServiciosAE(_servicioServicio, _servicioPerfilado, _servicioPestania, _servicioUnia);
                servicioAE.SetPerfilado(servicio1);
                DialogResult dr = servicioAE.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                var servicio2 = servicioAE.GetServicio();
                //preguntar si exite 
                _servicioServicio.Guardar(servicio2);
                InicializarGrilla();
                MessageBox.Show($"Se edito el servicio "
          , "Mansaje", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                SetearFila(r, servicioCopia);
                throw;
            }
        }
    }
}
