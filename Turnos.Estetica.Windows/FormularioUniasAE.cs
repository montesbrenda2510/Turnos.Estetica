using System;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Entidades;
using Turnos.Estetica.Servicios.Interfas;

namespace Turnos.Estetica.Windows
{
    public partial class FormularioUñasAE : Form
    {
        private readonly IServicioUnias _servicio;
        public FormularioUñasAE(IServicioUnias servicio)
        {
            InitializeComponent();
            _servicio = servicio;

        }
        private Unias unias;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (unias != null)
            {
                textBoxValor.Text = unias.Valor.ToString();

                textBoxServicio.Text = unias.TipodeServicio;
            }
        }

        private void FormularioUñasAE_Load(object sender, EventArgs e)
        {

        }
        public Unias GetUnia()
        {
            return unias;
        }
        public Unias SetTintes(Unias unias)
        {
            return unias;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (unias == null)
            {
                unias = new Unias();
            }
            unias.TipodeServicio = textBoxServicio.Text;
            unias.Valor = decimal.Parse(textBoxValor.Text);
            DialogResult = DialogResult.OK;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
