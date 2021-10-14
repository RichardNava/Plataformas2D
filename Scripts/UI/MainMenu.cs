using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject skinsPanel;
    public GameObject player;

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SetPlayerMaskDude()
    {
        PlayerPrefs.SetString("PlayerSelected", "MaskDude");
        ResetPlayerSkins();
    }
    public void SetPlayerNinjaFrog()
    {
        PlayerPrefs.SetString("PlayerSelected", "NinjaFrog");
        ResetPlayerSkins();
    }
    public void SetPlayerPinkMan()
    {
        PlayerPrefs.SetString("PlayerSelected", "PinkMan");
        ResetPlayerSkins();
    }
    public void SetPlayerVirtualGuy()
    {
        PlayerPrefs.SetString("PlayerSelected", "VirtualGuy");
        ResetPlayerSkins();
    }

    public void ResetPlayerSkins()
    {
        skinsPanel.gameObject.SetActive(false);
        player.GetComponent<PlayerSelect>().ChangeSkin();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
