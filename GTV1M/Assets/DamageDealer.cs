using UnityEngine;

/// <summary>
/// A damage dealing script
/// Defines the amount of damage an area or object does
/// </summary>
public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private int amount;

    /// <summary>
    /// Returns the amount of damage
    /// </summary>
    /// <returns>The amount of damage</returns>
    public int GetAmount()
    {
        return amount;
    }
}
