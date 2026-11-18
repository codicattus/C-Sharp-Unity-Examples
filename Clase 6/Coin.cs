using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Acceso global directo mediante la propiedad estática Instance
            GameManager.Instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}

