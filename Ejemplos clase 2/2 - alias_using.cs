using UnityEngine;
using URandom = UnityEngine.Random;
using SRandom = System.Random;


public class test : MonoBehaviour
{
    void Start()
    {
        float number1 = URandom.Range(0f, 1000f);
        
        SRandom randomSystem = new SRandom();
        int number2 = randomSystem.Next(0, 10);
    }
}
