using System;
using System.Linq;

namespace Ahorcado
{
    public class ConsolaUI
    {
        private readonly MotorAhorcado _motor;

        public ConsolaUI(MotorAhorcado motor)
        {
            _motor = motor;
        }

        public void MostrarTablero()
        {
            Console.Clear();
            
            // Título principal en Cian
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== AHORCADO SOLID ===");
            Console.ResetColor();
            
            MostrarAhorcado();

            // Pista automática según el estado del motor
            if (_motor.DebeMostrarPista)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n[PISTA]: La palabra comienza con: '{_motor.ObtenerPista()}'");
                Console.ResetColor();
            }

            // Color dinámico para los intentos
            Console.Write("\nIntentos restantes: ");
            if (_motor.IntentosRestantes > 3) Console.ForegroundColor = ConsoleColor.Green;
            else if (_motor.IntentosRestantes > 1) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(_motor.IntentosRestantes);
            Console.ResetColor();

            // Color para las letras usadas
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Letras usadas: {string.Join(", ", _motor.LetrasUsadas)}");
            Console.ResetColor();
            
            Console.Write("Palabra: ");
            
            // Letras adivinadas en verde, guiones por defecto
            foreach (char c in _motor.PalabraSecreta)
            {
                if (_motor.LetrasUsadas.Contains(c))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{c} ");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write("_ ");
                }
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        public char PedirLetra()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nIngresa una letra: ");
            Console.ResetColor();
            string entrada = Console.ReadLine() ?? "";
            return entrada.Length > 0 ? entrada[0] : ' ';
        }

        public void MostrarMensaje(string mensaje)
        {
            // Colorear el mensaje final dependiendo si ganó o perdió
            if (mensaje.ToLower().Contains("ganaste") || mensaje.ToLower().Contains("felicidades"))
                Console.ForegroundColor = ConsoleColor.Green;
            else if (mensaje.ToLower().Contains("perdiste") || mensaje.ToLower().Contains("fin"))
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(mensaje);
            Console.ResetColor();
        }

        public bool PreguntarOtraVez()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            Console.ResetColor();
            return Console.ReadLine()?.ToLower() == "s";
        }

        private void MostrarAhorcado()
        {
            string[] etapas = new string[]
            {
                "-----\n |   |\n |\n |\n |\n |\n=========",
                "-----\n |   |\n O   |\n |\n |\n |\n=========",
                "-----\n |   |\n O   |\n |   |\n |\n |\n=========",
                "-----\n |   |\n O   |\n/|   |\n |\n |\n=========",
                "-----\n |   |\n O   |\n/|\\  |\n |\n |\n=========",
                "-----\n |   |\n O   |\n/|\\  |\n/    |\n |\n=========",
                "-----\n |   |\n O   |\n/|\\  |\n/ \\  |\n |\n========="
            };

            int indice = Math.Clamp(6 - _motor.IntentosRestantes, 0, 6);
            
            // El dibujo del ahorcado en color rojo
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(etapas[indice]);
            Console.ResetColor();
        }
    }
}