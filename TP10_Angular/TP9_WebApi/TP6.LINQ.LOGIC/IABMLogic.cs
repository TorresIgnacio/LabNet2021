using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP6.LINQ.LOGIC
{
    interface IABMLogic<T,K>
    {
        bool Add(T newRow);

        void Delete(K id);

        //UpdateLazy updatea todos los campos especificados pero no puede nullear
        bool UpdateLazy(T row);

        //UpdateAndBlank blanquea todos los campos no llenados en el objeto parametro a excepcion de los campos requeridos
        bool UpdateAndBlank(T row);

        List<T> GetAll();

    }
}
