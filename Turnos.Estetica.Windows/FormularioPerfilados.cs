using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;
using Turnos.Estetica.Servicios.Interfas;
using Turnos.Estetica.Servicios.Servicios;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioPerfilados : Form
    {
        public FormularioPerfilados()
        {
            InitializeComponent();
            _servicioPerfilado = new ServicioPerfilados();
        }
        readonly private IServicioPerfilados _servicioPerfilado;
        private List<PerfiladoDto> listaPerfilado;


        private void FormularioPerfilados_Load(object sender, EventArgs e)
        {
            try
            {
                listaPerfilado = _servicioPerfilado.GetPerfilado();
                MostrarDatosenGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosenGrilla()
        {
            dataGridViewPerfilado.Rows.Clear();
            foreach (var perfilado in listaPerfilado)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, perfilado);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dataGridViewPerfilado.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, PerfiladoDto perfilado)
        {
            r.Cells[Columntipo.Index].Value = perfilado.TipodePerfilado.ToString();
            r.Cells[ColumnTinte.Index].Value = perfilado.Color;
            r.Cells[ColumnTotal.Index].Value = perfilado.Valor;
            r.Tag = perfilado;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridViewPerfilado);
            return r;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButtonNuevo_Click(object sender, EventArgs e)
        {
            FormularioPerfiladoAE formulario = new FormularioPerfiladoAE(_servicioPerfilado);
            DialogResult dr = formulario.ShowDialog();

            if (dr == DialogResult.No)
            {
                return;
            }
            //obtener el clientes, se lo pido al formulario
            var perfilado = formulario.GetPerfilado();
            //preguntar si existe 

            _servicioPerfilado.Guardar(perfilado);
            //preguntar la cantidad
            //_serviciosClientes.GetCantidad();
            listaPerfilado = _servicioPerfilado.GetPerfilado();
            MostrarDatosenGrilla();
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPerfilado.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dataGridViewPerfilado.SelectedRows[0];
            PerfiladoDto perfilado = (PerfiladoDto)r.Tag;
            DialogResult rd = MessageBox.Show($"Estas seguro que quiere eliminar este {perfilado.TipodePerfilado}" +
          $" ??  ", "Esperando confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rd == DialogResult.No)
            {
                return;
            }
            QuitarFila(r);
            _servicioPerfilado.Borrar(perfilado.IdPerfilado);
            //traigo la lista actualizada
            listaPerfilado = _servicioPerfilado.GetPerfilado();
            MostrarDatosenGrilla();
        }
        //saca la fila
        private void QuitarFila(DataGridViewRow r)
        {
            dataGridViewPerfilado.Rows.Remove(r);
        }
    

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewPerfilado.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dataGridViewPerfilado.SelectedRows[0];
            PerfiladoDto perfilado = (PerfiladoDto)r.Tag;
            PerfiladoDto perfiladoCopia = (PerfiladoDto)perfilado.Clone();
            Perfilado perfilado1 = _servicioPerfilado.GetPerfiladPorId(perfilado.IdPerfilado);

            try
            {
                FormularioPerfiladoAE perfiladoAE = new FormularioPerfiladoAE(_servicioPerfilado);
                perfiladoAE.SetPerfilado(perfilado1);
                DialogResult dr = perfiladoAE.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                var perfilado2 = perfiladoAE.GetPerfilado();
                //preguntar si exite 
                _servicioPerfilado.Guardar(perfilado2);
                MostrarDatosenGrilla();
                MessageBox.Show($"Se edito el perfilado {perfilado.TipodePerfilado} "
          , "Mansaje", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                SetearFila(r, perfiladoCopia);
                throw;
            }
        }
    }
}
