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
    public partial class FormularioTintesAE : Form
    {
        private readonly IServiciosTintes _servicio;
        public FormularioTintesAE(IServiciosTintes servicios)
        {
            InitializeComponent();
            _servicio = servicios;
        }
       
        private Tintes tintes;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tintes!=null)
            {
                textBoxColorTinte.Text = tintes.Color;
            }
        }


        private void labelTintes_Click(object sender, EventArgs e)
        {

        }

        private void FormularioTintesAE_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (tintes==null)
            {
                tintes = new Tintes();
            }
            tintes.Color = textBoxColorTinte.Text;
            DialogResult= DialogResult.OK;  
        }

        public Tintes GetTintes()
        {
            return tintes;
        }
        public Tintes SetTintes(Tintes tintes)
        {
            return tintes;
        }

      
    }
}
