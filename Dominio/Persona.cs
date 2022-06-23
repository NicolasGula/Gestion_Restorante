using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
            public abstract class Persona : IComparable<Cliente>, IValidable
    {
        //ID AUTONUMERICO
        private static int idAuto = 0;

        //ATRIBUTOS
        private int id;
        private string nombre;
        private string apellido;
        private string nombreUsuario;
        private string password;
        private string rol;


        //PROPERTYS
        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }



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

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public Persona()
        {
        }

        //CONSTRUCTOR
        public Persona(string password, string nombre, string apellido, string nombreUsuario, string rol)
        {
            this.id = ++idAuto;
            this.nombre = nombre;
            this.apellido = apellido;
            this.password = password;
            this.nombreUsuario = nombreUsuario;
            this.rol = rol;
        }

        //VALIDACIONES
        public bool Validar()
        {
            return ValidarNombrePersona() && ValidarApellido() && ValidarPassword();
        }

        private bool ValidarNombrePersona()
        {
            return Validaciones.ValidarTexto(this.nombre) && EncontrarNumero(this.Nombre);
        }

        public bool ValidarApellido()
        {
            return Validaciones.ValidarTexto(this.apellido) && EncontrarNumero(this.apellido);
        }

        //CERCIORA QUE UN TEXTO NO TENGA NUMEROS.
        public bool EncontrarNumero(string palabra)
        {
            bool exito = true;
            int i = 0;
            do
            {
                char letra = palabra[i];
                if (letra >= '0' && letra <= '9')
                {
                    exito = false;
                }
                i++;
            } while (exito && i < palabra.Length);

            return exito;
        }

        //COMPARA LOS CLIENTES POR APELLIDO
        //SI EL APELLIDO EMPIEZA POR LA MISMA LETRA
        //LOS ORDENA POR NOMBRE
        public int CompareTo(Cliente unCliente)
        {
            int orden = Apellido.CompareTo(unCliente.Apellido);
            if (orden == 0)
            {
                orden = Nombre.CompareTo(unCliente.Nombre);
            }
            return orden;
        }

        //LLAMA A TODOS LOS METODOS PARA VALIDAR EL PASSWORD
        //LONGITUD DE PASSWORD, SI CONTIENE UNA MINUSCULA, UNA MAYUSCULA Y UN NUMERO.
        public bool ValidarPassword()
        {
            if (Password.Length >= 6)
            {
                if (BuscarMinuscula())
                {
                    if (BuscarMayuscula())
                    {
                        if (BuscarNumero())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        //VALIDA QUE EL PASSWORD TENGA AL MENOS UNA MINUSCULA.
        public bool BuscarMinuscula()
        {
            bool exito = false;
            int i = 0;
            do
            {
                char letra = Password[i];
                if (letra >= 'a' && letra <= 'z')
                {
                    exito = true;
                }
                i++;
            } while (!exito && i < Password.Length);
            return exito;
        }

        //VVALIDA QUE EL PASSWORD TENGA AL MENOS UNA MAYUSCULA.
        public bool BuscarMayuscula()
        {
            bool exito = false;
            int i = 0;
            do
            {
                char letra = this.Password[i];
                if (letra >= 'A' && letra <= 'Z')
                {
                    exito = true;
                }
                i++;
            } while (!exito && i < this.Password.Length);
            return exito;
        }

        //VALIDA QUE EL PASSWORD TENGA AL MENOS UN NUMERO.
        public bool BuscarNumero()
        {
            bool exito = false;
            int i = 0;
            do
            {
                char letra = this.Password[i];
                if (letra >= '0' && letra <= '9')
                {
                    exito = true;
                }
                i++;
            } while (!exito && i < this.Password.Length);
            return exito;
        }


    }
} 
  

