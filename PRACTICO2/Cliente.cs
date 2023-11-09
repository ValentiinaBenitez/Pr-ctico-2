using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICO2
{
    internal class Cliente
    {
        private int documento;
        private string nombre;
        private string apellido;
        private int telefono;

        public Cliente() { }
        public Cliente(int documento, string nombre, string apellido, int telefono)
        {
            this.documento = documento;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
        }
        public int GetDocumento() => documento;
        public string GetNombre() => nombre;
        public string GetApellido() => apellido;
        public int GetTelefono() => telefono;

        public void SetDocumento(int documento) => this.documento = documento;
        public void SetNombre(string nombre) => this.nombre = nombre;
        public void SetApellido(string apellido) => this.apellido = apellido;
        public void SetTelefono(int telefono) => this.telefono = telefono;

        




    }
}
