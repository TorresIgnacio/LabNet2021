using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    class Automovil : Transporte, IManejo
    {
        
        public Automovil()
        {
            capacidadMaxima = 5;
            SetCantidadPasajeros(RandomizarPasajeros(capacidadMaxima));
            VelocidadRuedas = 0;
            IncreaseTransportes();

        }
        public Automovil(uint capacidadMaxima)
        {
            if (capacidadMaxima > 5)
                this.capacidadMaxima = 5;
            else
                this.capacidadMaxima = capacidadMaxima;

            SetCantidadPasajeros(RandomizarPasajeros(this.capacidadMaxima));
            VelocidadRuedas = 0;
            IncreaseTransportes();
        }

        public Automovil(uint capacidadMaxima, uint cantidadPasajeros)
        {
            if (capacidadMaxima > 5)
                this.capacidadMaxima = 5;
            else
                this.capacidadMaxima = capacidadMaxima;

            if (cantidadPasajeros > capacidadMaxima)
                SetCantidadPasajeros(this.capacidadMaxima);
            else
                SetCantidadPasajeros(cantidadPasajeros);
            VelocidadRuedas = 0;
            IncreaseTransportes();
        }

        private uint RandomizarPasajeros(uint capacidadMaxima)
        {
            return (Convert.ToUInt32(random.Next(1, Convert.ToInt32(capacidadMaxima))));        //Se considera a chofer como pasajero
        }

        //Metodos de Transporte
        public override string Avanzar()
        {
            Acelerar();
            return $"Auto avanza a {VelocidadRuedas} Km/h";
        }

        public override string Detenerse()
        {
            Frenar();
            return "Auto frena";
        }


        //Metodos y atributos de IManejo
        public int VelocidadRuedas { get; set; }

        public void Acelerar()
        {
            VelocidadRuedas += 5;
            return;
        }

        public void Frenar()
        {
            VelocidadRuedas = 0;
            return;
        }


    }
}
