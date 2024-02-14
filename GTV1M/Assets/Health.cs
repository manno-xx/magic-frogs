using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic health class.
/// Keeps track of current health.
/// Max health maybe should be 'settable' from the inspector. An exercise?
/// </summary>
public class Health : MonoBehaviour
{
    private float CurrentHealth = 0;
    
    private float MaxHealth = 100;
    
    /// <summary>
    /// Set current health equal to max health.
    /// </summary>
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    /// <summary>
    /// For now, when we click it, health decreases
    /// </summary>
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
        
        // todo: notify 'the world' health has changed (so UI can get updated)
    }
}
