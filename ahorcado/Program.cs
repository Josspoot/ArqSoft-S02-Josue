namespace Ahorcado
{
    public class Juego
    {
        private List<string> _palabras = new()
        {
            "arquitectura",
            "encapsulamiento",
            "interfaz",
            "herencia",
            "polimorfismo"
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
                    Console.WriteLine($"\n¡Ganaste! La palabra era: {_palabraSecreta}");
                    Reiniciar();
                    return;
                }

                Console.Write("\nIngresa una letra: ");
                string entrada = Console.ReadLine()?.ToLower() ?? "";
                
                if (string.IsNullOrEmpty(entrada)) continue;

                char letra = entrada[0];

                if (_letrasUsadas.Contains(letra))
                {
                    Console.WriteLine("Ya usaste esa letra.");
                    Thread.Sleep(1000); // Pausa breve para leer el mensaje
                    continue;
                }

                _letrasUsadas.Add(letra);

                if (!_palabraSecreta.Contains(letra))
                    _intentosRestantes--;
            }

            MostrarTablero();
            Console.WriteLine($"\nPerdiste. La palabra era: {_palabraSecreta}");
            Reiniciar();
        }

        private bool VerificarVictoria()
        {
            foreach (char c in _palabraSecreta)
            {
                if (!_letrasUsadas.Contains(c)) return false;
            }
            return true;
        }

        private void Reiniciar()
        {
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            if (Console.ReadLine()?.ToLower() == "s")
            {
                new Juego().Jugar();
            }
        }

        private void MostrarTablero()
        {
            Console.Clear();
            Console.WriteLine("=== AHORCADO ===");
            MostrarAhorcado();
            Console.WriteLine($"\nIntentos restantes: {_intentosRestantes}");
            Console.WriteLine($"Letras usadas: {string.Join(", ", _letrasUsadas)}");
            Console.Write("Palabra: ");
            
            foreach (char c in _palabraSecreta)
            {
                Console.Write(_letrasUsadas.Contains(c) ? $"{c} " : "_ ");
            }
            Console.WriteLine();
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

            Console.WriteLine(etapas[6 - _intentosRestantes]);
        }
    }

    // Para ejecutarlo en Program.cs:
    // class Program { static void Main() { new Juego().Jugar(); } }
}
