using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] private DataPlayer dataPlayer;

    // Las variables estáticas sobreviven a las recargas de escena
    private static bool _isPlayInit = false;

    private void Start()
    {
        // Esto solo se ejecutará cuando entres al juego de verdad,
        // no cuando recargues la escena desde el ControladorClic.

        if (dataPlayer != null)
        {
            if (!_isPlayInit)
            {
                dataPlayer.currentHealth = 100;
                dataPlayer.isGrounded = true;
                _isPlayInit = true;
                Debug.Log("<color=green><b>[Partida]</b></color> Vida inicializada a 100 al arrancar el juego.");
            }
            else
            {
                // Si ya se había iniciado, ignoramos el código para no machacar la vida
                Debug.Log("<color=orange><b>[Partida]</b></color> Escena recargada. Conservando vida actual: " + dataPlayer.currentHealth);
            }
        }
    }
}

