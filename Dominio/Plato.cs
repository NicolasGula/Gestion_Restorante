using System;

namespace Dominio
{
    public class Plato : IEquatable<Plato>, IValidable, IComparable<Plato>
    {
        //ATRIBUTOS
        private static decimal precioMinimo = 200;
        private int id;
        private string nombre;
        private decimal precio;
        private int meGustas = 0;

        //PROPIEDADES
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public decimal PrecioMinimo
        {
            get { return precioMinimo; }
            set { precioMinimo = value; }
        }

        public int MeGustas
        {
            get { return meGustas; }
            set { meGustas = value; }
        }

        //CONSTRUCTOR
        public Plato(int id, string nombre, decimal precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
        }

        //VALIDACIONES
        public bool Validar()
        {
            return ValidarNombrePlato() && ValidarPrecio();
        }

        private bool ValidarNombrePlato()
        {
            return Validaciones.ValidarTexto(nombre);
        }

        private bool ValidarPrecio()
        {
            return this.precio >= precioMinimo;
        }

        //EQUALS implementado con IEquatable
        public bool Equals(Plato unPlato)
        { 
            return unPlato != null && id == unPlato.Id;
        }

        //TOSTRING
        public override string ToString()
        {
            return $"NOMBRE: {nombre} PRECIO: {precio}";
        }

        //CAMBIA EL PRECIO MINIMO DEL PLATO
        public static bool ModificarPrecioMinimo(decimal nuevoPrecio)
        {
            bool exito = false;
            if(nuevoPrecio > 100)
            {
                precioMinimo = nuevoPrecio;
                exito =  true;
            }
            return exito;
        }

        public void AgregarLike()
        {
            this.MeGustas++;
        }

        //COMPARA LOS LPATOS POR NOMBRE Y LOS DEVUELVE ORDENADOS ALFABETICAMENTE.
        public int CompareTo(Plato unPlato)
        {
            return Nombre.CompareTo(unPlato.Nombre);
        }
    }
}
