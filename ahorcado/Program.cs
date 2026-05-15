using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class Juego
    {
        private string _palabraSecreta;
        private List<char> _letrasUsadas;
        private int _intentosRestantes;
        private PalabrasEnMemoria _repositorio = new PalabrasEnMemoria();

        public Juego()
        {
            _letrasUsadas = new List<char>();
            _intentosRestantes = 6;
        }

        public void Jugar()
        {
            Console.Clear();
            
            // Título del menú en Cian
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== BIENVENIDO AL AHORCADO ===");
            Console.ResetColor();
            
            Console.WriteLine("Selecciona una categoría:");
            Console.WriteLine("1. Arquitectura");
            Console.WriteLine("2. POO");
            Console.WriteLine("3. .NET");
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Opción: ");
            Console.ResetColor();
            
            string opcion = Console.ReadLine();
            string categoriaSeleccionada = opcion switch
            {
                "1" => "Arquitectura",
                "2" => "POO",
                "3" => ".NET",
                _ => "Arquitectura" // Por defecto
            };

            // Asignamos la palabra según la categoría elegida
            _palabraSecreta = _repositorio.ObtenerPalabraAleatoria(categoriaSeleccionada);

            while (_intentosRestantes > 0)
            {
                MostrarTablero(categoriaSeleccionada);

                if (VerificarVictoria())
                {
                    // Mensaje de victoria en Verde
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n¡Ganaste! La palabra era: " + _palabraSecreta);
                    Console.ResetColor();
                    
                    FinalizarJuego();
                    return;
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nIngresa una letra: ");
                Console.ResetColor();
                
                string entrada = Console.ReadLine()?.ToLower();
                if (string.IsNullOrEmpty(entrada)) continue;

                char letra = entrada[0];

                if (_letrasUsadas.Contains(letra))
                {
                    // Advertencia en Amarillo
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n--> Ya usaste esa letra. Enter para seguir...");
                    Console.ResetColor();
                    Console.ReadLine();
                }
                else
                {
                    _letrasUsadas.Add(letra);
                    if (!_palabraSecreta.Contains(letra)) _intentosRestantes--;
                }
            }

            MostrarTablero(categoriaSeleccionada);
            
            // Mensaje de derrota en Rojo
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPerdiste. La palabra era: " + _palabraSecreta);
            Console.ResetColor();
            
            FinalizarJuego();
        }

        private bool VerificarVictoria() => _palabraSecreta.All(c => _letrasUsadas.Contains(c));

        private void MostrarTablero(string cat)
        {
            Console.Clear();
            
            // Título superior en Cian
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"=== AHORCADO | Categoría: {cat} ===");
            Console.ResetColor();
            
            MostrarAhorcado();
            
            // Color dinámico para los intentos restantes
            Console.Write($"Intentos restantes: ");
            if (_intentosRestantes > 3) Console.ForegroundColor = ConsoleColor.Green;
            else if (_intentosRestantes > 1) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(_intentosRestantes);
            Console.ResetColor();

            // Pista automática (Reto anterior) en Amarillo
            if ((6 - _intentosRestantes) >= 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[PISTA]: Inicia con '{_palabraSecreta[0]}'");
                Console.ResetColor();
            }

            // Letras usadas en Magenta oscuro
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Letras usadas: {string.Join(", ", _letrasUsadas)}");
            Console.ResetColor();
            
            Console.Write("Palabra: ");
            foreach (char c in _palabraSecreta)
            {
                if (_letrasUsadas.Contains(c))
                {
                    // Letras correctas adivinadas en Verde
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(c + " ");
                }
                else
                {
                    // Guiones normales
                    Console.ResetColor();
                    Console.Write("_ ");
                }
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        private void FinalizarJuego()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            Console.ResetColor();
            
            if (Console.ReadLine()?.ToLower() == "s") new Juego().Jugar();
        }

        private void MostrarAhorcado()
        {
            string[] etapas = new string[]
            {
                " -----\n |    |\n      |\n      |\n      |\n      |\n=========",
                " -----\n |    |\n O    |\n      |\n      |\n      |\n=========",
                " -----\n |    |\n O    |\n |    |\n      |\n      |\n=========",
                " -----\n |    |\n O    |\n/|    |\n      |\n      |\n=========",
                " -----\n |    |\n O    |\n/|\\   |\n      |\n      |\n=========",
                " -----\n |    |\n O    |\n/|\\   |\n/     |\n      |\n=========",
                " -----\n |    |\n O    |\n/|\\   |\n/ \\   |\n      |\n========="
            };
            
            // Dibujo del ahorcado en color Rojo
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(etapas[6 - _intentosRestantes]);
            Console.ResetColor();
        }
    }
}