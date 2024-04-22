﻿using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TP4_GRUPO_3
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
        private const string stringConexion = @"Data Source=DESKTOP-2MB1JSO\SQLEXPRESS;Initial Catalog=Viajes;Integrated Security=True";
        private string consultaProvincias = "SELECT * FROM Provincas";
        private string consultaLocalidades = "SELECT * FROM Localidades";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                cargarProvincias();
                cargarLocalidades();
            }
        }

        private void cargarProvincias()
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

        private void cargarLocalidades()
        {
            try
            {

                //Conexión a la base de datos
                SqlConnection connection = new SqlConnection(stringConexion);
                connection.Open();

                //Consulta SQL
                SqlCommand sqlCommand = new SqlCommand(consultaLocalidades, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                //asignación de valores a DDLInicio
                DDLInicioLocalidades.DataSource = sqlDataReader;
                DDLInicioLocalidades.DataTextField = "NombreLocalidad";
                DDLInicioLocalidades.DataValueField = "IdLocalidad";
                DDLInicioLocalidades.DataBind();

                //liberación de recursos para nueva consulta
                sqlDataReader.Close();

                //Consulta SQL
                sqlCommand = new SqlCommand(consultaLocalidades, connection);
                SqlDataReader sqlDataReader2 = sqlCommand.ExecuteReader();

                //asignación de valores a DDLFinal
                DDLFinalLocalidades.DataSource = sqlDataReader2;
                DDLFinalLocalidades.DataTextField = "NombreLocalidad";
                DDLFinalLocalidades.DataValueField = "IdLocalidad";
                DDLFinalLocalidades.DataBind();

                //Asignación de valor inicial a los DDL
                DDLInicioLocalidades.Items.Insert(0, new ListItem("-- Seleccionar --", ""));
                DDLFinalLocalidades.Items.Insert(0, new ListItem("-- Seleccionar --", ""));

                connection.Close();
            }
            catch (Exception err)
            {
                lblError.Text = "Error al cargar Localidades: " + err.Message;
            }
        }


        protected void DDLInicioLocalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}