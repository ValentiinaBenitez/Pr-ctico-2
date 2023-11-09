using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PRACTICO2
{
    internal class Sucursal
    {
        private int numero;
        private string direccion;
        private List<Alquiler> colAlquileres;
        private List<Vehiculo> colVehiculos;
        private List<Cliente> clientes = new List<Cliente>();

        public Sucursal(int numero, string direccion, List<Alquiler> colAlquileres, List<Vehiculo> colVehiculos)
        {
            this.numero = numero;
            this.direccion = direccion;
            this.colAlquileres = colAlquileres;
            this.colVehiculos = colVehiculos;
        }
        public int GetNumero() => numero;
        public string GetDireccion() => direccion;
        public List<Alquiler> GetColAlquileres() => colAlquileres;
        public List<Vehiculo> GetColVehiculos() => colVehiculos;

        public void SetNumero(int numero) => this.numero = numero;
        public void SetDireccion(string direccion) => this.direccion = direccion;
        public void SetColAlquileres(List<Alquiler> colAlquileres) => this.colAlquileres = colAlquileres;
        public void SetColVehiculos(List<Vehiculo> colVehiculos) => this.colVehiculos = colVehiculos;

        public string VehiculosStock(int numero)
        {
            var objetosFiltrados = colVehiculos.Where(obj => obj is Deportivo || obj is Utilitario || obj is Familiar).ToList();
            string info = "";
            if (numero == 0)
            {
                foreach (var obj in objetosFiltrados)
                {
                    if (obj is Deportivo)
                    {
                        info += "\n\n - DEPORTIVO - \n" + obj.GetNumero() + ". " + obj.GetMarca() + "\n    - " + 
                            obj.GetMatricula() + "\n    - " + obj.GetColor() + "\n    - Capacidad del tanque: " + 
                            obj.GetCapacidadTanque() + "\n    - Km/L: " + obj.GetKmLitro() + "\n    - $USD " + 
                            obj.GetPrecioAlquilerDia() + "\n    Velocidad maxima: " + ((Deportivo)obj).GetVelocidadMaxima() 
                            + "\n    Disponibilidad: " + obj.GetDisponibilidad();
                    }
                    else if (obj is Utilitario)
                    {
                        info += "\n\n - UTILITARIO - \n" + obj.GetNumero() + ". " + obj.GetMarca() + "\n    - " +
                            obj.GetMatricula() + "\n    - " + obj.GetColor() + "\n    - Capacidad del tanque: " + 
                            obj.GetCapacidadTanque() + "\n    - Km/L: " + obj.GetKmLitro() + "\n    - $USD " + 
                            obj.GetPrecioAlquilerDia() + "\n    Capacidad máxima: " + ((Utilitario)obj).GetCapacidadMaxima() 
                            + "kg \n    Disponibilidad: " + obj.GetDisponibilidad();
                    }
                    else if (obj is Familiar)
                    {
                        info += "\n\n - FAMILIAR - \n" + obj.GetNumero() + ". " + obj.GetMarca() + "\n    - " + 
                            obj.GetMatricula() + "\n    - " + obj.GetColor() + "\n    - Capacidad del tanque: " +
                            obj.GetCapacidadTanque() + "\n    - Km/L: " + obj.GetKmLitro() + "\n    - $USD " + 
                            obj.GetPrecioAlquilerDia() + "\n    Capacidad maletero: " + ((Familiar)obj).GetCapacidadMaletero() 
                            + "kg \n    Disponibilidad: " + obj.GetDisponibilidad();
                    }
                }
                return info;
            }
            else if (numero == 1)
            {

                foreach (var obj in objetosFiltrados)
                {
                    if (obj.GetDisponibilidad() == true)
                    {
                        if (obj is Deportivo)
                        {
                            info += "\n\n - DEPORTIVO - \n" + obj.GetNumero() + ". " + obj.GetMarca() + "\n    - " + 
                                obj.GetMatricula() + "\n    - " + obj.GetColor() + "\n    - Capacidad del tanque: " +
                                obj.GetCapacidadTanque() + "\n    - Km/L: " + obj.GetKmLitro() + "\n    - $USD " +
                                obj.GetPrecioAlquilerDia() + "\n    Velocidad maxima: " + ((Deportivo)obj).GetVelocidadMaxima();
                        }
                        else if (obj is Utilitario)
                        {
                            info += "\n\n - UTILITARIO - \n" + obj.GetNumero() + ". " + obj.GetMarca() + "\n    - " + 
                                obj.GetMatricula() + "\n    - " + obj.GetColor() + "\n    - Capacidad del tanque: " + 
                                obj.GetCapacidadTanque() + "\n    - Km/L: " + obj.GetKmLitro() +"\n    - $USD " + 
                                obj.GetPrecioAlquilerDia() + "\n    Capacidad máxima: " + ((Utilitario)obj).GetCapacidadMaxima();
                        }
                        else if (obj is Familiar)
                        {
                            info += "\n\n - FAMILIAR - \n" + obj.GetNumero() + ". " + obj.GetMarca() + "\n    - " + 
                                obj.GetMatricula() + "\n    - " + obj.GetColor() + "\n    - Capacidad del tanque: " + 
                                obj.GetCapacidadTanque() + "\n    - Km/L: " + obj.GetKmLitro() + "\n    - $USD " + 
                                obj.GetPrecioAlquilerDia() + "\n    Capacidad maletero: " + ((Familiar)obj).GetCapacidadMaletero();
                        }
                    }
                }
                return info;
            }
            return info;
        }
        public void IngresarVehiculo(Vehiculo vehiculo)
        {
            colVehiculos.Add(vehiculo);
        }

        public bool BuscarCliente(int documento)
        {
            foreach (Alquiler item in this.colAlquileres)
            {
                if (item.GetCliente().GetDocumento() == documento)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Alquiler> DarAlquileresPorCliente(int documento)
        {
            List<Alquiler> alquileresCliente = new List<Alquiler>();
            foreach (Alquiler item in this.colAlquileres)
            {
                if (item.GetCliente().GetDocumento() == documento)
                {
                    alquileresCliente.Add(item);
                }
            }
            return alquileresCliente;
        }
        public string DetallarListaCliente(List<Alquiler> alquileresCliente)
        {
            string info = "";
            foreach (Alquiler item in alquileresCliente)
            {
                info += "N° alquiler: " + item.GetNumero() + "\nPrecio total: " + item.CalcPrecioTotal() + 
                    "\nVehiculos incluidos\n" + item.VehiculosIncluidos() + "\nDetalle por vehículo\n" + 
                    item.DetalleDeCadaVehiculo() + "\n";
            }
            return info;
        }

        public void CambiarDisponibilidadPorNumeroDeVehiculo(int numero)
        {
            foreach (Vehiculo item in this.colVehiculos)
            {
                if (item.GetNumero() == numero)
                    item.CambiarDisponibilidad();
            }
        }

        public void IngresarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }
    
        public string ListarClientes()
        {
            string info = "";
            foreach (Cliente item in clientes) { 
                info += "Documento: " + item.GetDocumento() + " || Nombre: " + item.GetNombre() + 
                    " || Apellido: " + item.GetApellido() + " || Teléfono: " + item.GetTelefono() + "\n";
            }
            return info;
        }

        public Cliente DevolverCliente(int documento)
        {
            foreach (Cliente item in clientes)
            {
                if (item.GetDocumento() == documento)
                {
                    return item;  
                }
            }
            return null;
        }
        public Vehiculo DevolverVehiculo(int numero)
        {
            foreach (Vehiculo item in colVehiculos)
            {
                if (item.GetNumero() == numero)
                {
                    return item;
                }
            }
            return null;
        }
        
        public string DarListaAlquileres()
        {
            string info = "";
            foreach (Alquiler item in colAlquileres)
            {
                info += "Número de alquiler: " + item.GetNumero() + "\nPrecio total: " + item.GetPrecioTotal() + 
                    "\n" + item.DetalleDeCadaVehiculo() + "Cliente: " + item.GetCliente().GetNombre() + " " 
                    + item.GetCliente().GetApellido() + " - CI: " + item.GetCliente().GetDocumento() + "\n\n";
            }
            return info; 
        }
        public bool BuscarVehiculo(int numero)
        {
            foreach (Vehiculo item in colVehiculos)
            {
                if (item.GetNumero() == numero)
                {
                    return true;
                }
            }
            return false;
        }

        public bool BuscarAlquiler(int numero)
        {
            foreach (Alquiler item in colAlquileres)
            {
                if (item.GetNumero() == numero)
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}
