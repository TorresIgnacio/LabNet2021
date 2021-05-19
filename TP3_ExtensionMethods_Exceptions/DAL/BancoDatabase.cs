using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BancoDatabase
    {
        public List<Usuario> usuarios = new List<Usuario>();
        public BancoDatabase()
        {
            usuarios.Add(new Usuario(1, "Juan", 250000));
            usuarios.Add(new Usuario(2, "Pedro", 120000));
            usuarios.Add(new Usuario(3, "Gonzalo", 20000));
            usuarios.Add(new Usuario(4, "Agustin", 150000));
            usuarios.Add(new Usuario(5, "Rodrigo", 300000));
            usuarios.Add(new Usuario(6, "Kevin", 4000000));
        }
    }
}
