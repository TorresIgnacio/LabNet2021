using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP3_Consigna2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP3_Consigna2.Tests
{
    [TestClass()]
    public class OperacionesTests
    {
        [TestMethod()]
        public void DividirTest()
        {
            // Arrange
            //Se simula input del usuario utilizando Console.SetIn
            var stringWrite = new StringReader("10\n2");
            decimal resultadoEsperado = 5.0M;
            Console.SetIn(stringWrite);

            //Act
            var resultado = Operaciones.Dividir();

            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Dividir_DivisionPorCero_ArrojaExcepcion()
        {
            // Arrange
            var stringWrite = new StringReader("10\n0");
            Console.SetIn(stringWrite);

            //Act
            var resultado = Operaciones.Dividir();

            // Assert manejado por excepciones
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Dividir_UserIngresaLetra_ArrojaExcepcion()
        {
            // Arrange
            var stringWrite = new StringReader("10\na");
            Console.SetIn(stringWrite);

            //Act
            var resultado = Operaciones.Dividir();

            // Assert manejado por excepciones
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Dividir_UserNoIngresaNada_ArrojaExcepcion()
        {
            // Arrange
            var stringWrite = new StringReader(" ");
            Console.SetIn(stringWrite);

            //Act
            var resultado = Operaciones.Dividir();

            // Assert manejado por excepciones
        }
    }
}