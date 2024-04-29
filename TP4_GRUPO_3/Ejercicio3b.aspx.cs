using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace TP4_GRUPO_3
{
    public partial class Ejercicio3b : System.Web.UI.Page
    {
        private const string stringConnection = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";
        private string consultaLibros = "SELECT * FROM Libros WHERE IdTema = ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                consultaLibros += Request.QueryString["temaId"];

                SqlConnection connection = new SqlConnection(stringConnection);
                connection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consultaLibros, connection);

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "TablaLibros");

                GVLibros.DataSource = dataSet.Tables["TablaLibros"];
                GVLibros.DataBind();

                connection.Close();
            }
        }
        protected void LblVolverAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ejercicio3.aspx");
        }
    }
}