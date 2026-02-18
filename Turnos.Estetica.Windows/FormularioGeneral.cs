using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Datos.Repositorios;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;
using Turnos.Estetica.Servicios.Interfas;
using Turnos.Estetica.Servicios.Servicios;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioGeneral : Form
    {
        public FormularioGeneral()
        {
            InitializeComponent();
            _serviciosGeneral = new ServicioGeneral();
            _servicioPerfilado = new ServicioPerfilados();
            _servicioPestania = new ServicioPestanias();
            _servicioUnia = new ServicioUnias();
            _horario = new RepositorioHorario();
            _turno = new RepositorioTurno();
            _servicioServicios = new ServicioServicios();
            _servicioClientes = new ServiciosClientes();
            _ServicioMetododePago = new ServicioMetododePago();

        }
        readonly private IServicioGeneral _serviciosGeneral;
        private List<GeneralDto> listaGeneral;
        private readonly IServicioUnias _servicioUnia;
        private readonly IServicioPestanias _servicioPestania;
        private readonly IServicioPerfilados _servicioPerfilado;
        private readonly IServicioGeneral _servicio;
        private readonly IRepositorioHorario _horario;
        private readonly IRepositorioTurno _turno;
        private readonly IServicioServicios _servicioServicios;
        private readonly IServicioClientes _servicioClientes;
        private readonly IServicioMetododePago _ServicioMetododePago;
        private void FormularioGeneral_Load(object sender, EventArgs e)
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
            listaGeneral = _serviciosGeneral.GetGeneralDto();
            MostrarDatosenGrilla();
        }

        private void MostrarDatosenGrilla()
        {
            dataGridViewCliente.Rows.Clear();
            foreach (var general in listaGeneral)
            {
                DataGridViewRow r = ConstruirFila(dataGridViewCliente);
                SetearFila(r, general);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dataGridViewCliente.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, GeneralDto general)
        {
            r.Cells[ColumnNomApe.Index].Value = general.Nombre;
            r.Cells[ColumnApellido.Index].Value = general.Apellido;
            r.Cells[ColumnDia.Index].Value = general.Dia;
            r.Cells[ColumnIngreso.Index].Value = general.Ingreso;
            r.Cells[ColumnEgreso.Index].Value = general.Egreso;
            r.Cells[ColumnTel.Index].Value = general.Telefono;
            r.Cells[ColumnUnia.Index].Value = general.TipodeServicio;
            r.Cells[ColumnPerfilado.Index].Value = general.TipodePerfilado;
            r.Cells[ColumnPestania.Index].Value = general.TipodePestania;
            r.Cells[ColumnPrecio.Index].Value = general.ValoraPagar;
            r.Cells[ColumnMtd.Index].Value = general.TipodePago;
            r.Cells[ColumnAsit.Index].Value = general.Asistencia;
            r.Tag = general;

        }

        private DataGridViewRow ConstruirFila(DataGridView dataGridViewCliente)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dataGridViewCliente);
            return r;
        }

        private void toolStripButtonNuevo_Click(object sender, EventArgs e)
        {
            FormularioGeneralAE frm = new FormularioGeneralAE(
         _serviciosGeneral,
         _servicioPerfilado,
         _servicioPestania,
         _servicioUnia,
         _turno,
         _horario,
         _servicioServicios,
         _servicioClientes,
         _ServicioMetododePago);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                InicializarGrilla();
            }
        }

            private void ButtonFiltrar_Click(object sender, EventArgs e)
        {
            ButtonFiltrar.Text = "";

        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCliente.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dataGridViewCliente.SelectedRows[0];
            GeneralDto general = (GeneralDto)r.Tag;
            DialogResult rd = MessageBox.Show($"Estas seguro que quiere eliminar este {general.Ingreso}{general.Egreso} {general.Apellido}" +
                $"{general.Nombre}" +
          $" ??  ", "Esperando confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (rd == DialogResult.No)
            {
                return;
            }
            QuitarFila(r);
            _serviciosGeneral.Borrar(general.IdGeneral);
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
            GeneralDto general = (GeneralDto)r.Tag;
            GeneralDto generalCopia = (GeneralDto)general.Clone();
            General general1 = _serviciosGeneral.GetGeneralPorId(general.IdGeneral);

            try
            {
                FormularioGeneralAE generalAE = new FormularioGeneralAE(_serviciosGeneral, 
                    _servicioPerfilado, _servicioPestania, _servicioUnia, _turno,_horario,
                    _servicioServicios, _servicioClientes,_ServicioMetododePago);
                generalAE.SetGeneral(general1);
                DialogResult dr = generalAE.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                var general2 = generalAE.GetGeneral();
                //preguntar si exite 
                //_serviciosGeneral.Guardar(general2);
                InicializarGrilla();

                MessageBox.Show($"Se edito el turno completo: {general.IdGeneral} "
          , "Mansaje", MessageBoxButtons.OK);
            }
            catch (Exception)
            {
                SetearFila(r, generalCopia);
                throw;
            }
        }

        private void ButtonSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nombreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ButtonFiltrar_TextChanged(object sender, EventArgs e)
        {
            var texto = ButtonFiltrar.Text;
            BuscarCliente(listaGeneral, texto);
        }

        private void BuscarCliente(List<GeneralDto> listaGeneral, string texto)
        {

            var listaFiltrada = listaGeneral;
            if (texto.Length != 0)
            {
                Func<GeneralDto, bool> condicion = c => c.Apellido.ToUpper().Contains(texto.ToUpper()) || c.Nombre.ToUpper().Contains(texto.ToUpper()) || c.Telefono.Contains(texto.ToUpper());
                listaFiltrada = listaGeneral.Where(condicion).ToList();
            }

            MostrarDatosEnGrilla<GeneralDto>(dataGridViewCliente, listaFiltrada);

        }

        private void MostrarDatosEnGrilla<T>(DataGridView dataGridViewCliente, List<GeneralDto> listaFiltrada)
        {
            dataGridViewCliente.Rows.Clear();
            foreach (var obj in listaFiltrada)
            {
                DataGridViewRow r = ConstruirFila(dataGridViewCliente);
                SetearFila(r, obj);


                AgregarFila(dataGridViewCliente, r);
            }
        }

        private void AgregarFila(DataGridView dataGridViewCliente, DataGridViewRow r)
        {
          dataGridViewCliente.Rows.Add(r);
        }
    }
}
