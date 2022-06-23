using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Administrativa
    {
        private static Administrativa instancia;
        //===================================LISTAS CON TODA LA INFORMACION===============================
        private List<Plato> platos = new List<Plato>();

      

        private List<Cliente> clientes = new List<Cliente>();
        private List<Mozo> mozos = new List<Mozo>();
        private List<Repartidor> repartidores = new List<Repartidor>();
        private List<Local> locales = new List<Local>();
        private List<Delivery> deliverys = new List<Delivery>();
        private List<CantidadPlatos> cantidadPlatos = new List<CantidadPlatos>();
        private List<Servicio> servicios = new List<Servicio>();
        

        private List<Persona> personas = new List<Persona>();


        public static Administrativa Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Administrativa();
                }
                return instancia;
            }
        }

        public Administrativa()
        {
            PreCargaPlatos();
            PreCargaClientes();
            PreCargaMozos();
            PreCargaRepartidores();
            PreCargaServicios();
        }

        //===================================PRECARGA DE LOS DATOS===============================

        private void PreCargaPlatos()
        {
            //CASOS POSITIVOS
            CargarPlato(1, "Milanesa", 500);
            CargarPlato(2, "Hamburguesa", 250);
            CargarPlato(3, "Fideos con pesto", 200);
            CargarPlato(4, "Pollo al spiedo", 500);
            CargarPlato(5, "Lasagna", 400);
            CargarPlato(6, "Papas al horno", 600);
            CargarPlato(7, "Gramajo", 200);
            CargarPlato(8, "Nuggets", 200);
            CargarPlato(9, "Pizza con Muzzarella", 430);
            CargarPlato(10, "Chop Suey", 230);
            //CASOS CON ERROR
            CargarPlato(10, "Gramajo", 700); // ID IGUAL AL PLATO ANTERIOR
            CargarPlato(8, "Nuggets", 90); // PRECIO MENOR AL PRECIO MINIMO ESTABLECIDO (PRECMIN:$200)
            CargarPlato(9, "", 430); // PLATO SIN NOMBRE
        }

        private void PreCargaClientes()
        {

            //CASOS POSITIVOS
            CargarCliente("Alfredo", "Gomez", "Ab.12345", "cliente1", "cliente", "cliente1@gmail.com");
            CargarCliente("Lorenzo", "Ansuate", "Ab.12345", "cliente2", "cliente", "cliente2@gmail.com");
            CargarCliente("Beatriz", "Pereyra", "Ab.12345", "cliente3", "cliente", "cliente3@gmail.com");
            CargarCliente("Fiorella", "Rodriguez", "Ab.12345", "cliente4", "cliente", "cliente4@gmail.com");
            CargarCliente("Pepe", "Argento", "Ab.12345", "cliente5", "cliente", "cliente5@gmail.com");
            //CASOS CON ERROR
            //CargarCliente("cliente1gmail.com", "Ab.12345", "Alfredo", "Gomez", "cliente6");// MAIL SIN @
            //CargarCliente("cliente2@gmail.com", "Ab.14", "Lorenzo", "Ansuate", "cliente7");// PASSWORD CON LONGITUD MENOR A 6
            //CargarCliente("cliente3@gmail.com", "Ab.12345", "", "Pereyra", "cliente8");// CLIENTE SIN NOMBRE
        }

        private void PreCargaMozos()
        {
            //CASOS POSITIVOS
            CargarMozo("Abc123", "Raquel", "Suarez", "mozo1", "mozo");
            CargarMozo("Abc123", "Ramon", "Fagundez", "mozo2", "mozo");
            CargarMozo("Abc123", "Rosario", "Figueroa", "mozo3", "mozo");
            CargarMozo("Abc123", "Raul", "Mauro", "mozo4", "mozo");
            CargarMozo("Abc123", "Roman", "Couste", "mozo5", "mozo");
            //CASOS NEGATIVOS
            //CargarMozo("", "Mauro"); // SIN NOMBRE
            //CargarMozo("Roman", "");// SIN APELLIDO
        }

        private void PreCargaRepartidores()
        {

            //CASOS POSITIVOS
            CargarRepartidor("Abc123", "Federico", "Baston", "repartidor1", "repartidor", "Bicicleta");
            CargarRepartidor("Abc123", "Nahuel", "Larrosa", "repartidor2", "repartidor", "Bicicleta");
            CargarRepartidor("Abc123", "Paola", "De los santos", "repartidor3", "repartidor", "Pie");
            CargarRepartidor("Abc123", "Penelope", "Cruz", "repartidor4", "repartidor", "Bicicleta");
            CargarRepartidor("Abc123", "Federico", "Baston", "repartidor5", "repartidor", "Moto");
            //CASOS NEGATIVOS
            //CargarRepartidor("", "Federico", "Baston"); // SIN TIPO DE VEHICULO
            //CargarRepartidor("Bicicleta", "", "Larrosa");// SIN NOMBRE
            //CargarRepartidor("Pie", "Paola", "");// SIN APELLIDO
        }

        private void PreCargaServicios()
        {
            //Locales
            CantidadPlatos unaCantidad;

            Plato unPlato = BuscarPlato(2);
            Cliente unCliente = BuscarCliente(2);
            Mozo unMozo = BuscarMozo(6);
            unaCantidad = CargarCantidadPlatos(unPlato, 4);
            CargarLocal(unCliente, new DateTime(2022, 07, 15), unaCantidad, 4, unMozo, 2, 70, false);

            unPlato = BuscarPlato(1);
            unCliente = BuscarCliente(1);
            unMozo = BuscarMozo(6);
            unaCantidad = CargarCantidadPlatos(unPlato, 2);
            CargarLocal(unCliente, new DateTime(2022, 08, 12), unaCantidad, 2, unMozo, 1, 70, false);

            unPlato = BuscarPlato(3);
            unCliente = BuscarCliente(3);
            unMozo = BuscarMozo(6);
            unaCantidad = CargarCantidadPlatos(unPlato, 1);
            CargarLocal( unCliente, new DateTime(2022, 02, 12), unaCantidad, 3, unMozo, 3, 70, false);

            unPlato = BuscarPlato(8);
            unCliente = BuscarCliente(2);
            unMozo = BuscarMozo(7);
            unaCantidad = CargarCantidadPlatos(unPlato, 4);
            CargarLocal(unCliente, new DateTime(2022, 02, 12), unaCantidad, 4, unMozo, 4, 70, false);

            unPlato = BuscarPlato(9);
            unCliente = BuscarCliente(1);
            unMozo = BuscarMozo(7);
            unaCantidad = CargarCantidadPlatos(unPlato, 1);
            CargarLocal(unCliente, new DateTime(2022, 08, 24), unaCantidad, 4, unMozo, 1, 70, false);

            unPlato = BuscarPlato(5);
            unCliente = BuscarCliente(5);
            unMozo = BuscarMozo(7);
            unaCantidad = CargarCantidadPlatos(unPlato, 2);
            CargarLocal( unCliente, new DateTime(2022, 02, 12), unaCantidad, 4, unMozo, 2, 70, false);

            unPlato = BuscarPlato(7);
            unCliente = BuscarCliente(1);
            unMozo = BuscarMozo(8);
            unaCantidad = CargarCantidadPlatos(unPlato, 1);
            CargarLocal(unCliente, new DateTime(2022, 04, 19), unaCantidad, 4, unMozo, 2, 70, false);

            unPlato = BuscarPlato(7);
            unCliente = BuscarCliente(2);
            unMozo = BuscarMozo(8);
            unaCantidad = CargarCantidadPlatos(unPlato, 1);
            CargarLocal(unCliente, new DateTime(2022, 04, 19), unaCantidad, 4, unMozo, 1, 70, false);

            unPlato = BuscarPlato(7);
            unCliente = BuscarCliente(4);
            unMozo = BuscarMozo(8);
            unaCantidad = CargarCantidadPlatos(unPlato, 4);
            CargarLocal(unCliente, new DateTime(2022, 04, 19), unaCantidad, 4, unMozo, 2, 70, false);

            unPlato = BuscarPlato(1);
            unCliente = BuscarCliente(1);
            unMozo = BuscarMozo(9);
            unaCantidad = CargarCantidadPlatos(unPlato, 1);
            CargarLocal(unCliente, new DateTime(2022, 07, 29), unaCantidad, 4, unMozo, 2, 70, false);

            unPlato = BuscarPlato(7);
            unCliente = BuscarCliente(2);
            unMozo = BuscarMozo(9);
            unaCantidad = CargarCantidadPlatos(unPlato, 2);
            CargarLocal(unCliente, new DateTime(2012, 05, 30), unaCantidad, 4, unMozo, 3, 70, false);

            unPlato = BuscarPlato(1);
            unCliente = BuscarCliente(3);
            unMozo = BuscarMozo(9);
            unaCantidad = CargarCantidadPlatos(unPlato, 3);
            CargarLocal( unCliente, new DateTime(2022, 12, 21), unaCantidad, 4, unMozo, 4, 70, false);

            unPlato = BuscarPlato(1);
            unCliente = BuscarCliente(1);
            unMozo = BuscarMozo(10);
            unaCantidad = CargarCantidadPlatos(unPlato, 4);
            CargarLocal(unCliente, new DateTime(2022, 10, 12), unaCantidad, 4, unMozo, 12, 70, false);

            unPlato = BuscarPlato(1);
            unCliente = BuscarCliente(2);
            unMozo = BuscarMozo(10);
            unaCantidad = CargarCantidadPlatos(unPlato, 4);
            CargarLocal( unCliente, new DateTime(2020, 02, 12), unaCantidad, 4, unMozo, 9, 70, false);

            unPlato = BuscarPlato(1);
            unCliente = BuscarCliente(5);
            unMozo = BuscarMozo(10);
            unaCantidad = CargarCantidadPlatos(unPlato, 4);
            CargarLocal(unCliente, new DateTime(2021, 01, 22), unaCantidad, 4, unMozo, 7, 70, false);

            //Deliverys
            Repartidor unRepartidor;

            unRepartidor = BuscarRepartidor(11);
            unPlato = BuscarPlato(1);
            unCliente = BuscarCliente(3);
            unaCantidad = CargarCantidadPlatos(unPlato, 5);
            CargarDelivery( unCliente, new DateTime(2021, 01, 31), unaCantidad, "Rivera", unRepartidor, 10, false);

            unRepartidor = BuscarRepartidor(11);
            unPlato = BuscarPlato(4);
            unCliente = BuscarCliente(2);
            unaCantidad = CargarCantidadPlatos(unPlato, 2);
            CargarDelivery(unCliente, new DateTime(2021, 02, 18), unaCantidad, "Propios", unRepartidor, 4, false);

            unRepartidor = BuscarRepartidor(11);
            unPlato = BuscarPlato(2);
            unCliente = BuscarCliente(1);
            unaCantidad = CargarCantidadPlatos(unPlato, 2);
            CargarDelivery(unCliente, new DateTime(2022, 01, 13), unaCantidad, "Mariano Soler", unRepartidor, 10, false);

            unRepartidor = BuscarRepartidor(12);
            unPlato = BuscarPlato(4);
            unCliente = BuscarCliente(1);
            unaCantidad = CargarCantidadPlatos(unPlato, 8);
            CargarDelivery( unCliente, new DateTime(2022, 05, 21), unaCantidad, "18 de julio", unRepartidor, 15, false);

            unRepartidor = BuscarRepartidor(13);
            unPlato = BuscarPlato(2);
            unCliente = BuscarCliente(3);
            unaCantidad = CargarCantidadPlatos(unPlato, 2);
            CargarDelivery( unCliente, new DateTime(2022, 08, 12), unaCantidad, "Bulevar Artigas", unRepartidor, 30, false);

            unRepartidor = BuscarRepartidor(14);
            unPlato = BuscarPlato(5);
            unCliente = BuscarCliente(4);
            unaCantidad = CargarCantidadPlatos(unPlato, 1);
            CargarDelivery( unCliente, new DateTime(2022, 03, 24), unaCantidad, "Orinoco", unRepartidor, 50, false);

            unRepartidor = BuscarRepartidor(15);
            unPlato = BuscarPlato(1);
            unCliente = BuscarCliente(3);
            unaCantidad = CargarCantidadPlatos(unPlato, 8);
            CargarDelivery( unCliente, new DateTime(2022, 09, 10), unaCantidad, "Rivera", unRepartidor, 20, false);
        }

        //===================================METODOS PARA CARGAR LOS OBJETOS===============================
        public bool CargarPlato(int id, string nombre, decimal precio)
        {
            Plato unPlato;
            unPlato = new Plato(id, nombre, precio);
            return AgregarPlato(unPlato);
        }

        public bool CargarCliente(string nombre, string apellido, string password, string nombreUsuario, string rol, string mail)
        {
            Cliente unCliente;
            unCliente = new Cliente(nombre, apellido, password, nombreUsuario, rol, mail);
            //AgregarPersona(nombre, apellido, password,nombreUsuario, rol, mail)
            return AgregarCliente(unCliente);
        }

        public bool CargarMozo(string password, string nombre, string apellido, string nombreUsuario, string rol)
        {
            Mozo unMozo;
            unMozo = new Mozo(password, nombre, apellido, nombreUsuario, rol);
            return AgregarMozo(unMozo);
        }

        public bool CargarRepartidor(string password, string nombre, string apellido, string nombreUsuario, string rol, string tipoVehiculo)
        {
            Repartidor unRepartidor;
            unRepartidor = new Repartidor(password, nombre, apellido, nombreUsuario, rol, tipoVehiculo);
            return AgregarRepartidor(unRepartidor);
        }

        public bool CargarDelivery( Cliente UnCliente, DateTime unaFecha, CantidadPlatos unaCantidad, string Direccion, Repartidor unRepartidor, decimal distancia, bool estado)
        {
            Delivery unDelivery;
            unDelivery = new Delivery( UnCliente, unaFecha, unaCantidad, estado,  Direccion, unRepartidor, distancia);
            return AgregarDelivery(unDelivery, unaCantidad);
        }

        public bool CargarLocal( Cliente UnCliente, DateTime unaFecha, CantidadPlatos unaCantidad, int nuemroMesa, Mozo unMozo, int cantComensales, decimal precioCubierto, bool estado)
        {
            Local unLocal;
            unLocal = new Local(UnCliente, unaFecha, unaCantidad, estado, nuemroMesa, unMozo, cantComensales, precioCubierto);
            return AgregarLocal(unLocal, unaCantidad);
        }

        public CantidadPlatos CargarCantidadPlatos(Plato unPlato, int cantidad)
        {
            if (cantidad > 0)
            {
                CantidadPlatos unaCantidad;
                unaCantidad = new CantidadPlatos(cantidad, unPlato);
                return unaCantidad;
            }
            return null;
        }

        //===================================METODOS PARA AGREGAR OBJETOS EN LAS LISTAS===============================

        public bool AgregarPlato(Plato unPlato)
        {
            bool exito = false;
            if (unPlato != null && unPlato.Validar() && !platos.Contains(unPlato))
            {
                platos.Add(unPlato);
                exito = true;
            }
            return exito;
        }

        public bool AgregarDelivery(Delivery unDelivery, CantidadPlatos unaCantidad)
        {
            if (unDelivery != null && unaCantidad != null && !deliverys.Contains(unDelivery))
            {
                deliverys.Add(unDelivery);
                servicios.Add(unDelivery);
                return true;
            }
            else
            {
                BuscarLocal(unDelivery.Id).AgregarPlato(unaCantidad);
            }
            return true;
        }

        public bool AgregarLocal(Local unLocal, CantidadPlatos unaCantidad)
        {
            if (unLocal != null && unLocal.Validar() && unaCantidad != null && !locales.Contains(unLocal))
            {
                locales.Add(unLocal);
                servicios.Add(unLocal);
                return true;
            }
            else
            {
                BuscarLocal(unLocal.Id).AgregarPlato(unaCantidad);
            }
            return true;
        }

        public bool AgregarCliente(Cliente unCliente)
        {
            bool exito = false;
            if (unCliente != null && unCliente.Validar() && !clientes.Contains(unCliente))
            {
                clientes.Add(unCliente);
                personas.Add(unCliente);
                exito = true;
            }
            return exito;
        }

        public bool AgregarMozo(Mozo unMozo)
        {
            bool exito = false;
            if (unMozo != null && unMozo.Validar() && !mozos.Contains(unMozo))
            {
                mozos.Add(unMozo);
                personas.Add(unMozo);
                exito = true;
            }
            return exito;
        }

        public bool AgregarRepartidor(Repartidor unRepartidor)
        {
            bool exito = false;
            if (unRepartidor != null && unRepartidor.Validar() && !repartidores.Contains(unRepartidor))
            {
                repartidores.Add(unRepartidor);
                personas.Add(unRepartidor);
                exito = true;
            }
            return exito;
        }

        //===================================METODOS PARA BUSCAR OBJETOS EN LAS LISTAS===============================

        //Busca un servicio local en la lista de los servicios locales
        public Local BuscarLocal(int id)
        {
            foreach (Local item in locales)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return null;
        }

        //Busca un cliente en la lista de los clientes
        public Cliente BuscarCliente(int id)
        {
            foreach (Cliente item in clientes)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return null;
        }

        //Busca un repartidor en la lista de los repartidores
        public Repartidor BuscarRepartidor(int id)
        {
            foreach (Repartidor item in repartidores)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return null;
        }

        //Busca un mozo en la lista de los mozos
        public Mozo BuscarMozo(int id)
        {
            foreach (Mozo item in mozos)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return null;
        }


        //Busca un plato en la lista de los platos
        public Plato BuscarPlato(int id)
        {
            foreach (Plato item in platos)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return null;
        }

        //Busca un servicio de delivery en la lista de los deliverys
        //dependiendo de que repartidor lo entrego y entre que rango de fechas 
        //se realizo la entrega.
        public List<Delivery> BuscarServiciosDeRepartidor(Repartidor unRepartidor, DateTime inicial, DateTime final)
        {
            List<Delivery> aux = new List<Delivery>();
            foreach (Delivery item in deliverys)
            {
                if (item.Repartidor.Id == unRepartidor.Id && item.Fecha.CompareTo(inicial) == 1 && item.Fecha.CompareTo(final) == -1)
                {
                    aux.Add(item);
                }
            }

            if (aux.Count == 0)
            {
                return null;
            }
            else
            {
                return aux;
            }

        }

      


        //===================================METODOS QUE DEVUELVEN LISTAS===============================
        public List<Delivery> ListarDeliverys()
        {
            List<Delivery> aux = new List<Delivery>();
            foreach (Delivery item in deliverys)
            {
                aux.Add(item);
            }
            return aux;
        }

        public List<Delivery> ServicioDeliveryPorClienteEstadoAbierto(int id)
        {
            List<Delivery> aux = new List<Delivery>();
            foreach (Delivery item in deliverys)
            {
                if (item.Cliente.Id == id && item.Estado == true)
                {
                    aux.Add(item);
                }   
            }
            return aux;
        }

        public List<Persona> ListaPersona()
        {
            List<Persona> aux = new List<Persona>();
            foreach (Persona item in personas)
            {
                aux.Add(item);
            }
            return aux;
        }

        public List<Local> ListarLocales()
        {
            List<Local> aux = new List<Local>();
            foreach (Local item in locales)
            {
                aux.Add(item);
            }
            return aux;
        }

       

        public List<Plato> ListarPlatos()
        {
            List<Plato> aux = new List<Plato>();
            foreach (Plato item in platos)
            {
                aux.Add(item);
            }

            if (aux.Count == 0)
            {
                return null;
            }
            aux.Sort();
            return aux;
        }

        public List<Cliente> ListarClientes()
        {
            List<Cliente> aux = new List<Cliente>();
            foreach (Cliente item in clientes)
            {
                aux.Add(item);
            }

            if (aux.Count == 0)
            {
                return null;
            }
            else
            {
                aux.Sort();
                return aux;
            }
        }

        //===================================METODO QUE MODIFICA EL PRECIO MINIMO DE LOS PLATOS===============================
        public bool ModificarPrecio(decimal nuevoPrecio)
        {
            return Plato.ModificarPrecioMinimo(nuevoPrecio);
        }

        //====================================LISTAS DE TODOS LOS DATOS PRECARGADOS==========================
        public List<Mozo> ListarMozo()
        {
            List<Mozo> aux = new List<Mozo>();
            foreach (Mozo item in mozos)
            {
                aux.Add(item);
            }

            return aux;
        }

        public List<Repartidor> ListarRepartidores()
        {
            List<Repartidor> aux = new List<Repartidor>();
            foreach (Repartidor item in repartidores)
            {
                aux.Add(item);
            }
            return aux;
        }

        //======================================= AGREGADAS PARA OBLIGATORIO MVC ====================================================================

        //Recorre la lista de las personas donde se encuentran los clientes, mozos y repartidores.
        public Persona ObtenerPersona(string nombreUsuario, string pass)
        {
            foreach (Persona item in personas)
            {
                //Falta validar mayusculas y minusculas y espacios.
                if (item.NombreUsuario == nombreUsuario && item.Password == pass)
                {
                    return item;
                }
            }
            return null;
        }

        //Busca el Servicio que a hecho el repartidor identificado con el id.
        public List<Delivery> ServicioRepartidor(string usuario, int id)
        {
            List<Delivery> aux = new List<Delivery>();

            foreach (Delivery item in deliverys)
            {
                if (item.Repartidor.Id == id && item.Repartidor.NombreUsuario == usuario)
                {
                    aux.Add(item);
                }
            }
            return aux;
        }

        //Busca los servicios entre determinadas fechas.
        public List<Local> ServicioLocal(DateTime inicial, DateTime final)
        {
            List<Local> aux = new List<Local>();
            foreach (Local item in locales)
            {
                if (item.Fecha >= inicial && item.Fecha <= final)
                {
                    aux.Add(item);
                }
            }
            return aux;
        }

        //Devuelve el cliente que pidio un servicio entre determinadas fechas.
        public List<Servicio> ServicioClienteFiltradoPorfecha(DateTime inicio, DateTime fin, string nombreUsuario)
        {
            List<Servicio> aux = new List<Servicio>();
            foreach (Servicio item in servicios)
            {
                if(item.Fecha >= inicio && item.Fecha <= fin && item.Cliente.NombreUsuario == nombreUsuario)
                {
                    aux.Add(item);
                }
            }
            return aux;
        }


        //Agrega los likes a los platos.
        public void AgregarLike(string nombre)
        {
            foreach (Plato item in platos)
            {
                if(item.Nombre == nombre)
                {
                    item.AgregarLike();
                }
            }
        }

        //Solicita el servicio local.
        public bool SolicitarServicioLocal(int idPlato, int idMozo, int cantidad, DateTime fecha, int mesa, int comensales, decimal cubierto, string nombreUsuario, bool estado)
        {
            Cliente unCliente = BuscarClienteXnombre(nombreUsuario);
            Plato unPlato = BuscarPlato(idPlato);
            Mozo unMozo = BuscarMozo(idMozo);
            CantidadPlatos unaCantidad = CargarCantidadPlatos(unPlato, cantidad);
            CargarLocal(unCliente, fecha, unaCantidad, mesa, unMozo, comensales, cubierto, estado);

            return true;
        }

        //Solicita el servicio del delivery.
        public bool SolicitarDelivery(DateTime fecha, int idPlato, int cantidad, string direccion, int idRepartidor, decimal distancia, string nombreUsuario, bool estado)
        {
            Repartidor unRepartidor = BuscarRepartidor(idRepartidor);
            Plato unPlato = BuscarPlato(idPlato);
            Cliente unCliente = BuscarClienteXnombre(nombreUsuario);
            CantidadPlatos unaCantidad = CargarCantidadPlatos(unPlato, cantidad);
            CargarDelivery(unCliente, fecha, unaCantidad, direccion, unRepartidor, distancia, estado);

            return true;
        }

        //Cierra los servicios locales que estan en estado abierto(de false pasa a true)
        public bool CerrarCaja(int id)
        {
            foreach (Local item in locales)
            {
                if (item.Id == id)
                {
                    item.Estado = false;
                }
            }
            return true;
        }

        //Cierra los servicios deliverys que estan en estado abierto(de false pasa a true)
        public bool CerrarCajaDelivery(int id)
        {
            foreach (Delivery item in deliverys)
            {
                if (item.Id == id)
                {
                    item.Estado = false;
                }
            }
            return true;
        }

        //Agrega un plato a un servicio.
        public bool AgregarPlatoServicio(int idPlato, int cantidad, int idServicio)
        {
            bool exito = false;
            Plato unPlato = BuscarPlato(idPlato);
            CantidadPlatos unaCantidad = CargarCantidadPlatos(unPlato, cantidad);

            foreach (Servicio item in servicios)
            {
                if (item.Id == idServicio)
                {
                    item.AgregarPlato(unaCantidad);
                    exito = true;
                }
            }
            return exito;
        }
        
        //Dado el nombre de un plato, muestra todos sus servicios en los que se pidio ese plato
        //al menos una vez.
        public List<Servicio> MostrarPlatoUnaVez(string nombreUsuario, int id)
        {
            List<Servicio> aux = new List<Servicio>();
            foreach (Servicio item in servicios)
            {
                if (item.Cliente.NombreUsuario == nombreUsuario)
                {
                    foreach (Plato pla in item.ListarTodoslosPlatos())
                    {
                        if (pla.Id == id)
                        {
                            aux.Add(item);
                        }
                    }
                }
            }
            return aux;
        }

        //Muestra el servicio mas caro de un cliente.
        public List<Servicio> ServicioMasCaro(string nombreUsuario)
        {
            double max = double.MinValue;
            List<Servicio> aux = new List<Servicio>();

            foreach (Servicio item in ListarServicioPorCliente(nombreUsuario))
            {
                double precioTotal = item.CalcularPrecio();
                if (precioTotal > max)
                {
                    aux.Clear();
                    aux.Add(item);
                    max = precioTotal;
                }
                else if (precioTotal == max)
                {
                    aux.Add(item);
                }
            }

            return aux;
        }

        //Muestra todos los servicios.
        public List<Servicio> ListarServicio()
        {
            List<Servicio> aux = new List<Servicio>();
            foreach (Servicio item in servicios)
            {
                aux.Add(item);
            }
            return aux;
        }

        //Lista los servicios realizados por un cliente.
        public List<Servicio> ListarServicioPorCliente(string nombreUsuario)
        {
            List<Servicio> aux = new List<Servicio>();
            foreach (Servicio item in servicios)
            {
                if (item.Cliente.NombreUsuario == nombreUsuario)
                {
                    aux.Add(item);
                }
            }
            return aux;
        }

        //Muestra los servicios locales en estado abierto y de un cliente en particular.
        public List<Local> ServiciosLocalesPorClienteEstadoAbierto(int id)
        {
            List<Local> aux = new List<Local>();
            foreach (Local item in locales)
            {
                if (item.Cliente.Id == id && item.Estado == true)
                {
                    aux.Add(item);
                }

            }
            return aux;
        }

        //Busca al cliente y lo devuelve.
        public Cliente BuscarClienteXnombre(string NombreUsuario)
        {
            foreach (Cliente item in clientes)
            {
                if (NombreUsuario == item.NombreUsuario)
                {
                    return item;
                }
            }
            return null;
        }

    }
}
