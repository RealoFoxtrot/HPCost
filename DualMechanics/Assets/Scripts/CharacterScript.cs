using UnityEngine;
using System.Collections.Generic;

public class CharacterScript : MonoBehaviour {

    public MasterScript Mref;
    public List<SkillClass> Learned = new List<SkillClass>();

    public int Will;
    public int HP;
    public int MaxHP = 12;
    public int Maxwill = 20;
    public int Protection;

    public void Setup()
    {
        for (int i = 0; i < Mref.Oref.Skills.Count; i++)
        {
            if (Mref.Oref.Skills[i].StartingSkill) {
                Learned.Add(Mref.Oref.Skills[i]);
            }
        }
        Will = 1;
        HP = 10;
    }

    public void useskill(string Use)
    {
        bool action = false;
        switch (Use)
        {
            case "Small Quick Attack":
                action = true;
                Mref.Gref.Location.Encounters[Mref.Gref.Target].CurrentHealth --;
                break;
            case "Quick Guard":
                Will++;
                Protection = 2;
                action = true;
                break;
            case "Hammer Of God":
                if (Will > 2)
                {
                    for (int i = 0; i < Mref.Gref.Location.Encounters.Length; i++)
                    {
                        Mref.Gref.Location.Encounters[i].CurrentHealth -= 5;
                    }
                    Will -= 3;
                    action = true;
                }
                break;

        }
        Mref.Uref.UpdateEnemyStats();
        Mref.Uref.UpdateStats();
        if (action)
        {
            Mref.Gref.EnemyAction();
        }
    }
}
