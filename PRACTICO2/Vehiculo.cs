using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICO2
{
    internal class Vehiculo
    {
        protected int numero;
        protected string matricula;
        protected string marca;
        protected string color;
        protected int capacidadTanque;
        protected bool disponibilidad;
        protected int precioAlquilerDia;
        protected int kmLitro;

        public Vehiculo() { }
        public Vehiculo(int numero, string matricula, string marca, string color, int capacidadTanque,
            bool disponibilidad, int precioAlquilerDia, int kmLitro)
        {
            this.numero = numero;
            this.matricula = matricula;
            this.marca = marca;
            this.color = color;
            this.capacidadTanque = capacidadTanque;
            this.disponibilidad = disponibilidad;
            this.precioAlquilerDia = precioAlquilerDia;
            this.kmLitro = kmLitro;
        }
        public int GetNumero() => numero;
        public string GetMatricula() => matricula;
        public string GetMarca() => marca;
        public string GetColor() => color;
        public int GetCapacidadTanque() => capacidadTanque;
        public bool GetDisponibilidad() => disponibilidad;
        public int GetPrecioAlquilerDia() => precioAlquilerDia;
        public int GetKmLitro() => kmLitro;

        public void SetNumero(int numero) => this.numero = numero;
        public void SetMatricula(string matricula) => this.matricula = matricula;
        public void SetMarca(string marca) => this.marca = marca;
        public void SetColor(string color) => this.color = color;
        public void SetCapacidadTanque(int capacidadTanque) => this.capacidadTanque = capacidadTanque;
        public void SetDisponibilidad(bool disponibilidad) => this.disponibilidad = disponibilidad;
        public void SetPrecioAlquilerDia(int precioAlquilerDia) => this.precioAlquilerDia = precioAlquilerDia;
        public void SetKmLitro(int kmLitro) => this.kmLitro = kmLitro;

        public void CambiarDisponibilidad()
        {
            if (this.GetDisponibilidad() == true)

                this.SetDisponibilidad(false);

            else this.SetDisponibilidad(true);
        }
    }
}
