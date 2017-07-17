using UnityEngine;
using System.Collections.Generic;

public class CharacterScript : MonoBehaviour
{

    public MasterScript Mref;
    public List<SkillClass> Learned;

    public int Will;
    public double Fort;
    public double MaxFort;
    public int Maxwill;
    public double Protection;

    public void Setup()
        
    {
        Learned = new List<SkillClass>();
        for (int i = 0; i < Mref.Oref.Skills.Count; i++)
        {
            if (Mref.Oref.Skills[i].StartingSkill)
            {
                Learned.Add(Mref.Oref.Skills[i]);
            }
        }
        Will = 0;
        Fort = 100;
        MaxFort = 120;
        Maxwill = 10;
    }

    public void useskill(string Use)
    {
        Protection = 0;
        bool action = false;
        switch (Use)
        {
            case "Quick Attack":
                action = true;
                Fort -= 2;
                Mref.Gref.Location.Encounters[Mref.Gref.Target].CurrentHealth -= 4;
                Protection = 0.8;
                break;

            case "Basic Attack":
                Mref.Gref.Location.Encounters[Mref.Gref.Target].CurrentHealth -= 8;
                Protection = 0.4;
                Fort -= 4;
                action = true;
                break;

            case "Determination":
                Heal(20);
                Protection = 0.8;
                Will -= 1;
                action = true;
                break;

            case "Broad Attack":
                    for (int i = 0; i < Mref.Gref.Location.Encounters.Length; i++)
                    {
                        Mref.Gref.Location.Encounters[i].CurrentHealth -= 5;
                    }
                    Fort -= 15;
                    action = true;
                break;

            case "Sacrifice":
                if (Will < 3)
                {
                    boostwill(-3);
                    for (int i = 0; i < Mref.Gref.Location.Encounters.Length; i++)
                    {
                        Mref.Gref.Location.Encounters[i].CurrentHealth -= 50;
                    }
                    action = true;
                }
                else
                {
                    Fort -= 50;
                    for (int i = 0; i < Mref.Gref.Location.Encounters.Length; i++)
                    {
                        Mref.Gref.Location.Encounters[i].CurrentHealth -= 50;
                    }
                    action = true;
                }
                break;

        }
        Mref.Uref.UpdateEnemyStats();
        if (action)
        {

            Mref.Gref.EnemyAction();


        }

        Mref.Uref.UpdateStats();
    }
    public void Attacked(double Value)
    {
        Fort -= Value - (Value * Protection);

        if (Fort < 1)
        {
            CharacterDeath();
        }
        
        //if (Value > Protection)
        //{
        //    Value -= Protection;
        //    HP -= Value;
        //    Protection = 0;
        //}
        //else
        //{
        //    Protection -= Value;
        //}


    }
    public void Heal(int Value)
    {
        Fort += Value;
        {
            if (Fort > MaxFort)
            {
                Fort = MaxFort;
            }
        }
    }
    public void boostwill(int Value)
    {
        Will += Value;
        if (Will > Maxwill)
        {
            Will = Maxwill;
        }
        else
        {
            if (Will < 0)
            {
                Will = 0;
            }
        }
    }

    public void CharacterDeath() {
        Mref.Gref.InPlay = false;
        Mref.Gref.BattleMode = false;
        Mref.Gref.Mainmenu = true;
        Mref.Uref.OverlayUI();
    }
}
