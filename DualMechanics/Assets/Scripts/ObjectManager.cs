using UnityEngine;
using System.Collections.Generic;



public class ObjectManager : MonoBehaviour
{

    public MasterScript Mref;
    public List<Creature> EnemyList;
    public List<RoomClassScript> RoomList;
    public List<SkillClass> Skills = new List<SkillClass>();

  

    public void PopulateLists()
    {
        EnemyList = new List<Creature>();
        for (int i = 0; i < 20; i++)
        {
            Creature C = new Creature();
            EnemyList.Add(C);
        }
        RoomList = new List<RoomClassScript>();
        for (int i = 0; i < 20; i++)
        {
         
            RoomClassScript R = new RoomClassScript(Mref.Gref.Difficulty, Mref);
            RoomList.Add(R);
        }
    }
}
