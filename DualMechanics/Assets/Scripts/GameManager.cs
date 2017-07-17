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
    public SkillClass[] Shop;

    void Start()
    {
        Mainmenu = true;
        Mref.Uref.OverlayUI();

    }

    void Update()
    {
        if (Credits == true)
        {
            Mref.Uref.UiElements[15].SetActive(true);
        }
        else
        {
            Mref.Uref.UiElements[15].SetActive(false);
        }
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
        RoomCount -= 1;
        Location = new RoomClassScript(Difficulty, Mref);
        Mref.Uref.SetupEnemyStats();
        Mref.Uref.OverlayUI();
    }
    public void LoadRespiteRoom()
    {
   
        RespiteMode = true;
        Difficulty++;
        RoomCount = Difficulty + 1;
        Mref.Oref.UpdateOptions();
        int shopsize = 3;
        if (shopsize > Mref.Oref.Options.Count)
        {
            shopsize = Mref.Oref.Options.Count;
        }

        Shop = new SkillClass[shopsize];
       
        for (int i = 0; i < shopsize; i++)
        {
            Shop[i] = Mref.Oref.Options[Random.Range(0, Mref.Oref.Options.Count)];
           
            
        }
        Mref.Uref.OverlayUI();
    }
    public void EnemyAction()
    {
        for (int i = 0; i < Location.Encounters.Length; i++)
        {
            if (Location.Encounters[i].CurrentHealth > 0)
            {
                Location.Encounters[i].TakeTurn();
            }
            else
            {
                Location.Encounters[i].Active = false;
            }
        }
        CheckEnemies();
    }
    void CheckEnemies()
    {
        bool stillplay = false;
        for (int i = 0; i < Location.Encounters.Length; i++)
        {
            if (Location.Encounters[i].Active) { stillplay = true; Target = i; }
        }
        if (!stillplay)
        {
            Mref.Cref.Heal(Location.Reward * 6);
            Mref.Cref.boostwill(1);

            Mref.Uref.UiElements[7].SetActive(true);
            Mref.Uref.UiElements[6].SetActive(false);
            Mref.Uref.UiElements[4].SetActive(false);
            Mref.Uref.UiElements[12].SetActive(false);
        }
    }
    void ClearRoom() {
        Mref.Uref.ClearEnemies();
        Mref.Uref.OverlayUI();
    }
    public void NextRoom()
    {
        
        BattleMode = false;

        RespiteMode = false;
        Mref.Uref.OverlayUI();
        ClearRoom();
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
