using System;
using System.Collections.Generic;


public class Cliente
{
    private string nombre;
    private int edad;
    private string correo;

    public Cliente(string nombre, int edad, string correo)
    {
        this.nombre = nombre;
        this.edad = edad;
        this.correo = correo;
    }

    //Metodos para obtener y establecer el nombre
    public void SetNombre(string nombre)
    {
        this.nombre = nombre;
    }

    public string GetNombre()
    {
        return nombre;
    }

    //Metodos para obtener y establecer la edad
    public void SetEdad(int edad)
    {
        this.edad = edad;
    }

    public int GetEdad()
    {
        return edad;
    }

    //Metodos para obtener y establecer el correo
    public void SetCorreo(string correo)
    {
        this.correo = correo;
    }

    public string GetCorreo()
    {
        return correo;
    }

    //Metodo virtual para mostrar información
    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {nombre}, Edad: {edad}, Correo: {correo}");
    }
}

//Clase derivada Cliente Corporativo
public class ClienteCorporativo : Cliente
{
    private string nombreEmpresa;

    public ClienteCorporativo(string nombre, int edad, string correo, string nombreEmpresa)
        : base(nombre, edad, correo)
    {
        this.nombreEmpresa = nombreEmpresa;
    }

    //Metodos para obtener y establecer el nombre de la empresa
    public void SetNombreEmpresa(string nombreEmpresa)
    {
        this.nombreEmpresa = nombreEmpresa;
    }

    public string GetNombreEmpresa()
    {
        return nombreEmpresa;
    }

    //Sobrescribir el metodo para incluir el nombre de la empresa
    public override void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {GetNombre()}, Edad: {GetEdad()}, Correo: {GetCorreo()}, Empresa: {nombreEmpresa}");
    }
}

class Program
{
    //Lista para almacenar los clientes
    static List<Cliente> clientes = new List<Cliente>();

    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Agregar Cliente");
            Console.WriteLine("2. Listar Clientes");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarCliente();
                    break;
                case "2":
                    ListarClientes();
                    break;
                case "3":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void AgregarCliente()
    {
        Console.Write("Ingrese el nombre del cliente: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la edad del cliente: ");
        int edad = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el correo del cliente: ");
        string correo = Console.ReadLine();

        Console.Write("¿Es un cliente corporativo? (s/n): ");
        string esCorporativo = Console.ReadLine();

        if (esCorporativo.ToLower() == "s")
        {
            Console.Write("Ingrese el nombre de la empresa: ");
            string nombreEmpresa = Console.ReadLine();

            ClienteCorporativo nuevoCliente = new ClienteCorporativo(nombre, edad, correo, nombreEmpresa);
            clientes.Add(nuevoCliente);
        }
        else
        {
            Cliente nuevoCliente = new Cliente(nombre, edad, correo);
            clientes.Add(nuevoCliente);
        }

        Console.WriteLine("Cliente agregado con éxito.\n");
    }

    static void ListarClientes()
    {
        Console.WriteLine("\nLista de Clientes:");

        foreach (var cliente in clientes)
        {
            cliente.MostrarInformacion();
        }

        Console.WriteLine();
    }
}