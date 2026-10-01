using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Instancia estática pública para que el controlador lo encuentre siempre
    public static PlayerController Instance { get; private set; }

    private Rigidbody2D _rb;


    private int _currentHealth;
    private bool _isGrounded;

    private void Awake()
    {
        // COMPROBACIÓN SINGLETON: Evita duplicados al cambiar o recargar escena
        if (Instance != null && Instance != this)
        {
            Debug.Log($"[Awake] Ya existe un jugador sobreviviente. Destruyendo el duplicado de {gameObject.name}.");
            Destroy(gameObject);
            return; // Detiene la ejecución para que no inicialice nada más
        }

        // Si es el primer jugador, se convierte en la instancia oficial
        Instance = this;
        DontDestroyOnLoad(gameObject); // Evita que Unity lo destruya al cambiar de escena

        // Inicialización normal
        _rb = GetComponent<Rigidbody2D>();

        _currentHealth = 100;
        _isGrounded = true;

        Debug.Log($"[Awake] ¡Primer jugador creado con éxito! Variables inicializadas en {gameObject.name}.");
        Debug.Log($"[Awake] valor de _currentHealth {_currentHealth}.");
    }

    // Método público para restar vida
    public void QuitarVida(int cantidad)
    {
        _currentHealth -= cantidad;
        Debug.Log($"[Daño] A {gameObject.name} le quitaron {cantidad} de vida. Vida restante: {_currentHealth}");
    }

    // Propiedad pública para leer la vida desde el controlador
    public int CurrentHealth => _currentHealth;
}

