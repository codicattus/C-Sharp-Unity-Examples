using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; 

public class ControladorClic_copy : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Buscamos directamente a la instancia viva del jugador
            PlayerController jugadorActual = PlayerController.Instance;

            if (jugadorActual != null)
            {
                jugadorActual.QuitarVida(25);

                if (jugadorActual.CurrentHealth <= 25)
                {
                    Debug.Log("<color=yellow><b>[Controlador]</b></color> Vida en 0 o menos. Recargando escena...");
                    RecargarEscenaActual();
                }
            }
        }
    }

    void RecargarEscenaActual()
    {
        string nombreEscena = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nombreEscena);
    }
}