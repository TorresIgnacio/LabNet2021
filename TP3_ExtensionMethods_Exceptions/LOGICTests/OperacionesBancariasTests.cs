using Microsoft.VisualStudio.TestTools.UnitTesting;
using LOGIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Tests
{
    [TestClass()]
    public class OperacionesBancariasTests
    {
        OperacionesBancarias operacionesBancarias = new OperacionesBancarias();

        [TestMethod()]
        [ExpectedException(typeof(UsuarioIdException))]
        public void Transferencia_IDOrigenIncorrecta_ArrojaExcepcion()
        {
            //Arrange
            uint idUsuarioOrigen = 12, idUsuarioDestino = 3;
            double monto = 2000;
            //Act
            operacionesBancarias.Transferencia(idUsuarioOrigen, idUsuarioDestino, monto);
        }

        [TestMethod()]
        [ExpectedException(typeof(UsuarioIdException))]
        public void Transferencia_IDDestinoIncorrecta_ArrojaExcepcion()
        {
            //Arrange
            uint idUsuarioOrigen = 1, idUsuarioDestino = 13;
            double monto = 2000;
            //Act
            operacionesBancarias.Transferencia(idUsuarioOrigen, idUsuarioDestino, monto);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Transferencia_MontoMayorAMontoMaximo_ArrojaExcepcion()
        {
            //Arrange
            uint idUsuarioOrigen = 1, idUsuarioDestino = 2;
            double monto = 120000;
            //Act
            operacionesBancarias.Transferencia(idUsuarioOrigen, idUsuarioDestino, monto);
        }

        [TestMethod()]
        [ExpectedException(typeof(FondosInsuficientesException))]
        public void Transferencia_MontoMayorASaldoOrigen_ArrojaExcepcion()
        {
            //Arrange
            uint idUsuarioOrigen = 3, idUsuarioDestino = 2;
            double monto = 30000;
            //Act
            operacionesBancarias.Transferencia(idUsuarioOrigen, idUsuarioDestino, monto);
        }

        [TestMethod()]
        public void DividirTest()
        {
            // Arrange
            
            double dividendo = 10, divisor = 2, resultadoEsperado = 5;

            //Act
            var resultado = operacionesBancarias.Dividir(divisor, dividendo);

            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Dividir_DivisionPorCero_ArrojaExcepcion()
        {
            // Arrange

            double dividendo = 10, divisor = 0;

            //Act
            var resultado = operacionesBancarias.Dividir(divisor, dividendo);

            // Assert manejado por excepciones
        }
    }
}