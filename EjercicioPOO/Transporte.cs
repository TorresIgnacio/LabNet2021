using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    abstract class Transporte
    {
        public static readonly Random random = new Random();
        private uint cantidadPasajeros;  
        protected uint capacidadMaxima;
        private static uint cantidadTransportes = 0;

        public abstract string Avanzar();
        public abstract string Detenerse();

        public uint GetCapacidadMaxima() { return capacidadMaxima; }

        public uint GetCantidadPasajeros() { return cantidadPasajeros; }
        public void SetCantidadPasajeros(uint cantidadPasajeros) { this.cantidadPasajeros = cantidadPasajeros; }
        public static uint GetCantidadTransportes() { return cantidadTransportes; }
        protected static void IncreaseTransportes() { cantidadTransportes++; }


    }
}
