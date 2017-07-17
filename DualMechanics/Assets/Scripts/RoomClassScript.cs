using UnityEngine;
using System.Collections;

[System.Serializable]
public class RoomClassScript{

    public int Difficulty;
    public int Enemies;
    public int Reward;
    public Creature[] Encounters;

    public RoomClassScript(int CurrentDifficulty, MasterScript Mref)
    {
       
        Difficulty = Random.Range(0, CurrentDifficulty+1);
        Enemies = Random.Range(1, 2 + (int)(CurrentDifficulty / 2f));
        Reward = (Difficulty+1) * Enemies * Random.Range(1, 4);
        Encounters = new Creature[Enemies];
        for (int i = 0; i < Enemies; i++)
        {
            int limit = CurrentDifficulty + 1;
            if (limit > Mref.Oref.EnemyList.Count)
            {
                limit = Mref.Oref.EnemyList.Count;
            }
            int dice = Random.Range(0, limit);
            Encounters[i] = new Creature(Mref.Oref.EnemyList[dice]);
           
        }
    }
}
