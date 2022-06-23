using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public static class Validaciones
    {
        public static bool ValidarTexto(string texto)
        {
            return !string.IsNullOrEmpty(texto);
        }

        public static bool MayorACero(int numero)
        {
            return numero > 0;
        }

    }
}
