using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public MasterScript Mref;
    public GameObject[] UiElements;
    public Slider MSlider;
    public Slider SSlider;
    public Text PlayerMessage;
    public GameObject Cref;
    public GameObject Tutorial;
    public GameObject TutorialPrefab;

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
}

