using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Arrastra aquí el archivo ScriptableObject desde el Inspector
    [SerializeField] private DataPlayer dataPlayer;

    private Rigidbody2D _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();


        // Inicializamos los datos del archivo en el Awake de la escena
        if (dataPlayer != null)
        {

            Debug.Log($"[Awake] Variables inicializadas en el ScriptableObject desde {gameObject.name}.");
            Debug.Log($"[Awake] valor de dataPlayer.currentHealth: {dataPlayer.currentHealth}.");
            Debug.Log($"[Awake] Valor de datos.dataPlayer.isGroundedo: {dataPlayer.isGrounded}.");
        }
    }

    public void QuitarVida(int cantidad)
    {
        if (dataPlayer != null)
        {
            dataPlayer.currentHealth -= cantidad;
            Debug.Log($"[Daño] Vida actual en el ScriptableObject: {dataPlayer.currentHealth}");
        }
    }

    // Propiedad para que el controlador de clics pueda leer la vida
    public int CurrentHealth => dataPlayer != null ? dataPlayer.currentHealth : 0;
}
