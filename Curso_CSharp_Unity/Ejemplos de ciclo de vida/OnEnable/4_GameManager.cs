using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // Evento global al que se suscribirá el jugador
    public static event Action OnGameStart;

    // Método público para disparar el evento (lo llamaremos desde el ratón)
    public void IniciarPartida()
    {
        Debug.Log("<color=brown><b>[GameManager]</b></color> Disparando evento OnGameStart...");
        OnGameStart?.Invoke(); // Lanza el evento a todos los suscritos
    }
}