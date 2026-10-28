using UnityEngine;

public class SistemaSalud : MonoBehaviour
{
    private float _vidaActual = 100f;

    // Versión 1: Daño básico
    public void RecibirDaño(float cantidad)
    {
        _vidaActual -= cantidad;
        Debug.Log($"Daño recibido: {cantidad}. Vida restante: {_vidaActual}");
    }

    // Versión 2: Daño con empuje físico (Sobrecarga 1)
    public void RecibirDaño(float cantidad, Vector3 direccionEmpuje, float fuerza)
    {
        // 1. Reutilizamos la lógica básica llamando a la versión 1:
        RecibirDaño(cantidad); 

        // 2. Añadimos la lógica extra del empuje:
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.AddForce(direccionEmpuje * fuerza, ForceMode.Impulse);
    }

    // Versión 3: Daño con tipo elemental (Sobrecarga 2)
    public void RecibirDaño(float cantidad, string tipoElemento)
    {
        if (tipoElemento == "Fuego") cantidad *= 1.5f; // Los enemigos de hielo sufren más
        RecibirDaño(cantidad);
    }
}
