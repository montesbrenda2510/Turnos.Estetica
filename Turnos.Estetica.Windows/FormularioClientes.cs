using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;
using Turnos.Estetica.Servicios.Servicios;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioClientes : Form
    {
        public FormularioClientes()
        {
            InitializeComponent();
            _serviciosClientes = new ServiciosClientes();
        }
        readonly private IServicioClientes _serviciosClientes;
        private List<Clientes> listaClientes;

        private void Formulario_Load(object sender, EventArgs e)
        {
            
        }

        private void MostrarDatosenGrilla()
        {
            dataGridViewCliente.Rows.Clear();
            foreach (var clientes in listaClientes)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, clientes);
                AgregarFila(r);
            }
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridViewCliente);
            return r;
        }

        private void SetearFila(DataGridViewRow r, Clientes clientes)
        {
            r.Cells[ColumnIdCliente.Index].Value = clientes.IdCliente;
            r.Cells[ColumnNombre.Index].Value = clientes.Nombre;
            r.Cells[ColumnApellido.Index].Value = clientes.Apellido;
            r.Cells[ColumnTel.Index].Value = clientes.Telefono;

            r.Tag = clientes;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dataGridViewCliente.Rows.Add(r);
        }

        private void FormularioClientes_Load(object sender, EventArgs e)
        {
            try
            {
                listaClientes = _serviciosClientes.GetCliente();
                MostrarDatosenGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void toolStripButtonNuevo_Click(object sender, EventArgs e)
        {
            FormularioClientesAE formulario = new FormularioClientesAE(_serviciosClientes);
            DialogResult dr = formulario.ShowDialog();

            if (dr==DialogResult.Cancel)
            {
                return;
            }
            //obtener el clientes, se lo pido al formulario
            var cliente = formulario.GetClinte();
            //preguntar si existe 
            _serviciosClientes.Guardar(cliente);
            //preguntar la cantidad
            //_serviciosClientes.GetCantidad();
            listaClientes = _serviciosClientes.GetCliente();
            MostrarDatosenGrilla();
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCliente.SelectedRows.Count==0)
            {
                return;
            }

            var r = dataGridViewCliente.SelectedRows[0];
            Clientes clientes = (Clientes)r.Tag;
            DialogResult rd = MessageBox.Show($"Estas seguro que quiere eliminar este {clientes.Nombre} {clientes.Apellido}" +
          $" ??  ", "Esperando confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rd==DialogResult.No)
            {
                return;
            }
            QuitarFila(r);
            _serviciosClientes.Borrar(clientes.IdCliente);
            //traigo la lista actualizada
            listaClientes = _serviciosClientes.GetCliente();
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
            Clientes clientes = (Clientes)r.Tag;
            Clientes clientesCopia = (Clientes)clientes.Clone();
            try
            {
                FormularioClientesAE clientesAE = new FormularioClientesAE(_serviciosClientes);
                clientesAE.SetCliente(clientes);
                DialogResult dr = clientesAE.ShowDialog();
                if (dr==DialogResult.No)
                {
                    return;
                }
                clientes = clientesAE.GetClinte();
                //preguntar si exite 
                _serviciosClientes.Guardar(clientes);
                SetearFila(r, clientes);
                MessageBox.Show($"Se edito el cliente {clientes.Nombre} {clientes.Apellido}" 
          , "Mansaje", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                SetearFila(r, clientesCopia);
                throw;
            }

        }

        private void dataGridViewCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
