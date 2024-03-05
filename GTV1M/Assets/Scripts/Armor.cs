using UnityEngine;

/// <summary>
/// Represents the armor of the player
/// </summary>
public class Armor : MonoBehaviour
{
    [SerializeField]
    private int armor = 0;

    /// <summary>
    /// Returns (the strength of) the armor currently carried
    /// </summary>
    /// <returns>The strength of the armor</returns>
    public int GetArmorAmount()
    {
        return armor;
    }
    
    /// <summary>
    /// When running into something:
    /// - See if its an armor pickup
    /// - if so, copy its armor strength to this script
    /// - Destroy the game object 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ArmorPickup>( out ArmorPickup armorPickup))
        {
            armor = armorPickup.GetStrength();
            Destroy(other.gameObject);
        }
    }
}
