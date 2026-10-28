using System;
using UnityEngine;

public class RefOut : MonoBehaviour
{
    private int gold = 50;
    public int silver = 50;
    void Start()
    {
        

        Debug.Log($"Plata antes del proceso: {silver}");
        ManufactureSilver(silver);
        Debug.Log($"Plata después del proceso: {silver}");
 
        
        
        Debug.Log($"Oro antes del proceso: {gold}");
        ManufactureGold(ref gold);
        Debug.Log($"Oro después del proceso: {gold}");

    }

    void ManufactureSilver(int amount)
    {
        amount *= 2;
        PaidTaxesSilver(amount);
        
        
    }
    
    void PaidTaxesSilver(int amount)
    {
        amount *= 3;
    }    
    
    
    void ManufactureGold(ref int amount)
    {
        amount *= 2;
        PaidTaxesGold(ref amount);
        
        
    }
    
    void PaidTaxesGold(ref int amount)
    {
        amount *= 3;
    }
    

}
