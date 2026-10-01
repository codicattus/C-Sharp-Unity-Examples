using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; 

public class ControladorClic : MonoBehaviour
{
    // Arrastra tu cápsula aquí en el Inspector
    public PlayerController player;

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (player != null)
            {
                player.QuitarVida(25);

                if (player.CurrentHealth <= 0)
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
