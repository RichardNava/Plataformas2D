using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    [SerializeField] Slider volume;


    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 0.5f);

        }
        else
        {
            // TODO
        }
        
    }
    
    public void SetLevel(float sliderValue)
    {
        // TODO
    }

    private void SetSettings(float sliderValue)
    {
        PlayerPrefs.SetFloat("volume", sliderValue);
    }
}
