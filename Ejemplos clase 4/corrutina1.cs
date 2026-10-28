using UnityEngine;
using System.Collections;
using Unity.VisualScripting.FullSerializer;

public class Corrutina1 : MonoBehaviour
{
    void Start()
    {
        //StartCoroutine(Contador());
        StartCoroutine("Contador");
    }

    private IEnumerator Contador()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Preparados");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Listos");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("YA!");
        yield return new WaitForSeconds(0.5f);
        
    }
}
