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
            decimal valor = 2;

            //Act
            var resultado = Operaciones.Dividir(valor);

            // Assert
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void Dividir_DivisionPorCero_RetornaFalso()
        {
            // Arrange
            decimal valor = 0;
            //Act
            var resultado = Operaciones.Dividir(valor);

            // Assert
            Assert.IsFalse(resultado);
        }


    }
}