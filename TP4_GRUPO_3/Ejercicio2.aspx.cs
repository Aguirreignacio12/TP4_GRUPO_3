using System;
using System.Data.SqlClient;
using System.Data;

namespace TP4_GRUPO_3
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        private const string stringConnection = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True";
        private readonly string consultaProductos = "SELECT * FROM Productos";
        private string consultaIdProductos = "SELECT * FROM Productos WHERE ";
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


        protected void BtnQuitarFiltro_Click(object sender, EventArgs e)
        {
            LimpiarTxtBox();
            CargarProductos();
        }

        protected void BtnFiltro_Click(object sender, EventArgs e)
        {
            if (!TxtBoxProducto.Text.Equals("") && TxtBoxCategoria.Text.Equals(""))
            {
                consultaIdProductos += DDLProducto.SelectedValue + TxtBoxProducto.Text;

                SqlConnection connection = new SqlConnection(stringConnection);
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(consultaIdProductos, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                GvProductos.DataSource = sqlDataReader;
                GvProductos.DataBind();

                connection.Close();
            }
            else
            {
                if (TxtBoxProducto.Text.Equals("") && !TxtBoxCategoria.Text.Equals(""))
                {
                    consultaIdProductos += DDLCategoria.SelectedValue + TxtBoxCategoria.Text;

                    SqlConnection connection = new SqlConnection(stringConnection);
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(consultaIdProductos, connection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    GvProductos.DataSource = sqlDataReader;
                    GvProductos.DataBind();

                    connection.Close();
                }
                else
                {
                    if (!TxtBoxProducto.Text.Equals("") && !TxtBoxCategoria.Text.Equals(""))
                    {
                        consultaIdProductos += DDLProducto.SelectedValue + TxtBoxProducto.Text + " AND " + DDLCategoria.SelectedValue + TxtBoxCategoria.Text;

                        SqlConnection connection = new SqlConnection(stringConnection);
                        connection.Open();

                        SqlCommand sqlCommand = new SqlCommand(consultaIdProductos, connection);
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                        GvProductos.DataSource = sqlDataReader;
                        GvProductos.DataBind();

                        connection.Close();
                    }
                    else
                    {
                        CargarProductos();
                    }
                }
            }
        }
    }
}