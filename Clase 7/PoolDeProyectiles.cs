using UnityEngine;
using UnityEngine.Pool; // OBLIGATORIO: De aquí sale la magia del reciclaje

public class PoolDeProyectiles : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBala;
    [SerializeField] private int _capacidadPorDefecto = 20;
    [SerializeField] private int _capacidadMaxima = 50;

    // El objeto piscina nativo de Unity
    private ObjectPool<GameObject> _piscina;

    private void Awake()
    {
        // Configuramos la piscina pasándole 4 funciones que C# necesita saber cómo hacer:
        _piscina = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(_prefabBala),            // 1. Cómo fabricar uno si la piscina se queda vacía
            actionOnGet: (bala) => bala.SetActive(true),           // 2. Qué hacer cuando saquemos una bala (Encenderla)
            actionOnRelease: (bala) => bala.SetActive(false),      // 3. Qué hacer cuando devolvamos una bala (Apagarla)
            actionOnDestroy: (bala) => Destroy(bala),              // 4. Qué hacer si superamos el límite máximo de la piscina
            collectionCheck: false,                                // Control de seguridad (false ahorra rendimiento)
            defaultCapacity: _capacidadPorDefecto,
            maxSize: _capacidadMaxima
        );
    }

    // El método que llamará el arma del jugador en lugar de Instantiate
    public GameObject ObtenerBala(Vector3 posicion, Quaternion rotacion)
    {
        // Sacamos una bala lavada y lista de la piscina
        GameObject bala = _piscina.Get();
        
        // La teletransportamos a donde se necesita
        bala.transform.position = posicion;
        bala.transform.rotation = rotacion;

        return bala;
    }

    // El método que llamará la bala cuando choque, en lugar de Destroy
    public void DevolverBala(GameObject bala)
    {
        // La devolvemos a la pila de platos limpios
        _piscina.Release(bala);
    }
}
