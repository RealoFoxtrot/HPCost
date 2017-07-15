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

    void Start()
    {
        Mainmenu = true;
        Mref.Uref.OverlayUI();
    }

    public void LoadRoom(int Difficulty)
    {

    }

    public void NextRoom()
    {

    }
}
