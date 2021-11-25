using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Generics;
using Excepciones;
using System.Threading;

namespace Entidades
{

    public delegate void Refrescador(DataTable tabla);
    public delegate void Notificador(string excepciones);


    public class GestorBaseDeDatos
    {

        private string sqlConexion;
        private string sqlComando;

        public GestorBaseDeDatos()
        {
            this.sqlConexion = @"Server=localhost\SQLEXPRESS;Database=TP3-CLUB;Trusted_Connection=True";
        }

        public GestorBaseDeDatos(string comando)
        : this()
        {
            this.sqlComando = comando;
        }

        public DataTable LeerDesdeBD()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(this.sqlConexion))
            {
                try
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(new SqlCommand(this.sqlComando, sqlConnection));
                    sqlDataAdapter.SelectCommand.CommandTimeout = 0;
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return dataTable;

        }

        public string SqlConexion
        {
            get
            {
                return this.SqlConexion;
            }
        }

        public string SqlComando
        {
            get
            {
                return this.sqlComando;
            }
            set
            {
                this.sqlComando = value;
            }
        }


        public void Guardar(Socix socio)
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.sqlConexion))
            {
                try
                {
                    string consulta = "INSERT INTO Socixs (dni,nombre,apellido,genero,edad,valorCuota,tipoSocix,medallas,categoria,posicion,partidosJugados,tipoPileta,estiloPreferido,categoriaPeso,cantidadPeleas,fechaAptaFisica,fechaDeAsociacion) VALUES (@dni,@nombre,@apellido,@genero,@edad,@valorCuota,@tipoSocix,@medallas,@categoria,@posicion,@partidosJugados,@tipoPileta,@estiloPreferido,@categoriaPeso,@cantidadPeleas,@fechaAptaFisica,@fechaDeAsociacion)";

                    SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

                    sqlCommand.Parameters.AddWithValue("dni", socio.DNI);
                    sqlCommand.Parameters.AddWithValue("nombre", socio.Nombre);
                    sqlCommand.Parameters.AddWithValue("apellido", socio.Apellido);
                    sqlCommand.Parameters.AddWithValue("genero", socio.Genero.ToString());
                    sqlCommand.Parameters.AddWithValue("edad", socio.Edad);
                    sqlCommand.Parameters.AddWithValue("valorCuota", socio.ValorCuota.ToString());
                    sqlCommand.Parameters.AddWithValue("tipoSocix", socio.TipoSocix.ToString());
                    sqlCommand.Parameters.AddWithValue("medallas", socio.CantidadMedallas);
                    sqlCommand.Parameters.AddWithValue("fechaAptaFisica", socio.FechaAptaFisica);
                    sqlCommand.Parameters.AddWithValue("fechaDeAsociacion", socio.FechaDeAsociacion);


                    if (socio is Futbolista)
                    {

                        sqlCommand.Parameters.AddWithValue("categoria", socio.Categoria.ToString());
                        sqlCommand.Parameters.AddWithValue("posicion", socio.Posicion);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", socio.PartidosJugados);
                        sqlCommand.Parameters.AddWithValue("tipoPileta", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("categoriaPeso", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("cantidadPeleas", 0);


                    }
                    else if (socio is Pugilista)
                    {
                        sqlCommand.Parameters.AddWithValue("categoria", 0);
                        sqlCommand.Parameters.AddWithValue("posicion", 0);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", 0);
                        sqlCommand.Parameters.AddWithValue("tipoPileta", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("categoriaPeso", socio.CategoriaPeso.ToString());
                        sqlCommand.Parameters.AddWithValue("cantidadPeleas", socio.CantidadPeleas);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("categoria", 0);
                        sqlCommand.Parameters.AddWithValue("posicion", 0);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", 0);
                        sqlCommand.Parameters.AddWithValue("tipoPileta", socio.TipoPileta.ToString());
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", socio.EstiloPreferido.ToString());
                        sqlCommand.Parameters.AddWithValue("categoriaPeso", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("cantidadPeleas", 0);
                    }



                    if (sqlConnection.State != System.Data.ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }

                    sqlCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new Exception("Excepcion Capturada en GuardarSocix",ex);
                }

            }

        }

        public bool DniExistente(int dni)
        {

            bool respuesta = false;

            using (SqlConnection sqlConnection = new SqlConnection(this.sqlConexion))
            {
                try
                {

                    string consulta = "SELECT dni FROM TP3-CLUB WHERE dni = @dni";
                    SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("dni", dni);

                    if (sqlConnection.State != System.Data.ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }


                    if (sqlCommand.ExecuteScalar() != null)
                    {
                        respuesta = true;
                    }


                }
                catch (Exception)
                {
                    throw;
                }
            }

            return respuesta;
        }

        public void EjecutarScalar()
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.sqlConexion))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(this.sqlComando, sqlConnection);
                    if (sqlConnection.State != System.Data.ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }


                    sqlCommand.ExecuteScalar();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void EjecutarReader()
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.sqlConexion))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(this.sqlComando, sqlConnection);
                    if (sqlConnection.State != System.Data.ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }


                    sqlCommand.ExecuteReader();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void EjecutarNonQuery()
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.sqlConexion))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(this.sqlComando, sqlConnection);
                    if (sqlConnection.State != System.Data.ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }


                    sqlCommand.ExecuteNonQuery();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
