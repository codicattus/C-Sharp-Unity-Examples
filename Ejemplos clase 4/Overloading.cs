using UnityEngine;

public class Overloading : MonoBehaviour
{
    private float _currentLives = 100f;
    void Start()
    {
        TakeDamage(20);
        TakeDamage(10, Vector3.right, 2);
        TakeDamage("bullet", 10);
        
    }

    void TakeDamage(float damage)
    {
        _currentLives -= damage;
        Debug.Log($"Daño recibido: {damage}. Vida restante: {_currentLives}");
    }
    
    void TakeDamage(float damage, Vector3 directionThrust, float force )
    {
        _currentLives -= damage * force;
        Debug.Log($"Daño recibido: {damage}. Fuerza empleada: {force}. Dirección de ataque: {directionThrust}. Vida restante: {_currentLives}");
    }
    
    void TakeDamage(string weapon, float damage)
    {
        float force;
        switch (weapon)
        {
            case "fist" : force = 1f; break;
            case "daga" : force = 1.5f; break;
            case "katana" : force = 2f; break;
            case "bullet" : force = 3.5f; break;
            case "grenade" : force = 5f; break;
            default : force = 1f; break;
        }
        _currentLives -= damage * force;
        Debug.Log($"Daño recibido: {damage}. Arma empleada: {weapon}. Fuerza empleada: {force}. Vida restante: {_currentLives}");
    }
}
