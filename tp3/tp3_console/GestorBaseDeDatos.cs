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

    public class GestorBaseDeDatos
    {

        private string sqlConexion;
        private string sqlComando;

        public GestorBaseDeDatos()
        {
            this.sqlConexion = @"Server=localhost\SQLEXPRESS;Database=TP3CLUB;Trusted_Connection=True";
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
                    string consulta = "INSERT INTO Socixs (dni,nombre,apellido,genero,edad,valorCuota,tipoSocix,medallas,categoria,posicion,partidosJugados,pileta,estiloPreferido,peso,cantidadPeleas,aptaFisica,asociacion) VALUES (@dni,@nombre,@apellido,@genero,@edad,@valorCuota,@tipoSocix,@medallas,@categoria,@posicion,@partidosJugados,@pileta,@estiloPreferido,@peso,@cantidadPeleas,@aptaFisica,@asociacion)";

                    SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

                    sqlCommand.Parameters.AddWithValue("dni", socio.DNI);
                    sqlCommand.Parameters.AddWithValue("nombre", socio.Nombre);
                    sqlCommand.Parameters.AddWithValue("apellido", socio.Apellido);
                    sqlCommand.Parameters.AddWithValue("genero", socio.Genero.ToString());
                    sqlCommand.Parameters.AddWithValue("edad", socio.Edad);
                    sqlCommand.Parameters.AddWithValue("valorCuota", socio.ValorCuota.ToString());
                    sqlCommand.Parameters.AddWithValue("tipoSocix", socio.TipoSocix.ToString());
                    sqlCommand.Parameters.AddWithValue("medallas", socio.CantidadMedallas);
                    sqlCommand.Parameters.AddWithValue("aptaFisica", socio.FechaAptaFisica);
                    sqlCommand.Parameters.AddWithValue("asociacion", socio.FechaDeAsociacion);


                    if (socio is Futbolista)
                    {

                        sqlCommand.Parameters.AddWithValue("categoria", ((Futbolista)socio).Categoria.ToString());
                        sqlCommand.Parameters.AddWithValue("posicion", ((Futbolista)socio).Posicion);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", ((Futbolista)socio).PartidosJugados);
                        sqlCommand.Parameters.AddWithValue("pileta", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("peso", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("cantidadPeleas", 0);


                    }
                    else if (socio is Pugilista)
                    {
                        sqlCommand.Parameters.AddWithValue("categoria", 0);
                        sqlCommand.Parameters.AddWithValue("posicion", 0);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", 0);
                        sqlCommand.Parameters.AddWithValue("pileta", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("peso", ((Pugilista)socio).CategoriaPeso.ToString());
                        sqlCommand.Parameters.AddWithValue("cantidadPeleas", ((Pugilista)socio).CantidadPeleas);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("categoria", 0);
                        sqlCommand.Parameters.AddWithValue("posicion", 0);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", 0);
                        sqlCommand.Parameters.AddWithValue("pileta", ((Nadador)socio).TipoPileta.ToString());
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", ((Nadador)socio).EstiloPreferido.ToString());
                        sqlCommand.Parameters.AddWithValue("peso", "No corresponde");
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
                    throw new Exception("Excepcion Capturada en GuardarSocix", ex);
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

                    string consulta = "SELECT dni FROM Socixs WHERE dni = @dni";
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Socix ObtenerSocix(int dni)
        {
            Socix socix = null;

            using (SqlConnection sqlConnection = new SqlConnection(this.sqlConexion))
            {
                try
                {
                    string consulta = "SELECT * FROM Socixs WHERE dni = @dni";

                    SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

                    sqlCommand.Parameters.AddWithValue("dni", dni);


                    if (sqlConnection.State != System.Data.ConnectionState.Open)
                    {
                        sqlConnection.Open();
                    }

                    SqlDataReader data = sqlCommand.ExecuteReader();

                    while (data.Read())
                    {
                        if (data.GetString(6).IndexOf("Natacion", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            socix = new Nadador();
                            ((Nadador)socix).TipoPileta = Enum.Parse<EPileta>(data.GetString(12));
                            ((Nadador)socix).EstiloPreferido = Enum.Parse<EEstilos>(data.GetString(13));
                        }
                        else if (data.GetString(6).IndexOf("Futbol", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            socix = new Futbolista();
                            ((Futbolista)socix).Categoria = Enum.Parse<ECategoria>(data.GetString(9));
                            ((Futbolista)socix).Posicion = data.GetInt32(10);
                            ((Futbolista)socix).PartidosJugados = data.GetInt32(11);
                        }
                        else
                        {
                            socix = new Pugilista();
                            ((Pugilista)socix).CategoriaPeso = Enum.Parse<EPeso>(data.GetString(14));
                            ((Pugilista)socix).CantidadPeleas = data.GetInt32(15);
                        }

                        socix.Nombre = data.GetString(2);
                        socix.Apellido = data.GetString(3);
                        socix.Genero = Enum.Parse<EGenero>(data.GetString(4));
                        socix.Edad = data.GetInt32(5);
                        socix.ValorCuota = Enum.Parse<ECuota>(data.GetString(6));
                        socix.TipoSocix = Enum.Parse<ETipoSocix>(data.GetString(7));
                        socix.CantidadMedallas = data.GetInt32(8);
                        socix.FechaAptaFisica = data.GetString(16);
                        socix.FechaDeAsociacion = data.GetString(17);


                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Excepcion Capturada en ObtenerSocix", ex);
                }

            }

            return socix;

        }

        public void ActualizarSocix(Socix socio, int dni)
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.sqlConexion))
            {
                try
                {
                    string consulta = "UPDATE Socixs SET nombre = @nombre, apellido = @apellido, genero = @genero, edad = @edad, valorCuota = @valorCuota, tipoSocix = @tipoSocix, medallas = @medallas, categoria = @categoria, posicion = @posicion, partidosJugados = @partidosJugados, pileta = @pileta , estiloPreferido = @estiloPreferido, peso = @peso, cantidadPeleas = @cantidadPeleas, aptaFisica = @aptaFisica, asociacion = @asociacion WHERE dni = @dni";

                    SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("dni", dni);
                    sqlCommand.Parameters.AddWithValue("nombre", socio.Nombre);
                    sqlCommand.Parameters.AddWithValue("apellido", socio.Apellido);
                    sqlCommand.Parameters.AddWithValue("genero", socio.Genero.ToString());
                    sqlCommand.Parameters.AddWithValue("edad", socio.Edad);
                    sqlCommand.Parameters.AddWithValue("valorCuota", socio.ValorCuota.ToString());
                    sqlCommand.Parameters.AddWithValue("tipoSocix", socio.TipoSocix.ToString());
                    sqlCommand.Parameters.AddWithValue("medallas", socio.CantidadMedallas);
                    sqlCommand.Parameters.AddWithValue("aptaFisica", socio.FechaAptaFisica);
                    sqlCommand.Parameters.AddWithValue("asociacion", socio.FechaDeAsociacion);


                    if (socio is Futbolista)
                    {

                        sqlCommand.Parameters.AddWithValue("categoria", ((Futbolista)socio).Categoria.ToString());
                        sqlCommand.Parameters.AddWithValue("posicion", ((Futbolista)socio).Posicion);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", ((Futbolista)socio).PartidosJugados);
                        sqlCommand.Parameters.AddWithValue("tipoPileta", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("peso", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("cantidadPeleas", 0);


                    }
                    else if (socio is Pugilista)
                    {
                        sqlCommand.Parameters.AddWithValue("categoria", 0);
                        sqlCommand.Parameters.AddWithValue("posicion", 0);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", 0);
                        sqlCommand.Parameters.AddWithValue("pileta", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", "No corresponde");
                        sqlCommand.Parameters.AddWithValue("peso", ((Pugilista)socio).CategoriaPeso.ToString());
                        sqlCommand.Parameters.AddWithValue("cantidadPeleas", ((Pugilista)socio).CantidadPeleas);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("categoria", 0);
                        sqlCommand.Parameters.AddWithValue("posicion", 0);
                        sqlCommand.Parameters.AddWithValue("partidosJugados", 0);
                        sqlCommand.Parameters.AddWithValue("pileta", ((Nadador)socio).TipoPileta.ToString());
                        sqlCommand.Parameters.AddWithValue("estiloPreferido", ((Nadador)socio).EstiloPreferido.ToString());
                        sqlCommand.Parameters.AddWithValue("peso", "No corresponde");
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
                    throw new Exception($"Excepcion Capturada en ActualizarSocix: {ex.Message}", ex);
                }

            }
        }

        public void BorrarDNI(int dni)
        {

            using (SqlConnection sqlConnectionDel = new SqlConnection(this.sqlConexion))
            {
                this.sqlComando = "Delete dni FROM Socixs WHERE dni = @dni";

                SqlCommand sqlCommandDelete = new SqlCommand(sqlComando, sqlConnectionDel);
                sqlCommandDelete.Parameters.AddWithValue("dni", dni);


                if (sqlConnectionDel.State != System.Data.ConnectionState.Open)
                {
                    sqlConnectionDel.Open();
                }

                sqlCommandDelete.ExecuteNonQuery();
            }
        }
    }
}
