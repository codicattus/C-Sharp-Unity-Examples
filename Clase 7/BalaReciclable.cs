using UnityEngine;

public class BalaReciclable : MonoBehaviour
{
    [SerializeField] private float _velocidad = 20f;
    private PoolDeProyectiles _miPiscina;

    // Al nacer, el gestor le pasa una referencia de la piscina a la bala
    public void ConfigurarBala(PoolDeProyectiles pool)
    {
        _miPiscina = pool;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // En lugar de morir, se entrega de vuelta a su piscina
        if (_miPiscina != null)
        {
            _miPiscina.DevolverBala(gameObject);
        }
    }
    
    void Awake()
    {
        // Esto hace que el objeto "sobreviva" al cambiar de escena
        DontDestroyOnLoad(gameObject);
    }
}



