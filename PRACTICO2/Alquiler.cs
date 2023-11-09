using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICO2
{
    internal class Alquiler
    {
        private int numero;
        private int precioTotal = 0;
        private Cliente cliente;
        private List<Vehiculo> colVehiculos;
        private List<Detalle> colDetalles;

        public Alquiler(int numero, Cliente cliente, List<Vehiculo> colVehiculos)
        {
            this.numero = numero;
            this.cliente = cliente;
            this.colVehiculos = colVehiculos;
            this.colDetalles = new List<Detalle>();
        }
        
        public void AgregarDetalle(Vehiculo vehiculo, DateTime fechaRetiro, int cantidadDias)
        {
            Detalle detalle = new Detalle(vehiculo, fechaRetiro, cantidadDias);
            colDetalles.Add(detalle);
        }        
        
        public int GetNumero() => numero;
        public int GetPrecioTotal() => precioTotal;
        public Cliente GetCliente() => cliente;
        public List<Vehiculo> GetColVehiculos() => colVehiculos;
        public List<Detalle> GetColDetalles() => colDetalles;

        public void SetNumero(int numero) => this.numero = numero;
        public void SetPrecioTotal(int precioTotal) => this.precioTotal = precioTotal;
        public void SetCliente(Cliente cliente) => this.cliente = cliente;
        public void SetColVehiculos(List<Vehiculo> colVehiculos) => this.colVehiculos = colVehiculos;
        public void SetColDetalles(List<Detalle> colDetalles) => this.colDetalles = colDetalles;

        public string VehiculosIncluidos()
        {
            string infoVehiculo = "";
            foreach (Vehiculo item in this.colVehiculos)
            {
                infoVehiculo += "    " + item.GetMarca() + " - Matricula: " + item.GetMatricula() + "\n";
            }
            return infoVehiculo;
        }

        public int CalcPrecioTotal()
        {
            int precio = 0;
            foreach (Detalle detalle in colDetalles)
            {
                precio = precio + detalle.CalcularPrecioDetalle();
            }
            return precio;
        }

        public string DetalleDeCadaVehiculo()
        {
            string infoDetalles = "";
            foreach (Detalle item in this.colDetalles)
            {
                infoDetalles += item.GetVehiculo().GetMarca() + " // Fecha de retiro: " 
                    + item.GetFechaRetiro() + " // Cantidad de días: " + item.GetCantidadDias() + "\n";
            }
            return infoDetalles;
        }

    }
}
