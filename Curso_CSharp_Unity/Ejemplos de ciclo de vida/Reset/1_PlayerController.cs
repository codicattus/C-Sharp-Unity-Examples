using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuración de Prueba")]
    public bool modeTest;

    [Header("Estadísticas")]
    public int playerHealth;

    private Rigidbody2D _rb;




    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        Debug.Log($"[Awake] Juego iniciado. La salud configurada desde el editor es: {playerHealth}");
    }

    // Se ejecuta al añadir el script por primera vez o al pulsar 'Reset' en el Inspector
    private void Reset()
    {
        // 1. Asegurar o añadir automáticamente un Collider (usaremos un CapsuleCollider2D para el jugador)
        if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<CapsuleCollider2D>();
            Debug.Log($"<b>[Reset]</b> Se ha añadido automáticamente un CapsuleCollider2D a {gameObject.name}.");
        }

        // 2. Comprobar si ya existe una cámara de tercera persona asignada a este jugador
        Camera cameraExist = GetComponentInChildren<Camera>();
        if (cameraExist == null)
        {
            // Creamos un nuevo GameObject hijo para la cámara
            GameObject objectCamera = new GameObject("Camara_TerceraPersona");
            objectCamera.transform.SetParent(this.transform);

            // Le añadimos el componente Camera
            Camera newCamera = objectCamera.AddComponent<Camera>();
            
            // Configuraciones de cámara para 2D/3D según tu entorno
            newCamera.orthographic = false; // Perspectiva para tercera persona

            // POSICIONAMIENTO: Un poco elevada (Y = 3), por detrás (Z = -5) y mirando ligeramente hacia abajo
            objectCamera.transform.localPosition = new Vector3(0f, 3f, -5f);
            objectCamera.transform.localRotation = Quaternion.Euler(20f, 0f, 0f);

            Debug.Log("<b>[Reset]</b> Se ha creado y posicionado una Cámara de Tercera Persona por detrás y elevada.");
        }

        // 3. Buscamos el objeto de configuración en la escena
        // Usamos FindFirstObjectByType por compatibilidad con versiones modernas de Unity
        TestDebug setupGlobal = Object.FindFirstObjectByType<TestDebug>();    

        if (setupGlobal != null)
        {
            // Sincronizamos la casilla local con la casilla del objeto vacío de la escena
            modeTest = setupGlobal.forzarModoTest;

            if (modeTest)
            {
                playerHealth = 1000;
            }
            else
            {
                playerHealth = 100;
            }

            Debug.Log($"<b>[Reset]</b> Datos leídos con éxito de '{setupGlobal.gameObject.name}'. Salud: {playerHealth}");
        }
        else
        {
            // Si olvidaste crear el objeto AjustesDebug en la escena, usa valores por defecto básicos
            modeTest = false;
            playerHealth = 100;
            Debug.LogWarning("<b>[Reset]</b> No se encontró ningún objeto con 'AjustesDebug' en la escena. Usando valores por defecto.");
        }

    }    
}

