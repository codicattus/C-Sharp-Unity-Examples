using System.Collections;
using UnityEngine;

// 1. Tu clase normal de Unity (puedes borrar la clase estática de aquí dentro)
public class ExtensionMethods : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f); 
        transform.Resetear(); 
    }
}

// 2. LA CLASE ESTÁTICA TIENE QUE ESTAR AQUÍ AFUERA (No anidada)
public static class MisExtensiones
{
    // Método estático con 'this'
    public static void Resetear(this Transform transformObjetivo)
    {
        transformObjetivo.position = Vector3.zero;
        transformObjetivo.rotation = Quaternion.identity;
    }
}