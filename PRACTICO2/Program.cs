using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PRACTICO2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            List<Alquiler> alquileres = new List<Alquiler>();
            Sucursal sucursal = new Sucursal(1, "Maldonado", alquileres, vehiculos);

            Deportivo Ferrari = new Deportivo(100, "AB516", "Ferrari", "Amarillo", 100, false, 500, 2, 290);
            Familiar Honda = new Familiar(45, "DF854", "Honda", "Blanco", 80, false, 100, 12, 6);
            Utilitario Citroen = new Utilitario(22, "LM325", "Citroen", "Gris", 60, false, 90, 18, 80);
            Deportivo Porsche = new Deportivo(200, "YT689", "Porsche", "Negro", 110, true, 600, 10, 300);
            Familiar Fiat = new Familiar(50, "TVJ222", "Fiat", "Rojo", 90, true, 150, 12, 7);
            Utilitario VW = new Utilitario(33, "SPO710", "Volkswagen", "Azul", 90, true, 85, 18, 75);
            sucursal.IngresarVehiculo(Ferrari);
            sucursal.IngresarVehiculo(Honda);
            sucursal.IngresarVehiculo(Citroen);
            sucursal.IngresarVehiculo(Porsche);
            sucursal.IngresarVehiculo(Fiat);
            sucursal.IngresarVehiculo(VW);

            Cliente cliente1 = new Cliente(23456789, "Susana", "Rodriguez", 097863655);
            List<Vehiculo> VehiculosAlquiladosA1 = new List<Vehiculo>();
            VehiculosAlquiladosA1.Add(Ferrari);
            VehiculosAlquiladosA1.Add(Honda);
            sucursal.IngresarCliente(cliente1);

            Alquiler alquiler1 = new Alquiler(01, cliente1, VehiculosAlquiladosA1);
            alquiler1.AgregarDetalle(Ferrari, DateTime.Now, 3);
            alquiler1.AgregarDetalle(Honda, DateTime.Now, 2);
            int precioTotal = alquiler1.CalcPrecioTotal();
            alquiler1.SetPrecioTotal(precioTotal);
            alquileres.Add(alquiler1);

            Cliente cliente2 = new Cliente(25630892, "Pedro", "Martinez", 094761322);
            List<Vehiculo> VehiculosAlquiladosA2 = new List<Vehiculo>();
            VehiculosAlquiladosA2.Add(Citroen);
            sucursal.IngresarCliente(cliente2);

            Alquiler alquiler2 = new Alquiler(02, cliente2, VehiculosAlquiladosA2);
            alquiler2.AgregarDetalle(Citroen, DateTime.Now, 10);
            precioTotal = alquiler2.CalcPrecioTotal();
            alquiler2.SetPrecioTotal(precioTotal);
            alquileres.Add(alquiler2);

            Console.WriteLine("-- GESTIÓN RENTADORA DE VEHÍCULOS --");
            Console.WriteLine("");
            Console.WriteLine("Seleccione: ");
            Console.WriteLine("1. Stock de vehículos");
            Console.WriteLine("2. Buscar cliente y detallar alquileres");
            Console.WriteLine("3. Agregar cliente");
            Console.WriteLine("4. Ver lista de clientes");
            Console.WriteLine("5. Agregar nuevo vehículo");
            Console.WriteLine("6. Cambiar disponibilidad de vehículo");
            Console.WriteLine("7. Agregar alquiler");
            Console.WriteLine("8. Ver lista de alquileres");
            Console.WriteLine("0. Salir");
            Console.WriteLine("");
            int numero = ValidarNumeroConRango(8);
            Console.Clear();

            while (numero != 0)
            {
                if (numero == 1)
                {
                    Console.WriteLine("Desea ver solo los disponibles?");
                    Console.WriteLine("0. No // 1. Si");
                    numero = ValidarNumeroConRango(2);
                    Console.Clear();
                    Console.WriteLine($"|| STOCK DE VEHÍCULOS || {sucursal.VehiculosStock(numero)}");
                }
                else if (numero == 2)
                {
                    Console.WriteLine("Ingrese documento para buscar cliente y listar alquileres");
                    int docu = ValidarNumeroSinRango();
                    Console.Clear();
                    bool existeCliente = sucursal.BuscarCliente(docu);
                    if (existeCliente == true)
                    {
                        List<Alquiler> alquileresCliente = sucursal.DarAlquileresPorCliente(docu);
                        Console.WriteLine($"Cantidad de alquileres del cliente {docu}: {alquileresCliente.Count}");
                        Console.WriteLine($"\n-- Detalles\n{sucursal.DetallarListaCliente(alquileresCliente)}");
                    }
                    else Console.WriteLine("No existe un cliente registrado con ese documento");
                }
                else if (numero == 3)
                {
                    Console.WriteLine("Ingrese número de documento:");
                    int documento = ValidarNumeroSinRango();
                    bool existeCliente = sucursal.BuscarCliente(documento);
                    if (existeCliente == true)
                    {
                        Console.WriteLine("Ya existe un cliente con ese documento");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese nombre:");
                        string nombre = ValidarString();
                        Console.Clear();
                        Console.WriteLine("Ingrese apellido:");
                        string apellido = ValidarString();
                        Console.Clear();
                        Console.WriteLine("Ingrese teléfono: ");
                        int telefono = ValidarNumeroSinRango();
                        Console.Clear();
                        cliente1 = new Cliente(documento, nombre, apellido, telefono);
                        sucursal.IngresarCliente(cliente1);
                        Console.WriteLine("Cliente agregado!");
                    }
                }
                else if (numero == 4)
                {
                    Console.WriteLine(sucursal.ListarClientes());
                }
                else if (numero == 5)
                {
                    Console.WriteLine("Ingrese número de vehículo:");
                    int numVehiculo = ValidarNumeroSinRango();
                    bool existeVehiculo = sucursal.BuscarVehiculo(numVehiculo);
                    while (existeVehiculo == true)
                    {
                        Console.WriteLine("Ya existe un vehículo asociado a ese número, vuelva a ingresar.");
                        numVehiculo = ValidarNumeroSinRango();
                        existeVehiculo = sucursal.BuscarVehiculo(numVehiculo);
                    }
                    Console.Clear();
                    Console.WriteLine("Ingrese matricula:");
                    string matricula = ValidarString();
                    Console.Clear();
                    Console.WriteLine("Ingrese marca:");
                    string marca = ValidarString();
                    Console.Clear();
                    Console.WriteLine("Ingrese color:");
                    string color = ValidarString();
                    Console.Clear();
                    Console.WriteLine("Ingrese capacidad del tanque:");
                    int capacidadTanque = ValidarNumeroSinRango();
                    Console.Clear();
                    bool disponibilidad = true;
                    Console.WriteLine("Elige disponibilidad: 0. No disponible / 1. Disponible");
                    numero = ValidarNumeroConRango(2);
                    if (numero == 0) disponibilidad = false;
                    if (numero == 1) disponibilidad = true;
                    Console.Clear();
                    Console.WriteLine("Ingrese precio del alquiler por día ($USD): ");
                    int precioAlquilerDia = ValidarNumeroSinRango();
                    Console.Clear();
                    Console.WriteLine("Especifique km/Litro:");
                    int kmLitro = ValidarNumeroSinRango();
                    Console.Clear();
                    Console.WriteLine("Tipo de vehículo:");
                    Console.WriteLine(" Deportivo ---> 1");
                    Console.WriteLine(" Utilitario ---> 2");
                    Console.WriteLine(" Familiar ---> 3");
                    numero = ValidarNumeroConRango(3);
                    Console.Clear();
                    if (numero == 1)
                    {
                        Console.WriteLine("Especifique la velocidad máxima del vehículo:");
                        int velocidadMax = ValidarNumeroSinRango();
                        Deportivo deportivo1 = new Deportivo(numVehiculo, matricula, marca, color,
                            capacidadTanque, disponibilidad, precioAlquilerDia, kmLitro, velocidadMax);
                        sucursal.IngresarVehiculo(deportivo1);
                    }
                    else if (numero == 2)
                    {
                        Console.WriteLine("Especifique la capacidad máxima del vehículo (kg):");
                        int capacidadMax = ValidarNumeroSinRango();
                        Utilitario utilitario1 = new Utilitario(numVehiculo, matricula, marca, color,
                            capacidadTanque, disponibilidad, precioAlquilerDia, kmLitro, capacidadMax);
                        sucursal.IngresarVehiculo(utilitario1);
                    }
                    else if (numero == 3)
                    {
                        Console.WriteLine("Especifique la capacidad del maletero del vehículo (kg):");
                        int capacidadMal = ValidarNumeroSinRango();
                        Familiar familiar1 = new Familiar(numVehiculo, matricula, marca, color, capacidadTanque,
                            disponibilidad, precioAlquilerDia, kmLitro, capacidadMal);
                        sucursal.IngresarVehiculo(familiar1);
                    }
                    Console.Clear();
                    Console.WriteLine("Vehículo agregado!");

                }
                else if (numero == 6)
                {
                    Console.WriteLine($" <<< Vehículos >>> {sucursal.VehiculosStock(0)}");
                    Console.WriteLine("");
                    Console.WriteLine("Seleccione el número de vehículo para cambiar la disponibilidad");
                    Console.WriteLine("");
                    numero = ValidarNumeroSinRango();
                    bool existeVehiculo = sucursal.BuscarVehiculo(numero);
                    while (existeVehiculo == false)
                    {
                        Console.WriteLine("No existe un vehículo registrado con ese número, vuelva a ingresar.");
                        numero = ValidarNumeroSinRango();
                        existeVehiculo = sucursal.BuscarVehiculo(numero);
                    }
                    sucursal.CambiarDisponibilidadPorNumeroDeVehiculo(numero);
                    Console.WriteLine("Disponibilidad cambiada!");
                }
                else if (numero == 7)
                {
                    if (sucursal.VehiculosStock(1) != string.Empty)
                    {
                        Console.WriteLine("Ingrese número de alquiler:");
                        numero = ValidarNumeroSinRango();
                        bool existeAlquiler = sucursal.BuscarAlquiler(numero);
                        while (existeAlquiler == true)
                        {
                            Console.WriteLine("Ya existe un alquiler con ese número, vuelva a ingresar.");
                            numero = ValidarNumeroSinRango();
                            existeAlquiler = sucursal.BuscarAlquiler(numero);
                        }
                        Console.Clear();
                        Console.WriteLine("Ingrese documento del cliente:");
                        int docu = ValidarNumeroSinRango();
                        Console.Clear();
                        bool existeCliente = sucursal.BuscarCliente(docu);
                        Cliente clienteIngresado = new Cliente();
                        if (existeCliente == true)
                        {
                            clienteIngresado = sucursal.DevolverCliente(docu);

                        }
                        else
                        {
                            Console.WriteLine("Nuevo cliente - Datos a continuación");
                            Console.WriteLine("");
                            Console.WriteLine("Ingrese nombre:");
                            string nombre = ValidarString();
                            Console.Clear();
                            Console.WriteLine("Ingrese apellido:");
                            string apellido = ValidarString();
                            Console.Clear();
                            Console.WriteLine("Ingrese teléfono:");
                            int telefono = ValidarNumeroSinRango();
                            Console.Clear();
                            clienteIngresado = new Cliente(docu, nombre, apellido, telefono);
                            sucursal.IngresarCliente(cliente1);
                        }
                        List<Vehiculo> VehiculosAlquiladosA3 = new List<Vehiculo>();
                        Alquiler alquiler3 = new Alquiler(numero, clienteIngresado, VehiculosAlquiladosA3);
                        Console.WriteLine($" > Vehículos disponibles < {sucursal.VehiculosStock(1)}");
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese número de vehículo: ");
                        Vehiculo vehiculoAgregado = new Vehiculo();
                        numero = ValidarNumeroSinRango();
                        bool existeVehiculo = sucursal.BuscarVehiculo(numero);
                        while (existeVehiculo == false)
                        {
                            Console.WriteLine("El número que seleccionó no se encuentra en la lista, vuelva a ingresar.");
                            numero = ValidarNumeroSinRango();
                            existeVehiculo = sucursal.BuscarVehiculo(numero);
                        }
                        vehiculoAgregado = sucursal.DevolverVehiculo(numero);
                        vehiculoAgregado.CambiarDisponibilidad();
                        Console.Clear();
                        Console.WriteLine("Ingrese cantidad de días:");
                        int cantidadDias = ValidarNumeroSinRango();
                        alquiler3.AgregarDetalle(vehiculoAgregado, DateTime.Now, cantidadDias);
                        precioTotal = alquiler3.CalcPrecioTotal();
                        alquiler3.SetPrecioTotal(precioTotal);
                        alquileres.Add(alquiler3);
                        Console.Clear();
                        Console.WriteLine("Desea agregar otro vehículo a la operación?");
                        Console.WriteLine("0 -- No // 1 -- Si");
                        numero = ValidarNumeroConRango(2);
                        Console.Clear();
                        if (numero == 0)
                        {
                            Console.WriteLine("Operación realizada con éxito!");
                            Console.Clear();
                        }
                        else if (numero == 1 && sucursal.VehiculosStock(1) != string.Empty)
                        {
                            do
                            {
                                Console.WriteLine($" > Vehículos disponibles < {sucursal.VehiculosStock(1)}");
                                Console.WriteLine("");
                                Console.WriteLine("Ingrese número de vehículo: ");
                                Vehiculo vehiculoAgregado2 = new Vehiculo();
                                numero = ValidarNumeroSinRango();
                                existeVehiculo = sucursal.BuscarVehiculo(numero);
                                while (existeVehiculo == false)
                                {
                                    Console.WriteLine("El número que seleccionó no se encuentra en la lista, vuelva a ingresar.");
                                    numero = ValidarNumeroSinRango();
                                    existeVehiculo = sucursal.BuscarVehiculo(numero);
                                }
                                vehiculoAgregado2 = sucursal.DevolverVehiculo(numero);
                                Console.Clear();
                                Console.WriteLine("Ingrese cantidad de días:");
                                cantidadDias = ValidarNumeroSinRango();
                                alquiler3.AgregarDetalle(vehiculoAgregado2, DateTime.Now, cantidadDias);
                                precioTotal = alquiler3.CalcPrecioTotal();
                                alquiler3.SetPrecioTotal(precioTotal);
                                vehiculoAgregado2.CambiarDisponibilidad();
                                if (sucursal.VehiculosStock(1) != string.Empty)
                                {
                                    Console.WriteLine("Desea agregar otro vehículo a la operación?");
                                    Console.WriteLine("0 -- No // 1 -- Si");
                                    numero = ValidarNumeroConRango(2);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("No quedan vehículos disponibles.");
                                    Console.WriteLine("");
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                Console.Clear();

                            }
                            while (sucursal.VehiculosStock(1) != string.Empty && numero == 1);
                        }
                        Console.WriteLine("Operación realizada con éxito!");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("En este momento no se encuentran vehículos disponibles para alquilar.");
                        Console.WriteLine("Intente más tarde.");
                        Console.WriteLine("");
                    }
                }
                else if (numero == 8)
                {
                    Console.WriteLine(sucursal.DarListaAlquileres());
                }

                Console.WriteLine("Presione enter para continuar...");
                Console.ReadKey();
                Console.Clear();

                Console.WriteLine("-- GESTIÓN RENTADORA DE VEHÍCULOS --");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Seleccione: ");
                Console.WriteLine("1. Stock de vehículos");
                Console.WriteLine("2. Buscar cliente y detallar alquileres");
                Console.WriteLine("3. Agregar cliente");
                Console.WriteLine("4. Ver lista de clientes");
                Console.WriteLine("5. Agregar nuevo vehículo");
                Console.WriteLine("6. Cambiar disponibilidad de vehículo");
                Console.WriteLine("7. Agregar alquiler");
                Console.WriteLine("8. Ver lista de alquileres");
                Console.WriteLine("0. Salir");
                numero = ValidarNumeroConRango(8);
                Console.Clear();
            }
        }



        static short ValidarNumeroConRango(short rango)
        {
            short numero = 0;
            bool entradaValida = false;
            while (!entradaValida)
            {
                try
                {
                    numero = short.Parse(Console.ReadLine());
                    if (rango == 8)
                    {
                        if (numero >= 0 && numero <= 8)
                        {
                            entradaValida = true;
                        }
                        else Console.WriteLine("Número fuera de rango");
                    }
                    else if (rango == 2)
                    {
                        if (numero >= 0 && numero <= 1)
                        {
                            entradaValida = true;
                        }
                        else Console.WriteLine("Número fuera de rango");
                    }
                    else if (rango == 3)
                    {
                        if (numero >= 1 && numero <= 3)
                        {
                            entradaValida = true;
                        }
                        else Console.WriteLine("Número fuera de rango");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error. " + ex.Message);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Error. " + e.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Valor no válido, ingrese nuevamente.");
                }

            }
            return numero;

        }
        static int ValidarNumeroSinRango()
        {
            int numero = 0;
            bool entradaValida = false;
            while (!entradaValida)
            {
                try
                {
                    numero = int.Parse(Console.ReadLine());
                    entradaValida = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error. " + ex.Message);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Error. " + e.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Valor no válido, ingrese nuevamente.");
                }

            }
            return numero;
        }
        static string ValidarString()
        {
            string texto1 = "";
            bool entradaValida = false;
            while (!entradaValida)
            {
                try
                {
                    texto1 = Console.ReadLine();
                    if (String.IsNullOrEmpty(texto1))
                    {
                        Console.WriteLine("No se puede ingresar un valor vacío.");
                    }
                    else if (texto1.Contains(" "))
                    {
                        Console.WriteLine("No se puede ingresar un valor vacío.");
                    }
                    else
                    {
                        entradaValida = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Valor no válido, ingrese nuevamente.");
                }
            }
            return texto1;
        }
    }
}
