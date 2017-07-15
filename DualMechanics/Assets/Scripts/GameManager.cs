using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public MasterScript Mref;

    public bool Pause;
    public bool InPlay;
    public bool Mainmenu;
    public bool Credits;
    public bool SoundOptions;
    public bool BattleMode;
    public bool RespiteMode;


    public int Difficulty;
    public int RoomCount;
    public string Currentroom;
    public RoomClassScript Location;
    public int Target;

    void Start()
    {
        Mainmenu = true;
        Mref.Uref.OverlayUI();
       
    }

    public void SetupGame()
    {
        Mref.Oref.PopulateLists();
        Mainmenu = false;
        Mref.Cref.Setup();
        Difficulty = 0;
        RoomCount = 1;
        LoadBattleRoom();
        InPlay = true;
        Mref.Uref.OverlayUI();
        Mref.Uref.UpdateStats();
    }

    public void LoadBattleRoom()
    {
        BattleMode = true;
        Target = 0;
        RoomCount = -1;
        Location = Mref.Oref.RoomList[Random.Range(0, Mref.Oref.RoomList.Count)];
        Mref.Uref.SetupEnemyStats();
        Mref.Uref.OverlayUI();
    }
    public void LoadRespiteRoom()
    {
        RespiteMode = true;
        Difficulty++;
        RoomCount = Difficulty + 1;
        Mref.Uref.OverlayUI();
    }
    public void EnemyAction() { }
    public void NextRoom()
    {
        BattleMode = false;
        RespiteMode = false;
        if (RoomCount > 0)
        {
            LoadBattleRoom();
        }
        else
        {
            LoadRespiteRoom();
        }
    }
}
