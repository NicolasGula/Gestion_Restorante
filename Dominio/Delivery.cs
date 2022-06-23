using System;

namespace Dominio
{
    public class Delivery : Servicio, IValidable, IComparable<Delivery>
    {
        //ATRIBUTOS
        private string direccion;
        private Repartidor repartidor;
        private decimal distancia;

        //CONSTRUCTOR
        public Delivery(Cliente cliente, DateTime fecha, CantidadPlatos cantidadPlatos, bool estado, string direccion, Repartidor repartidor, decimal distancia) : base(cliente, fecha, cantidadPlatos, estado)
        {
            this.Direccion = direccion;
            this.Repartidor = repartidor;
            this.Distancia = distancia;
        }

        //PROPERTYS
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public Repartidor Repartidor
        {
            get { return repartidor; }
            set { repartidor = value; }
        }

        public decimal Distancia
        {
            get { return distancia; }
            set { distancia = value; }
        }

        //VALIDACIONES
        public bool Validar()
        {
            return ValidarDireccion() && ValidarDistancia();
        }

        private bool ValidarDireccion()
        {
            return Validaciones.ValidarTexto(this.direccion);
        }

        private bool ValidarDistancia()
        {
            return Validaciones.MayorACero((int)distancia);
        }

        //CALCULAR EL PRECIO DEL SERVICIO DELIVERY
        public override double CalcularPrecio()
        {
            double precio = 0;

            foreach (CantidadPlatos item in base.MostrarCantidad())
            {
                precio = (double)item.Cantidad * (double)item.Plato.Precio;
            }

            if(distancia < 6)
            {
                switch (distancia)
                {
                    case 1:
                        precio += 50;
                        break;
                    case 2:
                        precio += 60;
                        break;
                    case 3:
                        precio += 70;
                        break;
                    case 4:
                        precio += 80;
                        break;
                    default:
                        precio += 90;
                        break;
                }
            }
            else
            {
                precio += 100;
            }

            return precio;
        }

        //TOSTRING
        public override string ToString()
        {
            return $"FECHA: {base.Fecha.ToShortDateString()} NOMBRE REPARTIDOR: {repartidor.Nombre}";
        }


        public int CompareTo(Delivery unDelivery)
        {
            return Fecha.CompareTo(unDelivery.Fecha);
        }
    }
}
