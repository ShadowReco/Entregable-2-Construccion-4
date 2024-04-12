using System;
using System.Collections.Generic;

interface IJugador
{
    string Nombre { get; }
    int Rendimiento { get; }
}

class Jugador : IJugador
{
    public string Nombre { get; }
    public int Rendimiento { get; }

    public Jugador(string nombre)
    {
        Nombre = nombre;
        Random random = new Random();
        Rendimiento = random.Next(1, 11);
    }
}

class Equipo
{
    private List<IJugador> jugadores = new List<IJugador>();
    public string Nombre { get; }
    public int TotalRendimiento
    {
        get
        {
            int total = 0;
            foreach (var jugador in jugadores)
            {
                total += jugador.Rendimiento;
            }
            return total;
        }
    }

    public Equipo(string nombre)
    {
        Nombre = nombre;
    }

    public void AgregarJugador(IJugador jugador)
    {
        jugadores.Add(jugador);
    }

    public void ListarJugadores()
    {
        Console.WriteLine($"Jugadores del equipo {Nombre}:");
        foreach (var jugador in jugadores)
        {
            Console.WriteLine($"{jugador.Nombre} (Rendimiento: {jugador.Rendimiento})");
        }
    }
}

class ProgramaPrincipal
{
    static void Main()
    {
        Equipo equipo1 = new Equipo("Equipo A");
        Equipo equipo2 = new Equipo("Equipo B");

        for (int i = 1; i <= 6; i++)
        {
            Console.Write($"Ingrese el nombre del jugador {i}: ");
            string nombre = Console.ReadLine();
            Jugador jugador = new Jugador(nombre);

            if (i % 2 == 1)
                equipo1.AgregarJugador(jugador);
            else
                equipo2.AgregarJugador(jugador);
        }

        Console.WriteLine("\nJugadores en los equipos:");
        equipo1.ListarJugadores();
        equipo2.ListarJugadores();

        Console.WriteLine("\nResultado del partido:");
        if (equipo1.TotalRendimiento > equipo2.TotalRendimiento)
            Console.WriteLine($"{equipo1.Nombre} gana.");
        else if (equipo2.TotalRendimiento > equipo1.TotalRendimiento)
            Console.WriteLine($"{equipo2.Nombre} gana.");
        else
            Console.WriteLine("¡Empate!");

        Console.ReadLine();
    }
}
