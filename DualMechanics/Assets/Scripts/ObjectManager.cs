using UnityEngine;
using System.Collections.Generic;



public class ObjectManager : MonoBehaviour
{

    public MasterScript Mref;
    public List<Creature> EnemyList;
    public Creature.ActionPatterns[] MasterActionPatterns = new Creature.ActionPatterns[10];
    public List<SkillClass> Skills = new List<SkillClass>();
    public List<SkillClass> Options;
    public string[] CreatureNames = new string[20];


    public void PopulateLists()
    {
        EnemyList = new List<Creature>();
        for (int i = 0; i < 20; i++)
        {
            Creature C = new Creature(MasterActionPatterns, CreatureNames[i], Mref);
            EnemyList.Add(C);
        }

    }
    public void UpdateOptions()
    {
        Options = new List<SkillClass>();
        for (int i = 0; i < Skills.Count; i++)
        {
            bool add = true;
            for (int a = 0; a < Mref.Cref.Learned.Count; a++)
            {
                if (Mref.Cref.Learned[a] == Skills[i]) { add = false; }
            }
            if (add)
            {
                Options.Add(Skills[i]);
            }
        }
    }
}
