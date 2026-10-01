using UnityEngine;
using System; // Obligatorio para usar Action

public class PlayerHealth : MonoBehaviour
{
    // Evento estático: Cualquier UI o sistema puede escuchar cuándo aparece el jugador
    public static event Action OnPlayerSpawned;

    private int _currentHealth = 50; 
    private void Awake()
    {
        // Aquí solo configuramos componentes locales fijos
        Debug.Log($"<color=green><b>[Awake]</b></color> {gameObject.name} preparado.");
    }

    private void OnEnable()
    {
        // 1. Notificar a otros sistemas que este objeto ya está activo
        OnPlayerSpawned?.Invoke();
        Debug.Log($"<color=yellow><b>[OnEnable]</b></color>  {gameObject.name} ha avisado de su aparición.");

        // 2. Suscribirse a un evento global (El GameManager avisa que empezó la partida)
        GameManager.OnGameStart += ResetHealth;
    }

    private void OnDisable()
    {
        // ¡Obligatorio! Limpiar la suscripción para evitar errores de memoria
        GameManager.OnGameStart -= ResetHealth;
        Debug.Log($"<color=magenta><b>[OnDisable]</b></color> {gameObject.name} deshabilitado. Suscripción liberada.");
    }

    private void ResetHealth()
    {
        // Lógica para restablecer la vida del jugador
        _currentHealth = 100;
        Debug.Log($"<color=green>[ResetHealth]</color> ¡Evento recibido! Vida de {gameObject.name} restaurada a {_currentHealth}.");
    }

    public void QuitarVida(int cantidad)
    {
        _currentHealth -= cantidad;
        Debug.Log($"<color=red><b>[Daño]</b></color> Vida actual: {_currentHealth}");
    }
}