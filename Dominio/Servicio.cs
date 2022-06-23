using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Servicio : IEquatable<Servicio>
    {
        //ATRIBUTOS
        private int id;
        private Cliente cliente;
        private DateTime fecha;
        private bool estado;
        private List<CantidadPlatos> cantidadPlatos = new List<CantidadPlatos>();
        private static int primerId  = 0;

        //CONSTRUCTOR
        protected Servicio( Cliente cliente, DateTime fecha, CantidadPlatos cantPlatos, bool estado)
        {
            this.id = primerId++;
            this.cliente = cliente;
            this.fecha = fecha;
            this.estado = estado;
            AgregarPlato(cantPlatos);
        }

        //PROPERTYS
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

     

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }



        public CantidadPlatos ObtenerCantidad(CantidadPlatos cantidad)
        {
            foreach (CantidadPlatos item in cantidadPlatos)
            {
                if (item.Plato.Id == cantidad.Plato.Id)
                {
                    return item;
                }
            }
            return null;
        }

        //AGREGA EL PLATO A LA LISTA DE CANTIDAD DE PLATOS SI
        //NO ESTA. SI ESTA SE AGREGA LA CANTIDAD
        public bool AgregarPlato(CantidadPlatos cantPlato)
        {
            bool exito = true;
            CantidadPlatos aux = ObtenerCantidad(cantPlato);
            if (aux == null)
            {
                cantidadPlatos.Add(cantPlato);
            }
            else
            {
                aux.Cantidad += cantPlato.Cantidad;
            }

            return exito;
        }

        public List<Plato> ListarTodoslosPlatos()
        {
            List<Plato> aux = new List<Plato>();

            foreach (CantidadPlatos item in cantidadPlatos)
            {
                aux.Add(item.Plato);
            }
            return aux;
        }

        public List<CantidadPlatos> MostrarCantidad()
        {
            List<CantidadPlatos> aux = new List<CantidadPlatos>();
            foreach (CantidadPlatos item in cantidadPlatos)
            {
                aux.Add(item);
            }
            return aux;
        }

        public abstract double CalcularPrecio();
        

        //EQUALS
        public bool Equals(Servicio unServicio)
        {
            return unServicio != null && Id == unServicio.id;
        }

        //TOSTRING
        public override string ToString()
        {
            return $"nPLATO: {cantidadPlatos[0].Plato}\nCANTIDAD: {cantidadPlatos[0].Cantidad}\nTOTAL: {cantidadPlatos[0].Plato.Precio * cantidadPlatos[0].Cantidad}\nFECHA: {fecha}";
        }
    }
}
