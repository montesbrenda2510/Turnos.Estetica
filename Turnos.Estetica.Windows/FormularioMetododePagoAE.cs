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

namespace Turnos.Estetica.Windows
{
    public partial class FormularioMetododePagoAE : Form
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (metododePago != null)
            {
                textBoxMetododePago.Text = metododePago.Tipodepago;
            }
        }
        public FormularioMetododePagoAE(IServicioMetododePago servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private MetododePago metododePago;
        private readonly IServicioMetododePago _servicio;
       

        private void FormularioMetododePagoAE_Load(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (metododePago == null)
            {
                metododePago = new MetododePago();
            }
            metododePago.Tipodepago = textBoxMetododePago.Text;
            DialogResult = DialogResult.OK;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; 
        }

        public MetododePago GetMetododepago()
        {
            return metododePago;
        }
        public MetododePago SetMetododePago(MetododePago metododePago)
        {
            return metododePago;
        }
    }
}
