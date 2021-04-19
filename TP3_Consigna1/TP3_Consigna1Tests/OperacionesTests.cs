using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP3_Consigna1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP3_Consigna1.Tests
{
    [TestClass()]
    public class OperacionesTests
    {
        [TestMethod()]
        public void DividirTest()
        {
            // Arrange
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

        [TestMethod()]
        public void Dividir_UsuarioIngresa0EnDividendo_ResultadoCero()
        {
            // Arrange
            var stringWrite = new StringReader("0\n2");
            decimal resultadoEsperado = 0M;
            Console.SetIn(stringWrite);

            //Act
            var resultado = Operaciones.Dividir();

            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }
    }
}