using System.Threading.Tasks;
using UnityEngine;

public class CinematicasAsync : MonoBehaviour
{
    // Las funciones normales 'async void' pueden lanzarse y olvidarse
    private async void Start()
    {
        await RutinaIntroduccion();
    }

    // Equivale a tu IEnumerator principal, pero sin yield
    private async Task RutinaIntroduccion()
    {
        Debug.Log("Iniciando cinemática...");

        // ENCADENAMIENTO: Esperamos de forma síncrona a que termine la tarea de la cámara
        await SecuenciaCamara();

        Debug.Log("La cámara terminó de moverse. Ahora mostramos el cartel de inicio.");
        
        // Esperamos a que termine el tutorial
        await ExtenderTutorial();

        Debug.Log("¡El jugador ya tiene el control del juego!");
    }

    private async Task SecuenciaCamara()
    {
        // 3000 milisegundos = 3 segundos
        await Task.Delay(3000);
        Debug.Log("[Camara] Movimiento finalizado.");
    }

    private async Task ExtenderTutorial()
    {
        // 2000 milisegundos = 2 segundos
        await Task.Delay(2000);
        Debug.Log("[UI] Cartel ocultado.");
    }
}