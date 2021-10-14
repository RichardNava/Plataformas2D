using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource clickButtonSound;

    public GameObject pausePanel;
    public GameObject soundPanel;
    
    // Método para el botón de pause
    public void PausePanel()
    {
        Time.timeScale = 0; // Pausar el tiempo
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1; // Reanudar el tiempo
        pausePanel.SetActive(false);
    }

    public void SoundPanel()
    {
        pausePanel.SetActive(false);
        soundPanel.SetActive(true);
    }

    public void BackSoundPanel()
    {
        pausePanel.SetActive(true);
        soundPanel.SetActive(false);
    }


    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu"); // Cargamos la escena buscando por nombre
    }

    public void QuitGame()
    {
        // Llamada al método que sale del juego
        Debug.Log("Saliendo del juego");
        Application.Quit();

    }

    public void PlaySoundButton()
    {
        clickButtonSound.Play();
    }
}
