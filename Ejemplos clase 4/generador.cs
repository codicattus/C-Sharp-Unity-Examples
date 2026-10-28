using System.Collections;
using UnityEngine;

public class Generador : MonoBehaviour
{
    void Start()
    {
        // Spawneamos un enemigo normal en el centro
        GameObject enemigo = SpawnearEnemigoSimple("CuboFlotante");

        // Iniciamos la corrutina para que empiece a subir suavemente
        StartCoroutine(SubirSuavemente(enemigo));
    }

    // 🌟 CORREGIDO: 'objetoAMover' ahora está todo junto
    IEnumerator SubirSuavemente(GameObject objetoAMover)
    {
        float alturaObjetivo = 5f;

        // Mientras el cubo no haya llegado a la altura de 5...
        while (objetoAMover.transform.position.y < alturaObjetivo)
        {
            // Movemos el cubo un poquito hacia arriba en este frame
            objetoAMover.transform.Translate(Vector3.up * Time.deltaTime * 2f);

            // Pausamos aquí hasta el siguiente frame para que el movimiento sea fluido
            yield return null; 
        }

        Debug.Log("¡El cubo ha terminado de subir!");
    }

    // Tu método simplificado para crear el cubo de la demo
    private GameObject SpawnearEnemigoSimple(string nombre)
    {
        GameObject clon = GameObject.CreatePrimitive(PrimitiveType.Cube);
        clon.transform.position = transform.position;
        clon.name = nombre;
        return clon;
    }
}