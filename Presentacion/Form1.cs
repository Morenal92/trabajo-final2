using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using dominio;



namespace Presentacion
{
    public partial class FrmArticulos : Form
    {

        private List<Articulo> listaArticulo;
        public FrmArticulos()
        {
            InitializeComponent();
        }

  

        private void FrmArticulos_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulo = negocio.listar();
            dgvArticulos.DataSource = listaArticulo;
            cargarImagen(listaArticulo[0].ImagenUrl);
        }

     

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.ImagenUrl);
        }
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception)
            {

                pbxArticulo.Load("https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png");
            }
            
        }
    }
}
