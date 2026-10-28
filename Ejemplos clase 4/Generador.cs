using UnityEngine;

public class Generador : MonoBehaviour
{
    void Start()
    {
        // ------------------------------------
        // DEMO DE USO (Diferentes formas de llamar a la función)
        // ------------------------------------

        // Opción A: Solo pasas el obligatorio. (Se crea en la posición del Generador)
        SpawnearEnemigo("Goblin");

        // Opción B: Pasas el obligatorio y la posición. (El color se queda en blanco por defecto)
        SpawnearEnemigo("Orco", new Vector3(3f, 0f, 0f));

        // Opción C: Pasas todos los datos en orden.
        SpawnearEnemigo("Troll", new Vector3(-3f, 0f, 0f), Color.red);

        // Opción D: ¡Argumentos Nombrados! Te saltas la posición y cambias solo el color
        SpawnearEnemigo("Espectro", colorEnemigo: Color.magenta);
    }

    // PARÁMETROS OPCIONALES: 'posicion' y 'colorEnemigo' tienen valores por defecto al final
    public void SpawnearEnemigo(string nombreEnemigo, Vector3 posicion = default, Color colorEnemigo = default)
    {
        // 1. Si la posición es default, usamos la posición de este objeto Generador
        Vector3 puntoSpawn = (posicion == default) ? transform.position : posicion;

        // 2. Si el color es default (negro transparente), lo cambiamos a Blanco para que se vea bien
        Color colorFinal = (colorEnemigo == default) ? Color.white : colorEnemigo;

        // 3. Creamos un Cubo básico de Unity directamente desde código (Sin Prefabs)
        GameObject clon = GameObject.CreatePrimitive(PrimitiveType.Cube);
        clon.transform.position = puntoSpawn;
        clon.name = nombreEnemigo;

        // 4. Le cambiamos el color al cubo para ver el resultado visualmente
        Renderer rendererClon = clon.GetComponent<Renderer>();
        if (rendererClon != null)
        {
            rendererClon.material.color = colorFinal;
        }

        Debug.Log($"Spawned: {nombreEnemigo} en {puntoSpawn} con color {colorFinal}");
    }
}