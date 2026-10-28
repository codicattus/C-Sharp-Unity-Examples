using UnityEngine;

public class DemoInModifier : MonoBehaviour
{
    // 1. Definimos el struct (Tipo de valor)
    public struct DatosEnemigo
    {
        public string nombre;
        public Vector3 posicion;
        public int vida;
    }

    void Start()
    {
        // 2. Inicializamos los datos del enemigo
        DatosEnemigo orco = new DatosEnemigo();
        orco.nombre = "Orco Gurka";
        orco.posicion = new Vector3(10f, 0f, 5f);
        orco.vida = 100;


        // 3. Llamamos a la función (No es obligatorio poner 'in' en la llamada)
        ProcesarEnemigo(orco);

        
        // También podrías llamarlo así y funcionaría igual:
        // ProcesarEnemigo(in orco);
    }

    // 4. Función que recibe el struct por referencia de solo lectura usando 'in'
    void ProcesarEnemigo(in DatosEnemigo enemigo)
    {
        // LEER DATOS: Está permitido y es ultra rápido porque no clona el struct en memoria
        Debug.Log($"[ProcesarEnemigo] Leyendo datos de: {enemigo.nombre}");
        Debug.Log($"[ProcesarEnemigo] Posición del enemigo: {enemigo.posicion}");

        // ❌ MODIFICAR DATOS: Si descomentas la línea de abajo, Unity dará un error de compilación
        // enemigo.vida = 50; 
        Debug.Log($"[ProcesarEnemigo] Vida del enemigo: {enemigo.vida}");
        // error CS8332: Cannot assign to a member of variable 'enemigo' because it is a read-only variable
    }
}