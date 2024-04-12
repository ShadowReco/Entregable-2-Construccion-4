using System;

class Pokemon
{    
    public string Nombre { get; set; }
    public string Tipo { get; set; }
    public int Salud { get; set; }
    public int[] Ataques { get; set; } = new int[3];
    public int[] Defensas { get; set; } = new int[2];

    public int Atacar()
    {
        Random random = new Random();
        int ataqueSeleccionado = random.Next(0, 3);
        double multiplicador = random.NextDouble() switch
        {
            var x when x < 0.3 => 1.0,
            var x when x < 0.6 => 0.5,
            _ => 1.5
        };

        return (int)(Ataques[ataqueSeleccionado] * multiplicador);
    }

    public int Defender()
    {
        Random random = new Random();
        int defensaSeleccionada = random.Next(0, 2);
        double multiplicador = random.NextDouble() switch
        {
            var x when x < 0.5 => 1.0,
            _ => 0.5
        };

        return (int)(Defensas[defensaSeleccionada] * multiplicador);
    }
}

class Program
{
    static void Main()
    {
        // Crear a Giratina
        Pokemon giratina = new Pokemon
        {
            Nombre = "Giratina",
            Tipo = "Fantasma/Dragón",
            Salud = 100,
            Ataques = new int[] { 40, 35, 30 },
            Defensas = new int[] { 25, 30 }
        };

        // Crear a Rayquaza
        Pokemon rayquaza = new Pokemon
        {
            Nombre = "Rayquaza",
            Tipo = "Dragón/Volador",
            Salud = 100,
            Ataques = new int[] { 38, 32, 37 },
            Defensas = new int[] { 28, 22 }
        };

        // Simular los putazos durante 3 turnos
        for (int turno = 1; turno <= 3; turno++)
        {
            int ataqueGiratina = giratina.Atacar();
            int defensaRayquaza = rayquaza.Defender();
            int danoGiratina = Math.Max(0, ataqueGiratina - defensaRayquaza);
            rayquaza.Salud -= danoGiratina;

            int ataqueRayquaza = rayquaza.Atacar();
            int defensaGiratina = giratina.Defender();
            int danoRayquaza = Math.Max(0, ataqueRayquaza - defensaGiratina);
            giratina.Salud -= danoRayquaza;

            Console.WriteLine($"Turno {turno}:");
            Console.WriteLine($"{giratina.Nombre} ataca a {rayquaza.Nombre} y le hace {danoGiratina} puntos de daño.");
            Console.WriteLine($"{rayquaza.Nombre} ataca a {giratina.Nombre} y le hace {danoRayquaza} puntos de daño.");
        }

        // Determinar el ganador o si hay empate
        if (giratina.Salud > rayquaza.Salud)
        {
            Console.WriteLine($"{giratina.Nombre} gana.");
            Console.WriteLine($"{giratina.Nombre} GOD.");
        }            
        else if (rayquaza.Salud > giratina.Salud)
            Console.WriteLine($"{rayquaza.Nombre} gana.");
        else
            Console.WriteLine("¡Empate!");

        Console.ReadLine();
    }
}