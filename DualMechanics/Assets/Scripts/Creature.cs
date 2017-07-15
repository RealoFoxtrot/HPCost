using System;
using UnityEngine;

/* THE BIG CREATURE-RELATED TODO LIST:
 * Implement a way to select a creature and display its abilities in some kind of ability bar.
 * Add UI showing the creature's status.
 * Create an interface for components that define a creature's stats and abilities (and then create those components).
 * Create a component that controls AI-controlled creatures.
 * Probably a ton of other things I'm not remembering at the moment.
 */

public class Creature : MonoBehaviour
{
    /// <summary>
    /// Event that fires whenever this creature takes damage (not through health payment).
    /// </summary>
    public event Action<int, int> OnDamageTaken = delegate { };

    /// <summary>
    /// Event that fires when this creature dies.
    /// </summary>
    public event Action OnDeath = delegate { };

    /// <summary>
    /// The path to the Creature prefab, relative the Assets/Resources/.
    /// </summary>
    private const string PrefabPath = "Creature";

    /// <summary>
    /// True if the player controls this creature, false otherwise.
    /// </summary>
    public bool PlayerControlled { get; private set; }

    private int _health;
    public int Health
    {
        get { return this._health; }
        set
        {
            this._health = value;
            // Question: do we want this integrated into the property?
            // Are there times where health the variable is allowed to be 0 or less and the creature should not die?
            if (this._health <= 0)
            {
                this.Die();
            }
        }
    }

    /// <summary>
    /// Spawn 
    /// </summary>
    public static void Spawn()
    {
        GameObject creature_obj = GameObject.Instantiate(QuickLoad.Load<GameObject>(PrefabPath));
        // TODO: give it a good position in the scene.
    }

    public void OnDrawGizmos()
    {
        // No sprite attached at the moment, so just draw a gizmo on our position.
        Gizmos.DrawWireSphere(this.transform.position, 0.5f);
    }

    /// <summary>
    /// Inflicts [damage_amount] damage on this creature. Triggers OnDamageTaken.
    /// </summary>
    public void TakeDamage(int damage_amount)
    {
        var old_health = this.Health;
        this.Health -= damage_amount;
        this.OnDamageTaken(old_health, this.Health);
    }

    /// <summary>
    /// Heals this creature for [heal_amound] health. Does not currently have an associated event.
    /// </summary>
    public void Heal(int heal_amount)
    {
        // TODO: make an OnHeal event if necessary.
        this.Health += heal_amount;
    }

    /// <summary>
    /// Kills this creature instantly (regardless of health).
    /// </summary>
    public void Die()
    {
        this.OnDeath();
        GameObject.Destroy(this.gameObject);
    }
}
