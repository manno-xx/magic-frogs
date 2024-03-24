using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private LayerMask myMask;
    
    // Update is called once per frame
    void Update()
    {
        // if the E-key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Cast a ray in the looking direction
            Ray ray = new Ray(transform.position, transform.forward);
            
            Debug.DrawRay(transform.position, transform.forward, Color.magenta, 10);
            
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 4, myMask))
            {
                // If it has hit an 'interactible'
                if (hitInfo.transform.gameObject.TryGetComponent<IInteracible>(out IInteracible interactible))
                {
                    // call its Interact function
                    interactible.Interact();
                }
            }
        }
    }
    
}
