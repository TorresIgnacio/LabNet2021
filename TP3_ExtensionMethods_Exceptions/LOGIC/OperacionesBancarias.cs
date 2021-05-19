using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class OperacionesBancarias
    {
        private BancoDatabase db;
        private double montoMaximo = 100000;

        public OperacionesBancarias()
        {
            db = new BancoDatabase();
        }

        public void Transferencia(uint usuarioOrigenID, uint usuarioDestinoID, double monto)
        {
            if (monto > montoMaximo)
                throw new ArgumentException($"No se puede transferir mas de {montoMaximo} por operacion");

            ModificarSaldoUsuario(usuarioOrigenID, -monto);
            ModificarSaldoUsuario(usuarioDestinoID, monto);
        }

        public void ModificarSaldoUsuario(uint usuarioID, double monto)
        {
            var usuario = db.usuarios.Find(u => u.id == usuarioID);
            if (usuario == null)
                throw new UsuarioIdException(usuarioID);
            if (monto < 0 && usuario.saldoBancario < monto.ValorAbsoluto() )
                throw new FondosInsuficientesException();
            usuario.saldoBancario += monto;
        }

        public List<Usuario> GetAll()
        {
            return db.usuarios;
        }

        public double Dividir(double divisor)
        {
            if (divisor == 0)
                throw new DivideByZeroException();
            double dividendo = 1000;
            return dividendo / divisor;
        }

        public double Dividir(double divisor, double dividendo)
        {
            if (divisor == 0)
                throw new DivideByZeroException();
            return dividendo / divisor;
        }
    }
}
