using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TP4_GRUPO_3
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        private const string stringConexion = @"Data Source=DESKTOP-2MB1JSO\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
        private readonly string consultaProvincias = "SELECT * FROM Provincias";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();

                //Asignación de valor inicial a los DDL
                DDLInicioLocalidades.Items.Insert(0, new ListItem("-- Seleccionar --", ""));
                DDLFinalLocalidades.Items.Insert(0, new ListItem("-- Seleccionar --", ""));
            }
        }

        private void CargarProvincias()
        {
            try
            {
                //Conexión a la base de datos
                SqlConnection connection = new SqlConnection(stringConexion);
                connection.Open();

                //Consulta SQL
                SqlCommand sqlCommand = new SqlCommand(consultaProvincias, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                //asignación de valores a DDLInicio
                DDLInicioProvincias.DataSource = sqlDataReader;
                DDLInicioProvincias.DataTextField = "NombreProvincia";
                DDLInicioProvincias.DataValueField = "IdProvincia";
                DDLInicioProvincias.DataBind();

                //liberación de recursos para nueva consulta
                sqlDataReader.Close();

                //Consulta SQL
                sqlCommand = new SqlCommand(consultaProvincias, connection);
                SqlDataReader sqlDataReader2 = sqlCommand.ExecuteReader();

                //asignación de valores a DDLFinal
                DDLFinalProvincias.DataSource = sqlDataReader2;
                DDLFinalProvincias.DataTextField = "NombreProvincia";
                DDLFinalProvincias.DataValueField = "IdProvincia";
                DDLFinalProvincias.DataBind();

                //Asignación de valor inicial a los DDL
                DDLInicioProvincias.Items.Insert(0, new ListItem("-- Seleccionar --", ""));
                DDLFinalProvincias.Items.Insert(0, new ListItem("-- Seleccionar --", ""));

                connection.Close();
            }
            catch (Exception err)
            {
                lblError.Text = "Error al cargar Provincias: " + err.Message;
            }
        }

        protected void DDLInicioProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string provinciaInicioId = DDLInicioProvincias.SelectedValue;

                // Carga de datos
                CargarLocalidades(provinciaInicioId, DDLInicioLocalidades);

                // Habilitar todas las opciones DDL final
                foreach (ListItem item in DDLFinalProvincias.Items)
                {
                    item.Enabled = true;
                }

                // Deshabilitar la opción seleccionada
                foreach (ListItem item in DDLFinalProvincias.Items)
                {
                    if (item.Value == provinciaInicioId)
                    {
                        item.Enabled = false;
                        break;
                    }
                }
            }
            catch (Exception err)
            {
                lblError.Text = "Error al cargar Localidades: " + err.Message;
            }
        }

        protected void DDLFinalProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string provinciaId = DDLFinalProvincias.SelectedValue;
                CargarLocalidades(provinciaId, DDLFinalLocalidades);
            }
            catch (Exception err)
            {
                lblError.Text = "Error al cargar Localidades: " + err.Message;
            }
        }

        private void CargarLocalidades(string provinciaId, DropDownList ddlLocalidades)
        {
            try
            {
                string consultaLocalidades = "SELECT * FROM Localidades WHERE IdProvincia = " + provinciaId;

                //Conexión a la base de datos
                using (SqlConnection connection = new SqlConnection(stringConexion))
                {
                    connection.Open();

                    //Consulta SQL
                    using (SqlCommand sqlCommand = new SqlCommand(consultaLocalidades, connection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            //asignación de valores al DropDownList correspondiente
                            ddlLocalidades.DataSource = sqlDataReader;
                            ddlLocalidades.DataTextField = "NombreLocalidad";
                            ddlLocalidades.DataValueField = "IdLocalidad";
                            ddlLocalidades.DataBind();

                            //Asignación de valor inicial al DropDownList
                            ddlLocalidades.Items.Insert(0, new ListItem("-- Seleccionar --", ""));
                        }
                    }
                }
            }
            catch (Exception err)
            {
                lblError.Text = "Error al cargar Localidades: " + err.Message;
            }
        }

       
    }
}