using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float CurrentHealth = 0;
    
    private float MaxHealth = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void OnMouseDown()
    {
        Decrease(10);
    }
    
    /// <summary>
    /// Decrease the health
    /// </summary>
    /// <param name="amount">The amount by which to decrease</param>
    private void Decrease(int amount)
    {
        CurrentHealth -= amount;
        // Debug.Log(CurrentHealth);
    }
}
