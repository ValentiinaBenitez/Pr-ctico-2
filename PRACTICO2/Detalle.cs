using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICO2
{
    internal class Detalle
    {
        private Vehiculo vehiculo;
        private DateTime fechaRetiro;
        private int cantidadDias;
        public Detalle(Vehiculo vehiculo, DateTime fechaRetiro, int cantidadDias)
        {
            this.vehiculo = vehiculo;
            this.fechaRetiro = fechaRetiro;
            this.cantidadDias = cantidadDias;
        }
        public Vehiculo GetVehiculo() => vehiculo;
        public DateTime GetFechaRetiro() => fechaRetiro;
        public int GetCantidadDias() => cantidadDias;

        public void SetVehiculo(Vehiculo vehiculo) => this.vehiculo = vehiculo;
        public void SetFechaRetiro(DateTime fechaRetiro) => this.fechaRetiro = fechaRetiro;
        public void SetCantidadDias(int cantidadDias) => this.cantidadDias = cantidadDias;

        public int CalcularPrecioDetalle()
        {
            int precioDetalle = 0;
            precioDetalle = vehiculo.GetPrecioAlquilerDia() * cantidadDias;
            return precioDetalle;
        }

    
        
    }
}
