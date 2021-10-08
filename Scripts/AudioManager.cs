using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    [SerializeField] Slider volumeSlider;


    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 0.5f);
            Load();
            SetLevel();
        }
        else
        {
            Load();
            SetLevel();
        }
        
    }
    
    public void SetLevel()
    {
        mixer.SetFloat("SetVolume", Mathf.Log10(volumeSlider.value) * 20);
        SaveSettings(volumeSlider.value);
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
    }

    private void SaveSettings(float sliderValue)
    {
        PlayerPrefs.SetFloat("volume", sliderValue);
    }
    

}
