using UnityEngine;
using System.Collections;

[System.Serializable]
public class Creature {

    public string Name;
    public int CurrentHealth;
    public int MaxHealth;

    public Creature()
    {
        Name = "creature";
        MaxHealth = 6;
        CurrentHealth = MaxHealth;
    }
}
