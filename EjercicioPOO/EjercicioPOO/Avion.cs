using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    class Avion : Transporte, IVuelo, IManejo
    {
        private bool volando;
        public Avion()
        {
            capacidadMaxima = 100;
            SetCantidadPasajeros(RandomizarPasajeros(capacidadMaxima));                         //Genera numero aleatorio entre 0 y 100
            IncreaseTransportes();
            volando = false;
            VelocidadAerea = 0;
            VelocidadRuedas = 0;
        }

        public Avion(uint capacidadMaxima)
        {
            this.capacidadMaxima = capacidadMaxima;
            SetCantidadPasajeros(RandomizarPasajeros(capacidadMaxima));                         //Genera numero entre 0 y capacidad maxima
            IncreaseTransportes();
            volando = false;
            VelocidadAerea = 0;
            VelocidadRuedas = 0;
        }

        public Avion(uint capacidadMaxima, uint cantidadPasajeros)
        {
            this.capacidadMaxima = capacidadMaxima;
            if (cantidadPasajeros > capacidadMaxima)
                SetCantidadPasajeros(capacidadMaxima);
            else
                SetCantidadPasajeros(cantidadPasajeros);
            IncreaseTransportes();
            volando = false;
            VelocidadAerea = 0;
            VelocidadRuedas = 0;
        }

        private uint RandomizarPasajeros(uint capacidadMaxima)
        {
            return (Convert.ToUInt32(random.Next(2, Convert.ToInt32(capacidadMaxima))));   //Se considera a pilotos como pasajeros
        }

        //Metodos de Transporte
        public override string Avanzar()
        {
            if (volando)
                return $"Avion esta volando a {VelocidadAerea} Km/h";
            else
            {
                Acelerar();
                return $"Ruedas del avion aceleran a {VelocidadRuedas} km/h";
            }
        }

        public override string Detenerse()
        {
            if (volando)
                return Aterrizar();
            else
            {
                Frenar();
                return "Ruedas del avion se detienen";
            }
        }

        //Metodos y atributos de la interface IVuelo

        public int VelocidadAerea { get; set; }
        public string Despegar()
        {
            volando = true;
            VelocidadAerea = 333;
            Frenar();
            return "El avion despega";
        }

        public string Aterrizar() {
            volando = false;
            VelocidadAerea = 0;
            VelocidadRuedas = 50;
            /*No tiene sentido asignar valor a VelocidadRuedas si Frenar() lo llevara a 0 pero intente
             * realizar un modelo simple de aterrizaje del avion*/
            Frenar();
            return $"El avion aterriza y se detiene";
        }

        //Metodos y atributos de la interface IManejo
        public int VelocidadRuedas { get; set; }
        public void Acelerar()
        {
            VelocidadRuedas += 10;
            return;
        }
        public void Frenar()
        {
            VelocidadRuedas = 0;
            return;

        }

    }
}
