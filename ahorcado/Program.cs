using System;
using System.Threading;
using Ahorcado; // Asegura que el namespace se esté importando

while (true)
{
    Console.Clear();
    Console.WriteLine("¿Qué juego quieres jugar?");
    Console.WriteLine("  1 — Ahorcado");
    Console.WriteLine("  2 — Viborita");
    Console.WriteLine("  3 — Salir");
    Console.Write("Opción: ");
    var opcion = Console.ReadLine();

    if (opcion == "1")
    {
        // --- LÓGICA DEL AHORCADO ---
        // ¡Tu nueva clase Juego ya hace todo! Solo instánciala y ejecútala:
        var juegoAhorcado = new Juego();
        juegoAhorcado.Jugar();
    }
    else if (opcion == "2")
    {
        // --- LÓGICA DE LA VIBORITA ---
        // Se asume que aún conservas las clases MotorViborita y ConsolaUIViborita
        var motor = new MotorViborita();
        var ui = new ConsolaUIViborita(motor);

        Console.Clear();
        Console.CursorVisible = false;

        while (!motor.Ganado() && !motor.Perdido())
        {
            ui.MostrarTablero();
            var tecla = ui.LeerTecla();

            if (tecla == ConsoleKey.Q) break;

            if (tecla != ConsoleKey.NoName)
                motor.CambiarDireccion(tecla);

            motor.Avanzar();
            Thread.Sleep(150); // velocidad del juego
        }

        ui.MostrarTablero();
        ui.MostrarMensaje(motor.Ganado()
            ? "\n¡Ganaste! Llegaste a 10 puntos."
            : "\nGame over.");

        Console.CursorVisible = true;
        Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
        Console.ReadKey(true);
    }
    else if (opcion == "3")
    {
        Console.WriteLine("¡Gracias por jugar!");
        break; // Rompe el bucle y cierra la consola
    }
    else
    {
        Console.WriteLine("Opción no válida. Presiona cualquier tecla para continuar...");
        Console.ReadKey(true);
    }
}