using Entities;
using LOGIC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class DisplayMethods
    {
        OperacionesBancarias operacionesBancarias = new OperacionesBancarias();
        public void ConsignaUno()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Consigna 1: Permite dividir 1000 por un numero ingresado por el usuario.\n" +
                "Si el usuario ingresa 0 como divisor se lanza DivideByZeroException.\n" +
                "Siempre se avisa que la operacion termino, haya sido exitosa o no\n");
                double divisor;
                try
                {
                    Console.WriteLine("Ingrese divisor:");
                    divisor = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"Resultado: 1000/{divisor} = {operacionesBancarias.Dividir(divisor)}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Hubo un error\nTipo: {ex.GetType().Name}\nMensaje: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hubo un error desconocido\nTipo: {ex.GetType().Name}\nMensaje: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("La operacion termino");
                }

                if (Continuar())
                {
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                break;
            }
        }

        public void ConsignaDos()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Consigna 2: Permite ingresar dos numeros y dividirlos.\n" +
                "Si el usuario ingresa 0 como divisor se lanza DivideByZeroException y se muestra el mensaje pedido.\n" +
                "Si el usuario ingresa letra o no ingresa nada se captura FormatException.\n");

                double dividendo;
                double divisor;
                try
                {
                    Console.WriteLine("Ingrese dividendo:");
                    dividendo = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Ingrese divisor:");
                    divisor = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"Resultado: {dividendo}/{divisor} = {operacionesBancarias.Dividir(divisor, dividendo)}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Solo Chuck Norris divide por cero!\nTipo: {ex.GetType().Name}\n" +
                        $"Mensaje propio de la excepcion: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hubo un error desconocido");
                    Console.WriteLine(ex.GetType().Name);
                    Console.WriteLine(ex.Message);
                }
                if (Continuar())
                {
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                break;
            }
        }
        public void ConsignaTresYCuatro()
        {
            Console.Clear();
            uint idUsuarioOrigen, idUsuarioDestino;
            double monto;
            
            while (true)
            {
                Console.WriteLine("Este programa permite realizar una transferencia de un usuario a otro.\n" +
                "Consigna 3: Si el usuario ingresa un monto mayor a 100000 se dispara ArgumentException.\n" +
                "Consigna 4: Si el usuario ingresa una ID no existente o si se intenta hacer una transferencia con un " +
                "monto mayor que el saldo del usuario se disparan excepciones personalizadas.\n");

                PrintUsuarios(operacionesBancarias.GetAll());
                try
                {
                    Console.WriteLine("Elija ID de usuario origen: ");
                    idUsuarioOrigen = Convert.ToUInt32(Console.ReadLine());

                    Console.WriteLine("Elija ID de usuario destino:");
                    idUsuarioDestino = Convert.ToUInt32(Console.ReadLine());

                    Console.WriteLine("Ingrese monto a transferir:");
                    monto = Convert.ToDouble(Console.ReadLine());

                    operacionesBancarias.Transferencia(idUsuarioOrigen, idUsuarioDestino, monto);
                    Console.Clear();
                    Console.WriteLine("La transaccion fue un exito\nResultado:\n");
                    PrintUsuarios(operacionesBancarias.GetAll());


                }
                catch (FormatException)
                {
                    Console.WriteLine("La transaccion no pudo llevarse a cabo");
                    Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!\n");
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine("Excepcion capturada siguiendo directivas de la consigna 3:");
                    Console.WriteLine($"Tipo: {ex.GetType().Name}");
                    Console.WriteLine($"Mensaje {ex.Message}");
                    Console.WriteLine("La transaccion no pudo llevarse a cabo\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Excepcion capturada siguiendo directivas de la consigna 4 (Excepcion personalizada):");
                    Console.WriteLine(ex.GetType().Name);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("La transaccion no pudo llevarse a cabo\n");
                }
                if (Continuar())
                {
                    Console.Clear();
                    continue;
                }
                Console.Clear();
                break;
            }
        }
        private void PrintUsuarios(List<Usuario> usuarios)
        {
            Console.WriteLine("|{0,3}|{1,10}|{2,10}|", 
                "ID", 
                "Nombre", 
                "Saldo");

            foreach (var usuario in usuarios)
            {
                Console.WriteLine("|{0,3}|{1,10}|{2,10}|",
                    usuario.id,
                    usuario.nombre,
                    usuario.saldoBancario);
            }
        }

        private bool Continuar()
        {
            Console.WriteLine("Continuar? Presione C");
            if (Console.ReadKey().Key == ConsoleKey.C)
            {
                return true;
            }
            return false;
        }
    }
}
