using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDestroy : MonoBehaviour, IInteracible
{
    public void Interact()
    {
        Destroy(gameObject);
    }
}
