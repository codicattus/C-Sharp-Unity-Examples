using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorPruebas : MonoBehaviour
{
    public PlayerHealth player;
    public GameManager gameManager;

    void Update()
    {
        if (Mouse.current == null) return;

        // 1. CLIC IZQUIERDO: Quita vida para comprobar que está baja
        if (Mouse.current.leftButton.wasPressedThisFrame && player != null)
        {
            player.QuitarVida(20);
        }

        // 2. CLIC DERECHO: Apaga y enciende al jugador para ver OnEnable/OnDisable
        if (Mouse.current.rightButton.wasPressedThisFrame && player != null)
        {
            bool estadoActual = player.gameObject.activeSelf;
            player.gameObject.SetActive(!estadoActual);
            Debug.Log($"<color=blue><b>[Controlador]</b></color> Cambiando estado del jugador a: {!estadoActual}");
        }

        // 3. TECLA ESPACIO: Ordena al GameManager iniciar la partida (restablecer vida)
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && gameManager != null)
        {
            gameManager.IniciarPartida();
        }
    }
}