using UnityEngine;

/// <summary>
/// When running into a damage dealing area, this script deals with the logic.
/// </summary>
[RequireComponent(typeof(Health), typeof(Armor))]
public class DamageControl : MonoBehaviour
{
    private Health healthComponent;

    private Armor armorComponent;
    
    /// <summary>
    /// Initialise by getting references to the components needed (and that should be on this game object as well 
    /// </summary>
    void Start()
    {
        healthComponent = GetComponent<Health>();
        armorComponent = GetComponent<Armor>();
    }

    /// <summary>
    /// When running into something:
    /// - check if it is a DamageDealer. If so
    ///   - retrieve the amount of damage that should do 
    ///   - get the strength of the current armor
    ///   - subtract that from the proposed damage
    ///   - apply the damage to the HP (Health script)
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DamageDealer>(out DamageDealer damageDealer))
        {
            int proposedDamage = damageDealer.GetAmount();
            int myArmor = armorComponent.GetArmorAmount();
            int actualDamage = proposedDamage - myArmor;
            healthComponent.Decrease(actualDamage);
        }
    }
}
