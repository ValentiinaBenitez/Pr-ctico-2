using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICO2
{
    internal class Familiar:Vehiculo
    {
        public int capacidadMaletero;
        public Familiar(int numero, string matricula, string marca, string color, int capacidadTanque, bool disponibilidad, int precioAlquilerDia, int kmLitro, int capacidadMaletero) : base(numero, matricula, marca, color, capacidadTanque, disponibilidad, precioAlquilerDia, kmLitro)
        {
            this.capacidadMaletero = capacidadMaletero;
        }
        public int GetCapacidadMaletero() => capacidadMaletero;
        public void SetCapacidadMaletero(int capacidadMaletero) => this.capacidadMaletero = capacidadMaletero;
    }
}
