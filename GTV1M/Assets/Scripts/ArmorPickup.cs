using UnityEngine;

/// <summary>
/// The armor pickup
/// Mainly a simple data object storing an amount of armor
/// </summary>
public class ArmorPickup : MonoBehaviour
{
    [SerializeField, Range(1, 100), Tooltip("The strenght")] private int strength;

    /// <summary>
    /// Returns the strength of the armor this pickup has
    /// </summary>
    /// <returns>The strength ot the armor</returns>
    public int GetStrength()
    {
        return strength;
    }
}
