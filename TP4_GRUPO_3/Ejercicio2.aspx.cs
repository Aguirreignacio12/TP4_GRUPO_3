using System;
using System.Data.SqlClient;
using System.Data;

namespace TP4_GRUPO_3
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        private const string stringConnection = @"Data Source=DESKTOP-2MB1JSO\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True";
        private readonly string consultaProductos = "SELECT * FROM Productos";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();

            }
        }


        private void LimpiarTxtBox()
        {
            TxtBoxProducto.Text = "";
            TxtBoxCategoria.Text = "";
        }

        private void CargarProductos()
        {
            //Conexión DB
            SqlConnection connection = new SqlConnection(stringConnection);
            connection.Open();

            //Consulta SQL
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consultaProductos, connection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "TablaProductos");

            //asignación de datos al GridView
            GvProductos.DataSource = dataSet.Tables["TablaProductos"];
            GvProductos.DataBind();

            connection.Close();

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnQuitarFiltro_Click(object sender, EventArgs e)
        {
            LimpiarTxtBox();
            CargarProductos();
        }
    }
}