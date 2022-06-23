using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class CantidadPlatos : IEquatable<CantidadPlatos>, IValidable
    {
        //ATRIBUTOS
        private int cantidad;
        private Plato plato;

        //CONSTRUCTOR
        public CantidadPlatos(int cantidad, Plato plato)
        {
            this.cantidad = cantidad;
            this.plato = plato;
        }

        //PROPERTYS
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public Plato Plato
        {
            get { return plato; }
            set { plato = value; }
        }

        //VALIDACIONES
        public bool Validar()
        {
            return ValidarCantidadDeComensales();
        }

        private bool ValidarCantidadDeComensales()
        {
            return Validaciones.MayorACero(this.cantidad);
        }

        //TOSTRING
        public override string ToString()
        {
            return $"{cantidad} de {plato.Nombre}";
        }

       //EQUALS
        public bool Equals(CantidadPlatos unaCantidad)
        {
            return unaCantidad != null && Plato == unaCantidad.Plato;
        }
    }
}
