using Newtonsoft.Json;
using System;

public class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
}

class Program
{
    static void Main()
    {
        // Crear un objeto
        Persona persona = new Persona { Nombre = "Juan", Edad = 30 };

        // Serializar el objeto a JSON
        string json = JsonConvert.SerializeObject(persona);
        Console.WriteLine("JSON: " + json);

        // Deserializar el JSON a un objeto
        Persona personaDeserializada = JsonConvert.DeserializeObject<Persona>(json);
        Console.WriteLine("Nombre: " + personaDeserializada.Nombre);
        Console.WriteLine("Edad: " + personaDeserializada.Edad);
    }
}
