using System;
using System.Windows.Forms;
using Turnos.Estetica.Comun.Interfases;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Entetidades.EntidadesDto;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioGeneralAE : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CargarDatosComboCliente(ref comboBoxCliente);
            CargarDatosComboServicio(ref comboBoxUnia);
            CargarDatosComboTurno(ref comboBoxTurno);
            CargarDatosComboMetododePago(ref comboBoxMdPago);
            if (general != null)
            { 
                var turno = _turno.GetTurnoPorId(general.IdTurno);
                var horario = _horario.GetHorarioPorId(turno.IdHorario);
                comboBoxCliente.SelectedValue = general.IdCliente;
                
                comboBoxTurno.SelectedValue = general.IdTurno;
                comboBoxMdPago.SelectedValue = general.IdMetododepago;
      
                comboBoxUnia.SelectedValue = general.IdServicio;

            }
        }

        private void CargarDatosComboMetododePago(ref ComboBox comboBoxMdPago)
        {
            var listaMetododePago = _servicioMetododePago.GetMetododePago();
            MetododePago defaultMetododePago = new MetododePago()
            {
                IdMetododePago= 0,
                Tipodepago= "Seleccione el un MetododePago"
            };
            listaMetododePago.Insert(0, defaultMetododePago);
            comboBoxMdPago.DataSource = listaMetododePago;
            comboBoxMdPago.DisplayMember = "TipodePago";
            comboBoxMdPago.ValueMember = "IdMetododePago";

            comboBoxMdPago.SelectedIndex = 0;
        }

        private void CargarDatosComboTurno(ref ComboBox comboBoxTurno)
        {
            var listaTurno = _turno.GetCombosDto();
            TurnocomboDto defaultTurno = new TurnocomboDto()
            {
                IdTurno = 0,
                Detalle= "Seleccione el un Turno"
            };
            listaTurno.Insert(0, defaultTurno);
            comboBoxTurno.DataSource = listaTurno;
            comboBoxTurno.DisplayMember = "Detalle";
            comboBoxTurno.ValueMember = "IdTurno";

            comboBoxTurno.SelectedIndex = 0;
        }

        private void CargarDatosComboServicio(ref ComboBox comboBoxUnia)
        {
            var listaServicio = _servicioServicio.GetCombosDto();
            ServicioComboDto defaultTurno = new ServicioComboDto()
            {
                IdServicio = 0,
                Detalle = "Seleccione el un Servicio"
               
            };
            listaServicio.Insert(0, defaultTurno);
            comboBoxUnia.DataSource = listaServicio;
            comboBoxUnia.DisplayMember = "Detalle";
            comboBoxUnia.ValueMember = "IdServicio";

            comboBoxUnia.SelectedIndex = 0;
        }

        private void CargarDatosComboCliente(ref ComboBox comboBoxCliente)
        {
            var listacliente = _serviciocliente.GetCombosDto();
            ClientesComboDto defaultcliente = new ClientesComboDto()
            {
                IdCliente = 0,
                Detalle = "Seleccione el un Cliente"

            };
            listacliente.Insert(0, defaultcliente);
            comboBoxCliente.DataSource = listacliente;
            comboBoxCliente.DisplayMember = "Detalle";
            comboBoxCliente.ValueMember = "IdCliente";

            comboBoxCliente.SelectedIndex = 0;
        }

        private void CargarDatosComboUnia(ref System.Windows.Forms.ComboBox comboBoxUnias)
        {
            var listaUnias = _servicioUnia.GetUnia();
            Unias defaultUnia = new Unias()
            {
                IdUnia = 0,
                TipodeServicio = "Seleccione el un tipo de servicio Unia"
            };
            listaUnias.Insert(0, defaultUnia);
            comboBoxUnias.DataSource = listaUnias;
            comboBoxUnias.DisplayMember = "TipodeServicio";
            comboBoxUnias.ValueMember = "IdUnia";

            comboBoxUnias.SelectedIndex = 0;
        }

        private void CargarDatosComboPestania(ref System.Windows.Forms.ComboBox cmboxColorPestania)
        {
            var listaPestania = _servicioPestania.GetCombosDto();
            PestaniaComboDto defaultPestania = new PestaniaComboDto()
            {
                IdPestania = 0,
                Detalle = "Seleccione un servicio de Pestania"
            };
            listaPestania.Insert(0, defaultPestania);//Ayudaaa
            cmboxColorPestania.DataSource = listaPestania;
            cmboxColorPestania.DisplayMember = "Detalle";
            cmboxColorPestania.ValueMember = "IdPestania";

            cmboxColorPestania.SelectedIndex = 0;
        }

        private void CargarDatosComboPerfilado(ref System.Windows.Forms.ComboBox comboBoxPerfilado)
        {
            var listaPerfilado = _servicioPerfilado.GetCombosDto();
            PerfiladoComboDto defaultPerfilado = new PerfiladoComboDto()
            {
                IdPerfilado = 0,
                Detalle = "Seleccione un servicio de Perfilado"
            };
            listaPerfilado.Insert(0, defaultPerfilado);//Ayudaaa
            comboBoxPerfilado.DataSource = listaPerfilado;
            comboBoxPerfilado.DisplayMember = "Detalle";
            comboBoxPerfilado.ValueMember = "IdPerfilado";

            comboBoxPerfilado.SelectedIndex = 0;
        }
        private readonly IServicioUnias _servicioUnia;
        private readonly IServicioPestanias _servicioPestania;
        private readonly IServicioPerfilados _servicioPerfilado;
        private readonly IServicioClientes _serviciocliente;
        private readonly IRepositorioTurno _turno;
       private readonly IRepositorioHorario _horario;
        private readonly IServicioGeneral _servicio;
        private readonly IServicioServicios _servicioServicio;
        private readonly IServicioMetododePago _servicioMetododePago; 
        public FormularioGeneralAE(IServicioGeneral servicio,IServicioPerfilados perfilados,
            IServicioPestanias pestanias,IServicioUnias unias,IRepositorioTurno turno,
            IRepositorioHorario horario, IServicioServicios servicioServicios,IServicioClientes clientes,
            IServicioMetododePago metododePago)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioPerfilado = perfilados;
            _servicioPestania = pestanias;
            _servicioUnia = unias;
            _turno = turno;
            _horario = horario;
            _servicioServicio = servicioServicios;
            _serviciocliente = clientes;
            _servicioMetododePago = metododePago; 
        }
        private General general;


        private void FormularioGeneralAE_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

            if (ValidarDatos())
            {
                if (general == null)
                {
                    general = new General();

                }

                general.IdCliente =(int)comboBoxCliente.SelectedValue;
              
                general.IdServicio=(int)comboBoxUnia.SelectedValue;
                general.IdMetododepago = (int)comboBoxMdPago.SelectedValue;

                general.IdTurno = (int)comboBoxTurno.SelectedValue;
                general.Asistencia = textBoxAsistencia.Text;
                


                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (comboBoxUnia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(comboBoxUnia, "Debe colocar un Tipo de servicio");
            }
            if (comboBoxCliente.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(comboBoxCliente, "Debe seleccionar un cliente");
            }
            if (comboBoxMdPago.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(comboBoxMdPago, "Debe seleccionar un metodo de pago");
            }
            if (comboBoxTurno.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(comboBoxTurno, "Debe seleccionar un Turno");
            }
            if (string.IsNullOrEmpty(textBoxAsistencia.Text))
            {
                valido = false;
                errorProvider1.SetError(textBoxAsistencia, "Debe colocar la asistencia");
            }

            return valido;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }



        internal General GetGeneral()
        {
            return general;
        }

        internal void SetGeneral(General general1)
        {
            this.general = general1;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }

}
