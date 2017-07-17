using UnityEngine;
using System.Collections;

[System.Serializable]
public class Creature
{

    public string Name;
    public int CurrentHealth;
    public int MaxHealth;
    public bool Active;
    public int Attackpattern;
    public ActionPatterns[] APlist;
    MasterScript Mref;

    [System.Serializable]
    public class ActionPatterns
    {
        public string Name;
        public string[] Actions = new string[4];
    }

    public Creature(ActionPatterns[] AP, string N, MasterScript M)
    {
        APlist = AP;
        Name = N;
        MaxHealth = 30;
        CurrentHealth = MaxHealth;
        Active = true;
        Mref = M;
        Attackpattern = Random.Range(0, APlist.Length);
    }
    public Creature(Creature Template)
    {
        Name = Template.Name;
        MaxHealth = Template.MaxHealth;
        CurrentHealth = Template.CurrentHealth;
        Active = Template.Active;
        APlist = Template.APlist;
        Attackpattern = Template.Attackpattern;
        Mref = Template.Mref;
    }

    public int CurrentAction = 0;
    public void TakeTurn()
    {
      
        if (CurrentAction > 3) { CurrentAction = 0; }
        ActionUse(APlist[Attackpattern].Actions[CurrentAction]);
        CurrentAction++;

    }

    public void ActionUse(string Use)
    {
        switch (Use)
        {
            case "":
                break;
            case "Light Attack":
                Mref.Cref.Attacked(4);
                break;
        }
    }
}
    /*

    Action Use - every type of action you want to happen for an enemy create a case matching its name here with the outcome of each 
    (mref.cref.attacked(?) will attack the player character and take into account protection from guard with ? being strength of attack)

    action patterns - you can create a pattern of 4 actions that will cycle around while the creature is alive (eg attack, nothing, guard, attack), 
    you can create a master list of attack patterns in the inspector that will be randomly assigned at the start of the game when creatures are created,
    
    Creature names - create a master list of names in the object manager in inspector;

    */

