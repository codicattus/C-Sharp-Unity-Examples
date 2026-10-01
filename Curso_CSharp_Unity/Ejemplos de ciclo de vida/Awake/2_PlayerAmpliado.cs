using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;


    private int _currentHealth;
    private bool _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();


        _currentHealth = 100;
        _isGrounded = true;

        Debug.Log($"[Awake] Componentes y variables internas inicializados en {gameObject.name}.");
        Debug.Log($"[Awake] valor de _currentHealth {_currentHealth}.");
        Debug.Log($"[Awake] Valor de _isGrounded {_isGrounded}.");
    }

    public void QuitarVida(int cantidad)
    {
        _currentHealth -= cantidad;
        Debug.Log($"[Daño] A {gameObject.name} le quitaron {cantidad} de vida. Vida restante: {_currentHealth}");
    }

    // Permite que otros scripts lean cuánta vida le queda actualmente
    public int CurrentHealth => _currentHealth;
}