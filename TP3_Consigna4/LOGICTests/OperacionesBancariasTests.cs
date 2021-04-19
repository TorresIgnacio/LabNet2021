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
        
        [TestMethod()]
        public void TransferenciaTest()
        {
            double id1 = 0, id2 = 1, monto = 60000;

            Assert.IsTrue(OperacionesBancarias.Transferencia(id1, id2, monto));
        }

        [TestMethod()]
        [ExpectedException(typeof(UsuarioIdException))]
        public void Transferencia_IdDeUsuario1Incorrecta_ArrojaExcepcion()
        {
            double id1 = 3, id2 = 1, monto = 60000;
            OperacionesBancarias.Transferencia(id1, id2, monto);
        }

        [TestMethod()]
        [ExpectedException(typeof(UsuarioIdException))]
        public void Transferencia_IdDeUsuario2Incorrecta_ArrojaExcepcion()
        {
            double id1 = 1, id2 = 4, monto = 60000;
            OperacionesBancarias.Transferencia(id1, id2, monto);
        }


    }
}