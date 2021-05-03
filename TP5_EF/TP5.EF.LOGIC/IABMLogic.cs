﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP5.EF.LOGIC
{
    interface IABMLogic<T,K>
    {
        void Add(T newRow);

        void Delete(K id);

        //UpdateLazy updatea todos los campos especificados pero no puede nullear
        void UpdateLazy(T row);

        //UpdateAndBlank blanquea todos los campos no llenados en el objeto parametro a excepcion de los campos requeridos
        void UpdateAndBlank(T row);

        List<T> GetAll();

    }
}
