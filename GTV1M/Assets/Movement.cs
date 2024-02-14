using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component that deals with movement
/// In 'physics based' environments, movement would be done differently.
/// The book's mini game does it similar to the method below too and later makes it based on physics
/// </summary>
public class Movement : MonoBehaviour
{
    [SerializeField, Range(1,10), Tooltip("Define the speed here")] private float Speed = 4;
    
    /// <summary>
    /// Read input and use it to translate (move) the transform
    /// </summary>
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(Time.deltaTime * Speed * movement);
    }
}
