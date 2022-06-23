using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public class Cliente : Persona, IEquatable<Cliente>, IValidable
    {
        //ATRIBUTOS
        private string mail;

        //PROPIEDADES
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public Cliente()
        {
        }


        //CONSTRUCTOR
        public Cliente(string nombre, string apellido, string password, string nombreUsuario, string rol, string mail) : base(password, nombre, apellido, nombreUsuario, rol)
        {
            this.mail = mail;
        }


        //VALIDACIONES
        public bool Validar()
        {
            return
                ValidarMail() &&
                base.Validar();
        }

        //VALIDA EL MAIL.
        //"System.ComponentModel.DataAnnotations" provee clases de atributos que
        //se usan para definir metadatos para controles de datos.
        //En este caso EmailAddressAtribute inicializa una nueva instancia de su clase
        //que valida direcciones de correo.
        public bool ValidarMail()
        {
            var testerDeEmail = new EmailAddressAttribute();
            bool exito = testerDeEmail.IsValid(this.mail);
            return exito;
        }



        //EQUALS
        public bool Equals(Cliente unCliente)
        {
            return unCliente != null && Id == unCliente.Id;
        }

        //TOSTRING
        public override string ToString()
        {
            string cliente = "";
            cliente += $"APELLIDO: {base.Apellido}\n";
            cliente += $"NOMBRE:{base.Nombre}\n";
            cliente += $"ID: {base.Id}\n";
            cliente += $"EMAIL: {mail}\n";
            return cliente;
        }

    }
}
