using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractKick : MonoBehaviour, IInteracible
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Interact()
    {
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }
}
