namespace Ahorcado;

public class PalabrasEnMemoria
{
    // Diccionario organizado por las categorías solicitadas
    private readonly Dictionary<string, List<string>> _categorias = new()
    {
        { "Arquitectura", new List<string> { "arquitectura", "componente", "descomposicion", "dependencia", "acoplamiento" } },
        { "POO", new List<string> { "polimorfismo", "encapsulamiento", "herencia", "abstraccion", "clase" } },
        { ".NET", new List<string> { "ensamblado", "namespace", "interfaz", "delegado", "middleware" } }
    };

    public string ObtenerPalabraAleatoria(string categoria)
    {
        if (!_categorias.ContainsKey(categoria)) return "error";
        
        var lista = _categorias[categoria];
        var random = new Random();
        return lista[random.Next(lista.Count)];
    }
}