using UnityEngine;

public class CinematicasSinCorrutinas : MonoBehaviour
{
    // Definimos los estados lógicos de la cinemática
    private enum EstadoCinematica { Inicio, EsperandoCamara, EsperandoTutorial, Finalizado }
    private EstadoCinematica _estadoActual = EstadoCinematica.Inicio;

    private float _cronometro = 0f;

    private void Start()
    {
        // Esto equivale al inicio de tu corrutina principal
        Debug.Log("Iniciando cinemática...");
        _estadoActual = EstadoCinematica.EsperandoCamara;
    }

    private void Update()
    {
        switch (_estadoActual)
        {
            case EstadoCinematica.EsperandoCamara:
                // Simulamos el paso del tiempo de SecuenciaCamara (3 segundos)
                _cronometro += Time.deltaTime;
                if (_cronometro >= 3f)
                {
                    SecuenciaCamaraFinalizada();
                }
                break;

            case EstadoCinematica.EsperandoTutorial:
                // Simulamos el paso del tiempo de ExtenderTutorial (2 segundos)
                _cronometro += Time.deltaTime;
                if (_cronometro >= 2f)
                {
                    ExtenderTutorialFinalizado();
                }
                break;

            case EstadoCinematica.Finalizado:
                // Ya no hacemos nada, la secuencia terminó
                break;
        }
    }

    // Funciones puras normales que actúan como "callbacks" al terminar los tiempos
    private void SecuenciaCamaraFinalizada()
    {
        Debug.Log("[Camara] Movimiento finalizado.");
        Debug.Log("La cámara terminó de moverse. Ahora mostramos el cartel de inicio.");
        
        // Reiniciamos el reloj y cambiamos al siguiente paso secuencial
        _cronometro = 0f;
        _estadoActual = EstadoCinematica.EsperandoTutorial;
    }

    private void ExtenderTutorialFinalizado()
    {
        Debug.Log("[UI] Cartel ocultado.");
        Debug.Log("¡El jugador ya tiene el control del juego!");
        
        _estadoActual = EstadoCinematica.Finalizado;
    }
}
