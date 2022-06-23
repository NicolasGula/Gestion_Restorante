using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Local : Servicio, IValidable
    {
        //ATRIBUTOS
        private int numeroMesa;
        private Mozo mozo;
        private int cantidadComensales;
        private decimal precioCubierto;

        //CONSTRUCTOR
        public Local(Cliente cliente, DateTime fecha, CantidadPlatos cantidadPlatos, bool estado, int numeroMesa, Mozo mozo, int cantidadComensales, decimal precioCubierto) : base( cliente, fecha, cantidadPlatos, estado)
        {
            this.NumeroMesa = numeroMesa;
            this.Mozo = mozo;
            this.CantidadComensales = cantidadComensales;
            this.PrecioCubierto = precioCubierto;
        }

        //PROPERTYS
        public int NumeroMesa
        {
            get { return numeroMesa; }
            set { numeroMesa = value; }
        }

        public Mozo Mozo
        {
            get { return mozo; }
            set { mozo = value; }
        }

        public int CantidadComensales
        {
            get { return cantidadComensales; }
            set { cantidadComensales = value; }
        }

        public decimal PrecioCubierto
        {
            get { return precioCubierto; }
            set { precioCubierto = value; }
        }

        public override double CalcularPrecio()
        {
            double recargoPropina = 1.10;
            double precio = 0;

            foreach (CantidadPlatos item in base.MostrarCantidad())
            {
                precio = (double)item.Cantidad * (double)item.Plato.Precio;
            }

            //Calcula el 10% de propina
            precio *= recargoPropina;

            //Agrega el precio del cubierto por comensal
            precio += (double)cantidadComensales * (double)precioCubierto;

            return precio;
        }

        //VALIDACIONES
        public bool Validar()
        {
            return ValidarCantidadComensales() && ValidarNumeroDeMesa();
        }

        private bool ValidarCantidadComensales()
        {
            return Validaciones.MayorACero(cantidadComensales);
        }

        private bool ValidarNumeroDeMesa()
        {
            return Validaciones.MayorACero(numeroMesa);
        }

        
    }
}
