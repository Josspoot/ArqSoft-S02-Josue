namespace Ahorcado
{
    public class MotorAhorcado
    {
        private readonly string _palabraSecreta;
        private readonly List<char> _letrasUsadas = new();
        private int _intentosRestantes = 6;

        public string PalabraSecreta => _palabraSecreta;
        public List<char> LetrasUsadas => _letrasUsadas;
        public int IntentosRestantes => _intentosRestantes;

        // Lógica de pista: se activa al llegar a 3 intentos o menos
        public bool DebeMostrarPista => _intentosRestantes == 3;

        public MotorAhorcado(IRepositorioPalabras repositorio)
        {
            _palabraSecreta = repositorio.ObtenerPalabraAleatoria().ToLower();
        }

        public char ObtenerPista() => _palabraSecreta[0];

        public bool LetraYaUsada(char letra) => _letrasUsadas.Contains(char.ToLower(letra));

        public void RegistrarLetra(char letra)
        {
            letra = char.ToLower(letra);
            if (!LetraYaUsada(letra))
            {
                _letrasUsadas.Add(letra);
                if (!_palabraSecreta.Contains(letra)) _intentosRestantes--;
            }
        }

        public bool Ganado() => _palabraSecreta.All(c => _letrasUsadas.Contains(c));
        public bool Perdido() => _intentosRestantes <= 0;
    }
}