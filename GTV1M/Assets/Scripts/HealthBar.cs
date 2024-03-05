using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    private Image healthBar;

    [SerializeField] private Gradient barColor;
    
    /// <summary>
    /// Initialise in Awake
    /// </summary>
    void Awake()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    public void UpdateHealthBar(float percentage)
    {
        // set the fill amount of the image to match percentage
        healthBar.fillAmount = percentage;
        // apply color
        healthBar.color = barColor.Evaluate(percentage);
    }
}
