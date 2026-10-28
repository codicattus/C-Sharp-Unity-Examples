using System.Collections;
using UnityEngine;

public class DemostracionTiempos : MonoBehaviour
{
    // Creamos pausas con tiempos notablemente diferentes
    private WaitForSeconds _pausaLargaA = new WaitForSeconds(3.0f);  // 3 segundos
    private WaitForSeconds _pausaCortaB = new WaitForSeconds(0.5f);  // 0.5 segundos

    private void Start()
    {
        Debug.Log("🚀 Arrancando el motor del juego...");
        
        // Iniciamos A primero en el código
        StartCoroutine(ProcesoLargoA());
        
        // Iniciamos B segundo en el código
        StartCoroutine(ProcesoCortoB());
    }

    private IEnumerator ProcesoLargoA()
    {
        Debug.Log("🟢 [0.0s] Proceso A INICIA y pide una pausa de 3 segundos.");
        
        yield return _pausaLargaA; // Se duerme por 3 segundos
        
        Debug.Log("🟢 [3.0s] Proceso A TERMINA (Regresó de su pausa larga).");
    }

    private IEnumerator ProcesoCortoB()
    {
        Debug.Log("🔵 [0.0s] Proceso B INICIA y pide una pausa de 0.5 segundos.");
        
        yield return _pausaCortaB; // Se duerme por solo 0.5 segundos
        
        Debug.Log("🔵 [0.5s] Proceso B TERMINA (Regresó antes porque su pausa era menor).");
    }
}