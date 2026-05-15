using System;
using System.Linq;

namespace Ahorcado
{
    public class ConsolaUIViborita
    {
        private readonly MotorViborita _motor;
 
        public ConsolaUIViborita(MotorViborita motor)
        {
            _motor = motor;
        }
 
        public void MostrarTablero()
        {
            Console.SetCursorPosition(0, 0);
            
            // Título y puntuación en Amarillo
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"=== VIBORITA === Puntos: {_motor.Puntos}");
            Console.ResetColor();

            // Borde superior en Azul
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("+" + new string('-', _motor.Ancho) + "+");
            Console.ResetColor();
 
            for (int y = 0; y < _motor.Alto; y++)
            {
                // Borde izquierdo en Azul
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("|");
                Console.ResetColor();
                
                for (int x = 0; x < _motor.Ancho; x++)
                {
                    var pos = (x, y);
 
                    // Lógica de dibujo con colores
                    if (_motor.Cuerpo.First() == pos)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("@"); // cabeza
                        Console.ResetColor();
                    }
                    else if (_motor.Cuerpo.Contains(pos))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("o"); // cuerpo
                        Console.ResetColor();
                    }
                    else if (_motor.Comida == pos)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("*"); // comida
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" "); // vacío
                    }
                }
                
                // Borde derecho en Azul
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("|");
                Console.ResetColor();
            }
 
            // Borde inferior en Azul
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("+" + new string('-', _motor.Ancho) + "+");
            Console.ResetColor();
            
            // Instrucciones en Cian
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Flechas: mover | Q: salir");
            Console.ResetColor();
        }
 
        public ConsoleKey LeerTecla()
        {
            if (Console.KeyAvailable)
                return Console.ReadKey(intercept: true).Key;
 
            return ConsoleKey.NoName;
        }
 
        public void MostrarMensaje(string mensaje)
        {
            // Colorear el mensaje final de rojo si es "fin del juego"
            if (mensaje.ToLower().Contains("fin") || mensaje.ToLower().Contains("perdiste"))
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
    }
}
