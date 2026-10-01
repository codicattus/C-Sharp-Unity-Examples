using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;

    private int _currentHealth;
    private bool _isGrounded;

    // Se ejecuta una sola vez al nacer el objeto, incluso si el script está desactivado
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        _currentHealth = 100;
        _isGrounded = true;

        Debug.Log($"[Awake] Componentes y variables internas inicializados en {gameObject.name}.");
        Debug.Log($"[Awake] valor de _currentHealth {_currentHealth}.");
        Debug.Log($"[Awake] Valor de _isGrounded {_isGrounded}.");
        DontDestroyOnLoad(gameObject); // Evita que Unity lo destruya al cambiar de escena
    }

    public void QuitarVida(int cantidad)
    {
        _currentHealth -= cantidad;
        Debug.Log($"[Daño] A {gameObject.name} le quitaron {cantidad} de vida. Vida restante: {_currentHealth}");
    }

    // Permite que otros scripts lean cuánta vida le queda actualmente
    public int CurrentHealth => _currentHealth;
}