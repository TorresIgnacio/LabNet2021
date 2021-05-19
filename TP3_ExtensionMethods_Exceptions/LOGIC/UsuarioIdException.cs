using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class UsuarioIdException : Exception
    {
        public UsuarioIdException(uint id) : base("La id ("+id+") provista no corresponde con ningun usuario existente")
        {

        }

    }
}
