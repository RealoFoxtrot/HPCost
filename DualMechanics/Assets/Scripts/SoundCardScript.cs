using UnityEngine;
using System.Collections;

public class SoundCardScript : MonoBehaviour
{

    public MasterScript Mref;
    public AudioSource Aref;
    public AudioClip[] SoundEffects;
    public AudioSource MuRef;
    public AudioClip[] Music;
    public bool MusicOn = true;
    public bool SFXOn = true;
    public float MusicVolume;
    public float SoundVolume;
    public float Counter;

    /*
    sounds needed
    0 - Button Success;
    1 - Alert Player;
    2 - Button Failure;

    */

    /*
    Music Needed
    0- Menu Music
    */


    public void PlaySound(int I)
    {
        Aref.PlayOneShot(SoundEffects[I]);
    }
    public void PlayMusic(int I)
    {
        MuRef.clip = Music[I];
        MuRef.Play();
    }
    public void Start()
    {
        MusicOn = true;
        SFXOn = true;
        MusicVolume = 0.6f;
        SoundVolume = 0.6f;
        MuRef.volume = 0.6f;
        Aref.volume = 0.6f;
    }
    public void MusicButton()
    {
        if (MusicOn)
        {
            MusicOn = false;
            MuRef.volume = 0;
            MusicVolume = 0;
        }
        else
        {
            MusicOn = true;
            MuRef.volume = 0.6f;
            MusicVolume = 0.6f;
        }
        Mref.Uref.CloseSoundMenu();
        Mref.Uref.OpenSoundMenu();
    }
    public void SoundButton()
    {
        if (SFXOn)
        {
            SFXOn = false;
            Aref.volume = 0;
            SoundVolume = 0;
        }
        else
        {
            SFXOn = true;
            Aref.volume = 0.6f;
            SoundVolume = 0.6f;
        }
        Mref.Uref.CloseSoundMenu();
        Mref.Uref.OpenSoundMenu();
    }

    public void SEChange(float Range)
    {
        Aref.volume = Range;
        SoundVolume = Range;
        if (!SFXOn && SoundVolume > 0)
        {
            SFXOn = true;
            Mref.Uref.CloseSoundMenu();
            Mref.Uref.OpenSoundMenu();
        }
        else if (SFXOn && SoundVolume == 0)
        {
            SFXOn = false;
            Mref.Uref.CloseSoundMenu();
            Mref.Uref.OpenSoundMenu();
        }

    }
    public void MusicChange(float Range)
    {
        MuRef.volume = Range;
        MusicVolume = Range;
        if (!MusicOn && MusicVolume > 0)
        {
            MusicOn = true;
            Mref.Uref.CloseSoundMenu();
            Mref.Uref.OpenSoundMenu();
        }
        else if (MusicOn && MusicVolume == 0)
        {
            MusicOn = false;
            Mref.Uref.CloseSoundMenu();
            Mref.Uref.OpenSoundMenu();
        }
    }
    void FixedUpdate()
    {
        if (Mref.Gref.SoundOptions && Counter > 0)
        {
            Counter -= 0.3f;
        }
        else if (Counter != -10)
        {
            Counter = -10;
            PlaySound(0);
        }
    }
}

