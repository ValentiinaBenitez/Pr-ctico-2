using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICO2
{
    internal class Utilitario:Vehiculo
    {
        public int capacidadMaxima;
        public Utilitario(int numero, string matricula, string marca, string color, int capacidadTanque, bool disponibilidad, int precioAlquilerDia, int kmLitro, int capacidadMaxima) : base(numero, matricula, marca, color, capacidadTanque, disponibilidad, precioAlquilerDia, kmLitro)
        {
            this.capacidadMaxima = capacidadMaxima;
        }
        public int GetCapacidadMaxima() => capacidadMaxima;
        public void SetCapacidadMaxima(int capacidadMaxima) => this.capacidadMaxima = capacidadMaxima;
    }
}
