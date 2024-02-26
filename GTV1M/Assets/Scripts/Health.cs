using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Basic health class.
/// Keeps track of current health.
/// Max health maybe should be 'settable' from the inspector. An exercise?
/// </summary>
public class Health : MonoBehaviour
{
    private float CurrentHealth = 0;
    
    private float MaxHealth = 100;

    public UnityEvent<float> HealthUpdate;

    public UnityEvent GameOver;
    
    /// <summary>
    /// Set current health equal to max health.
    /// </summary>
    void Start()
    {
        CurrentHealth = MaxHealth;
        BroadcastHealth();
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
        Debug.Log(CurrentHealth);
        
        BroadcastHealth();
    }

    /// <summary>
    /// Let all registered listeners know health stats have updated
    /// Only of current health <= 0, the gameover event is broadcast
    /// </summary>
    private void BroadcastHealth()
    {
        HealthUpdate.Invoke(CurrentHealth / MaxHealth);
        if (CurrentHealth <= 0)
        {
            // give signal on game over
            GameOver?.Invoke();
        }
    }
}
