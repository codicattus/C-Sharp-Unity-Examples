using UnityEngine;

// Esto te permite crear el archivo haciendo clic derecho en la carpeta Assets
[CreateAssetMenu(fileName = "DataPlayer", menuName = "Scriptable Objects/DataPlayer")]
public class DataPlayer : ScriptableObject
{
    public int currentHealth;
    public bool isGrounded;
}

// En el editor de Unity, los ScriptableObjects guardan los cambios permanentemente, 
// incluso si sales del modo Play. Si le quitas vida jugando y detienes el juego, la vida se quedará baja. 
// Si quieres que siempre empiece en 100 al pulsar Play, tienes que inicializarlo mediante código.