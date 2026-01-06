using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Turnos.Estetica.Entetidades.Combos;
using Turnos.Estetica.Servicios.Interfas;
using Turnos.Estetica.Servicios.Servicios;

namespace Turnos.Estetica.Windows.Combos
{
    public static class CombosHelpers
    {

        //public static void CargarComboGeneral(ref ComboBox combo)
        //{
        //    IServicioGeneral serviciosGeneral = new ServicioGeneral();
        //    var lista = serviciosGeneral.GetGeneralDto();
        //    var combosDto = new GeneralCombosDto()
        //    {
        //        IdGeneral = 0,
        //        NomApe = "Seleccione el Tipo de Pago"
        //    };
        //    lista.Insert(0, combosDto);
        //    combo.DataSource = lista;
        //    combo.DisplayMember = "NomApe";
        //    combo.ValueMember = "IdGeneral";
        //    combo.SelectedIndex = 0;
        //}

        //public static void CargarComboServicio(ref ComboBox combo)
        //{
        //    IServicioServicios serviciosServicio = new ServicioServicios();
        //    var lista = serviciosServicio.GetServicioDto();
        //    var defaultPais = new TiposDePagos()
        //    {
        //        IdTipoPago = 0,
        //        Tipo = "Seleccione el Tipo de Pago"
        //    };
        //    lista.Insert(0, defaultPais);
        //    combo.DataSource = lista;
        //    combo.DisplayMember = "Tipo";
        //    combo.ValueMember = "IdTipoPago";
        //    combo.SelectedIndex = 0;
        //}
    }
}
