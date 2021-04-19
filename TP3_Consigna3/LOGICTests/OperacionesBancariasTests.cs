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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Transferencia_MontoMayorAlPermitido_ArrojaExcepcion()
        {
            double id1 = 0, id2 = 1, monto = 133000;
            OperacionesBancarias.Transferencia(id1, id2, monto);
        }
    }
}