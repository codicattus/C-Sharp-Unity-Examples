using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ControladorClic : MonoBehaviour
{
    public PlayerController player;

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (player != null)
            {
                player.QuitarVida(25);

                // Si la vida llega a 0 o menos, recargamos la escena
                if (player.CurrentHealth <= 0)
                {
                    Debug.Log("<color=yellow><b>[Controlador]</b></color> Vida en 0. Recargando escena para activar el Awake...");
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