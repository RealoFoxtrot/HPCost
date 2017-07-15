using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public MasterScript Mref;
    public GameObject[] UiElements;
    public Slider MSlider;
    public Slider SSlider;

    /*ui prefabs*/
    public GameObject SkillText;
    public GameObject EnemyStat;

    public void OverlayUI()
    {
        CloseAllUI();
        if (Mref.Gref.SoundOptions)
        {
            OpenSoundMenu();
        }
        if (Mref.Gref.Mainmenu)
        {
            OpenMainMenu();
        }
        if (Mref.Gref.Credits)
        {
            OpenCredits();
        }
        if (Mref.Gref.BattleMode)
        {
            Statbar();
            SetupActions();
            UpdateEnemyStats();
        }
    }
    void CloseAllUI()
    {
        for (int i = 0; i < UiElements.Length; i++)
        {
            if (UiElements[i] != null) { UiElements[i].SetActive(false); }
        }
    }

    /* sound menu*/
    public void Musicbutton()
    {
        Mref.Sref.PlaySound(0);
        Mref.Sref.MusicButton();
    }
    public void SFxbutton()
    {
        Mref.Sref.PlaySound(0);
        Mref.Sref.SoundButton();
    }
    public void SoundOptionsBackButton()
    {
        Mref.Gref.SoundOptions = false;
        OverlayUI();
        Mref.Sref.PlaySound(0);
    }
    public void CloseSoundMenu()
    {
        Mref.Sref.PlaySound(0);

        Mref.Gref.SoundOptions = false;
        OverlayUI();
    }
    public void OpenSoundMenu()
    {

        UiElements[1].SetActive(true);
        MSlider = UiElements[1].transform.GetChild(3).GetComponentInChildren<Slider>();
        SSlider = UiElements[1].transform.GetChild(5).GetComponentInChildren<Slider>();
        MSlider.value = Mref.Sref.MusicVolume;
        SSlider.value = Mref.Sref.SoundVolume;
        if (Mref.Sref.MusicOn)
        {
            UiElements[1].transform.GetChild(0).GetComponentInChildren<Text>().text = "Music Off";

        }
        else {
            UiElements[1].transform.GetChild(0).GetComponentInChildren<Text>().text = "Music On";

        }
        if (Mref.Sref.SFXOn)
        {
            UiElements[1].transform.GetChild(1).GetComponentInChildren<Text>().text = "Sound Effects Off";
        }
        else {
            UiElements[1].transform.GetChild(1).GetComponentInChildren<Text>().text = "Sound Effects On";
        }
    }
    public void MusicSlider()
    {
        float X = MSlider.value;
        Mref.Sref.MusicChange(X);
    }
    public void SoundSlider()
    {
        float X = SSlider.value;
        Mref.Sref.SEChange(X);
        Mref.Sref.Counter = 1;
    }
    public void BackToMainSound()
    {
        Mref.Sref.PlaySound(0);
        Mref.Gref.Credits = false;
        Mref.Gref.SoundOptions = false;
        Mref.Gref.Mainmenu = true;
        OverlayUI();
    }
    /*main menu*/
    public void OpenMainMenu()
    {

        UiElements[0].SetActive(true);
    }
    public void StartGame()
    {
        Mref.Gref.SetupGame();
        Mref.Sref.PlaySound(0);
    }
    public void ViewCredits()
    {
        Mref.Sref.PlaySound(0);
        Mref.Gref.Mainmenu = false;
        Mref.Gref.Credits = true;
        OverlayUI();
    }
    public void ViewSound()
    {
        Mref.Sref.PlaySound(0);
        Mref.Gref.Mainmenu = false;
        Mref.Gref.SoundOptions = true;
        OverlayUI();
    }
    public void ExitGame()
    {
        Mref.Sref.PlaySound(0);
        Application.Quit();
    }
    /* Credit Menu*/
    public void OpenCredits()
    {
        UiElements[2].SetActive(true);
    }
    public void CloseCredits()
    {
        Mref.Sref.PlaySound(0);
        Mref.Gref.Mainmenu = true;
        Mref.Gref.Credits = false;
        OverlayUI();
    }
    /*In Play*/
    public void UpdateStats()


    {
        float percentage = ((float)Mref.Cref.HP / (float)Mref.Cref.MaxHP)*195;
        int sethealth =(int)( percentage);
        UiElements[3].transform.FindChild("HealthBar").FindChild("Level").GetComponent<LayoutElement>().preferredWidth = sethealth;
   percentage = ((float)Mref.Cref.Will / (float)Mref.Cref.Maxwill) * 195;
        sethealth = (int)(percentage);
        UiElements[3].transform.FindChild("WillBar").FindChild("Level").GetComponent<LayoutElement>().preferredWidth = sethealth;
        UiElements[3].transform.FindChild("RoomName").GetComponentInChildren<Text>().text = Mref.Gref.Currentroom;
    }
    public void Statbar()
    {
        UiElements[3].SetActive(true);
    }
    public void SetupActions()
    {
        UiElements[4].SetActive(true);
        foreach(Transform Child in UiElements[4].transform)
        {
            Destroy(Child.gameObject);
        }
        for (int i = 0; i < Mref.Cref.Learned.Count; i++)
                    {
            SkillClass Sref = Mref.Cref.Learned[i];
            GameObject S = Instantiate(SkillText);
            S.GetComponent<ActionScript>().Setup(Sref.NameSkill, Sref.DescribeSkill, Mref, UiElements[5], UiElements[5].GetComponentInChildren<Text>());
            S.transform.SetParent(UiElements[4].transform);
            S.GetComponent<Text>().text = Sref.NameSkill;
        }
    }
    public void SetupEnemyStats()
    {
        for (int i = 0; i < Mref.Gref.Location.Enemies; i++)
        {
            Creature C = Mref.Gref.Location.Encounters[i];
            GameObject E = Instantiate(EnemyStat);
            E.transform.SetParent(UiElements[6].transform);
            EnemyStat.GetComponentInChildren<Text>().text = C.Name;
            EnemyStat.GetComponentInChildren<TargetScript>().Setup(i, Mref);
            float percentage = ((float)C.CurrentHealth/ (float)C.CurrentHealth) * 115;
            int sethealth = (int)(percentage);
            E.transform.FindChild("HealthBar").FindChild("Level").GetComponent<LayoutElement>().preferredWidth = sethealth;
        }
    }
    public void UpdateEnemyStats()
    {
        UiElements[6].SetActive(true);
        for (int i = 0; i < Mref.Gref.Location.Enemies; i++)
        {
            Creature C = Mref.Gref.Location.Encounters[i];
            GameObject E = UiElements[6].transform.GetChild(i).gameObject;
            EnemyStat.GetComponentInChildren<Text>().text = C.Name;
            float percentage = ((float)C.CurrentHealth / (float)C.MaxHealth) * 115;
            int sethealth = (int)(percentage);
            E.transform.FindChild("HealthBar").FindChild("Level").GetComponent<LayoutElement>().preferredWidth = sethealth;
        }
    }
}

