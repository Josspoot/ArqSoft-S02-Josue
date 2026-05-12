namespace Ahorcado;

public class PalabrasEnMemoria
{
    private readonly List<string> _palabras = new()
    {
        "arquitectura", "interfaz", "polimorfismo", "encapsulamiento", "herencia"
    };

    public string getPalabras()
    {
        var random = new Random();
        return _palabras.ElementAt(random.Next(_palabras.Count));
    }
}