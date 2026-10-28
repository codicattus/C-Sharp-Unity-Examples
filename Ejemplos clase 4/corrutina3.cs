using UnityEngine;
using System.Collections;

public class CinematicasJuego : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RutinaIntroduccion());
    }

    private IEnumerator RutinaIntroduccion()
    {
        Debug.Log("Iniciando cinemática...");

        // ENCADENAMIENTO: Lanzamos la secuencia de la cámara y ESPERAMOS a que termine por completo
        yield return StartCoroutine(SecuenciaCamara());

        // Esta línea NO se ejecutará hasta que SecuenciaCamara() haya hecho su último yield return
        Debug.Log("La cámara terminó de moverse. Ahora mostramos el cartel de inicio.");
        
        yield return StartCoroutine(ExtenderTutorial());

        Debug.Log("¡El jugador ya tiene el control del juego!");
    }

    private IEnumerator SecuenciaCamara()
    {
        // Simula el movimiento de la cámara durante 3 segundos
        yield return new WaitForSeconds(3f);
        Debug.Log("[Camara] Movimiento finalizado.");
    }

    private IEnumerator ExtenderTutorial()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("[UI] Cartel ocultado.");
    }
}