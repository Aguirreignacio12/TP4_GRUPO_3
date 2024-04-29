using System;
using System.Data.SqlClient;
using System.Data;
namespace TP4_GRUPO_3
{
    public partial class Ejercicio3 : System.Web.UI.Page
    {
        private const string stringConnection = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Libreria;Integrated Security=True";
        private string consultaTemas = "SELECT * FROM Temas";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //estableciendo conexión
                CargarTemas();

            }
        }
        private void CargarTemas()
        {
            //estableciendo conexión
            SqlConnection connection = new SqlConnection(stringConnection);
            connection.Open();

            //Consulta SQL
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(consultaTemas, connection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "TablaTemas");

            //Asignación
            DDLTemas.DataSource = dataSet.Tables["TablaTemas"];
            DDLTemas.DataTextField = "Tema";
            DDLTemas.DataValueField = "IdTema";
            DDLTemas.DataBind();

            connection.Close();
        }

        protected void LblVerLibros_Click(object sender, EventArgs e)
        {
            // Tema seleccionado
            string temaId = DDLTemas.SelectedValue;

            // Redirección
            Response.Redirect("Ejercicio3b.aspx?temaId=" + temaId);
        }
    }
}