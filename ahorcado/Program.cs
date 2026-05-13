using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class Juego
    {
        private List<string> _palabras = new()
        {
            "arquitectura", "interfaz", "polimorfismo",
            "encapsulamiento", "herencia"
        };
        private string _palabraSecreta;
        private List<char> _letrasUsadas;
        private int _intentosRestantes;

        public Juego()
        {
            var random = new Random();
            _palabraSecreta = _palabras[random.Next(_palabras.Count)];
            _letrasUsadas = new List<char>();
            _intentosRestantes = 6;
        }

        public void Jugar()
        {
            while (_intentosRestantes > 0)
            {
                MostrarTablero();

                if (VerificarVictoria())
                {
                    Console.WriteLine("\n¡Ganaste! La palabra era: " + _palabraSecreta);
                    FinalizarJuego();
                    return;
                }

                Console.Write("\nIngresa una letra: ");
                string entrada = Console.ReadLine()?.ToLower();

                if (string.IsNullOrEmpty(entrada)) continue;

                char letra = entrada[0];

                if (_letrasUsadas.Contains(letra))
                {
                    Console.WriteLine("\n--> Ya usaste esa letra. Presiona Enter para continuar...");
                    Console.ReadLine();
                }
                else
                {
                    _letrasUsadas.Add(letra);
                    // Si la letra no está en la palabra, restamos un intento
                    if (!_palabraSecreta.Contains(letra))
                    {
                        _intentosRestantes--;
                    }
                }
            }

            // Si sale del bucle es porque perdió
            MostrarTablero();
            Console.WriteLine("\nPerdiste. La palabra era: " + _palabraSecreta);
            FinalizarJuego();
        }

        private bool VerificarVictoria()
        {
            foreach (char c in _palabraSecreta)
                if (!_letrasUsadas.Contains(c)) return false;
            return true;
        }

        private void MostrarTablero()
        {
            Console.Clear();
            Console.WriteLine("=== AHORCADO ===");
            MostrarAhorcado();
            Console.WriteLine($"Intentos restantes: {_intentosRestantes}");

            // --- LÓGICA DEL RETO: Pista automática ---
            int intentosFallidos = 6 - _intentosRestantes;
            if (intentosFallidos >= 3)
            {
                Console.WriteLine("*****************************************");
                Console.WriteLine($"* PISTA: La primera letra es: '{_palabraSecreta[0]}' *");
                Console.WriteLine("*****************************************");
            }
            // -----------------------------------------

            Console.WriteLine($"Letras usadas: {string.Join(", ", _letrasUsadas)}");
            Console.Write("Palabra: ");
            foreach (char c in _palabraSecreta)
            {
                Console.Write(_letrasUsadas.Contains(c) ? c + " " : "_ ");
            }
            Console.WriteLine();
        }

        private void FinalizarJuego()
        {
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            if (Console.ReadLine()?.ToLower() == "s")
            {
                new Juego().Jugar();
            }
        }

        private void MostrarAhorcado()
        {
            string[] etapas = new string[]
            {
                " -----\n |    |\n      |\n      |\n      |\n      |\n=========", // 0 fallos
                " -----\n |    |\n O    |\n      |\n      |\n      |\n=========", // 1 fallo
                " -----\n |    |\n O    |\n |    |\n      |\n      |\n=========", // 2 fallos
                " -----\n |    |\n O    |\n/|    |\n      |\n      |\n=========", // 3 fallos (Pista!)
                " -----\n |    |\n O    |\n/|\\   |\n      |\n      |\n=========", // 4 fallos
                " -----\n |    |\n O    |\n/|\\   |\n/     |\n      |\n=========", // 5 fallos
                " -----\n |    |\n O    |\n/|\\   |\n/ \\   |\n      |\n========="  // 6 fallos
            };

            int indice = 6 - _intentosRestantes;
            Console.WriteLine(etapas[indice]);
        }
    }
}