using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectSkin;

    public enum Player {MaskDude, NinjaFrog, PinkMan, VirtualGuy}; // Enum para seleccionar en el inspector entre las distintas skins
    public Player playerSelected;

    // Referenciamos dos componentes (Animator, SpriteRenderer)
    public Animator anim; 
    public SpriteRenderer sr;

    // Referencia al árbol de animaciones de los personajes
    public RuntimeAnimatorController[] playerAnimController;
    // Referencia al Sprite del Player
    public Sprite[] playerSprite;

    void Start()
    {
        if (!enableSelectSkin)
        {
            ChangeSkin();
        }
        else
        {
            switch (playerSelected)
            {
                case Player.MaskDude:
                    sr.sprite = playerSprite[0];
                    anim.runtimeAnimatorController = playerAnimController[0];
                    break;
                case Player.NinjaFrog:
                    sr.sprite = playerSprite[1];
                    anim.runtimeAnimatorController = playerAnimController[1];
                    break;
                case Player.PinkMan:
                    sr.sprite = playerSprite[2];
                    anim.runtimeAnimatorController = playerAnimController[2];
                    break;
                case Player.VirtualGuy:
                    sr.sprite = playerSprite[3];
                    anim.runtimeAnimatorController = playerAnimController[3];
                    break;
                default:
                    break;
            }
        }

    }

    public void ChangeSkin()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "MaskDude":
                sr.sprite = playerSprite[0];
                anim.runtimeAnimatorController = playerAnimController[0];
                break;
            case "NinjaFrog":
                sr.sprite = playerSprite[1];
                anim.runtimeAnimatorController = playerAnimController[1];
                break;
            case "PinkMan":
                sr.sprite = playerSprite[2];
                anim.runtimeAnimatorController = playerAnimController[2];
                break;
            case "VirtualGuy":
                sr.sprite = playerSprite[3];
                anim.runtimeAnimatorController = playerAnimController[3];
                break;
            default:
                break;
        }
    }
}
