using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configuración de Prueba")]
    public bool modeTest;

    [Header("Estadísticas")]
    public int playerHealth;

    private Rigidbody2D _rb;

    // 1. MOMENTO AWAKE: Registro de componentes internos del propio objeto
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        Debug.Log($"[Awake] Juego iniciado. La salud configurada desde el editor es: {playerHealth}");
    }

    // 2. MOMENTO START: Interacciones que dependen de otros objetos de la escena
    private void Start()
    {
        // Buscamos el punto de aparición externo mediante su Tag
        GameObject pointSpawn = GameObject.FindWithTag("SpawnPoint");

        if (pointSpawn != null)
        {
            // Teletransportamos la cápsula a la posición del punto vacío
            this.transform.position = pointSpawn.transform.position;
            Debug.Log($"[Start] Jugador teletransportado con éxito a: {pointSpawn.name}");
        }
        else
        {
            Debug.LogWarning("[Start] No se encontró ningún objeto con el Tag 'SpawnPoint'. El jugador se queda en su posición inicial.");
        }
    }

    // 3. EDITOR: Configuración automatizada al añadir el script o pulsar 'Reset'
    private void Reset()
    {
        // A. Asegurar o añadir automáticamente un Collider 2D
        if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<CapsuleCollider2D>();
            Debug.Log($"<b>[Reset]</b> Se ha añadido automáticamente un CapsuleCollider2D a {gameObject.name}.");
        }

        // B. Comprobar si ya existe una cámara asignada a este jugador
        Camera cameraExist = GetComponentInChildren<Camera>();
        if (cameraExist == null)
        {
            GameObject objectCamera = new GameObject("Camara_Jugador");
            objectCamera.transform.SetParent(this.transform);

            Camera newCamera = objectCamera.AddComponent<Camera>();
            
            // Configuración óptima para cámaras en juegos 2D
            newCamera.orthographic = true; 
            objectCamera.transform.localPosition = new Vector3(0f, 0f, -10f); // Retrasada en Z para que vea el plano 2D

            Debug.Log("<b>[Reset]</b> Se ha creado y posicionado una Cámara 2D como hija del jugador.");
        }

        // C. Buscamos el objeto de configuración de pruebas en la escena
        TestDebug setupGlobal = Object.FindFirstObjectByType<TestDebug>();    

        if (setupGlobal != null)
        {
            modeTest = setupGlobal.forzarModoTest;
            playerHealth = modeTest ? 1000 : 100;

            Debug.Log($"<b>[Reset]</b> Datos leídos de '{setupGlobal.gameObject.name}'. Salud establecida en: {playerHealth}");
        }
        else
        {
            modeTest = false;
            playerHealth = 100;
            Debug.LogWarning("<b>[Reset]</b> No se encontró 'TestDebug' en la escena. Usando valores por defecto (Salud: 100).");
        }
    }    
}
