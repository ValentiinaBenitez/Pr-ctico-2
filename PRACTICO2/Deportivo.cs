using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICO2
{
    internal class Deportivo : Vehiculo
    {
        private int velocidadMaxima;
        public Deportivo(int numero, string matricula, string marca, string color, int capacidadTanque, bool disponibilidad, int precioAlquilerDia, int kmLitro, int velocidadMaxima) : base(numero, matricula, marca, color, capacidadTanque, disponibilidad, precioAlquilerDia, kmLitro)
        {
            this.velocidadMaxima = velocidadMaxima;
        }
        public int GetVelocidadMaxima() => velocidadMaxima;
        public void SetVelocidadMaxima(int velocidadMaxima) => this.velocidadMaxima = velocidadMaxima;
    }
}

