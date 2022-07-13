using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Entidades;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;
using Generics;
using System.Threading;
using System.Text;

namespace TestUnitarios
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ErrorArchivosException))]
        public void TestFormatoArchivoLeer()
        {
            // Act
            GestorDeArchivos gbd = new GestorDeArchivos();
            List<Socix> list = new List<Socix>();
            // Arrange
            gbd.Leer(gbd.GenerarRutaCompleta, out list);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]

        public void TestAsignarDNIExistente()
        {
            // Act
            Socix socix = new Nadador();
            Socix otroSocix = new Futbolista();

            // Arrange
            socix.DNI = 37865167;
            socix.Nombre = "Elpe";
            socix.Apellido = "Poso";
            socix.Genero = EGenero.NoBinario;
            socix.Edad = 55;
            socix.TipoSocix = ETipoSocix.Recreativo;
            socix.CantidadMedallas = 0;
            ((Futbolista)socix).Posicion = 5;
            socix.FechaAptaFisica = DateTime.Today.ToString("dd/MM/yyyy");
            socix.FechaDeAsociacion = socix.FechaAptaFisica;
            ((Futbolista)socix).PartidosJugados = 0;
            socix.ValorCuota = ECuota.AdultxsFutbol;
            GestorBaseDeDatos gdb = new GestorBaseDeDatos();
            ((Futbolista)socix).Categoria = ECategoria.Amateur;
            gdb.Guardar(socix);
            otroSocix.DNI = 37865167;



        }
    }
}
