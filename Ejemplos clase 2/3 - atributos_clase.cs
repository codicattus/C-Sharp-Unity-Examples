using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

class AtributosClase : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.mass = 5f;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }
}