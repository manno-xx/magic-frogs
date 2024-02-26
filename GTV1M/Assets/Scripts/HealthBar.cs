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
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        // TESTING
        // UpdateHealthBar(.5f);
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
