using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenuManager : MonoBehaviour
{
    public TMP_Dropdown graphicsDropdown;
    public Slider masterVol, musicVol, sfxVol;
    public AudioMixer mainMixer;



    public void ChangeGraphicsQuality()
    {
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }

    public void ChangeMasterVolume()
    {
        mainMixer.SetFloat("MasterVol", masterVol.value);
    }
    public void ChangeMusicVolume()
    {
        mainMixer.SetFloat("MusicVol", musicVol.value);
    }
    public void ChangeSFXVolume()
    {
        mainMixer.SetFloat("SFXVol", sfxVol.value);
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
