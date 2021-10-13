using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    public Animator anim;
    public GameObject[] lifesArray;
    public float waitTime = 0f;
    private int lifes = 3;
    private int lifeLost = 0;
    public Vector2 initialPosition;

    // Variables para guardar la posicion del player (X/Y)
    public float checkPointX, checkPointY;

    void Start()
    {
        if (PlayerPrefs.GetFloat("checkPointX") != 0 )
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointX"), PlayerPrefs.GetFloat("checkPointY")));
        }
        else
        {
            initialPosition = transform.position;

        }

    }
    void Update()
    {
        waitTime += Time.deltaTime;
    }

    public void PlayerDamage()
    {
        if (waitTime > 0.8f)
        {
            lifes--; // similiar -> lifes = lifes -1;
            anim.Play("Hit");

            if (lifes > 0)
            {
                lifeLost++;

                //   Heart1    Heart2   Heart3      Null   -> Length = 3
                //   pos 0     pos 1    pos 2      pos 3

                // Posibilidad 1 - Poner corazón negro. 
                lifesArray[lifesArray.Length - lifeLost].GetComponent<Image>().color = Color.black;
                waitTime = 0;
                // Posibilidad 2 - Desactivar el componente
                // lifesArray[lifesArray.Length - lifeLost].SetActive(false);
            }
            else
            {
                lifesArray[0].GetComponent<Image>().color = Color.black;
                waitTime = 0;
                // Invoke llama a un método y recibe dos argumentos (string "Nombre del metodo",
                // float tiempo de espera para activar el método)
                Invoke("Respawn", 0.5f);
            }
        }

    }
    public void Respawn()
    {

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (PlayerPrefs.GetFloat("checkPointX") != 0)
        {     
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointX"), PlayerPrefs.GetFloat("checkPointY")));
            ResetStats();
            
        }
        else
        {
            transform.position = initialPosition;
            ResetStats();
        }

    }

    public void SetCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointX", x);
        PlayerPrefs.SetFloat("checkPointY", y);
    }

    public void ResetStats()
    {
        lifes = 3;
        lifeLost = 0;
        lifesArray[0].GetComponent<Image>().color = Color.white;
        lifesArray[1].GetComponent<Image>().color = Color.white;
        lifesArray[2].GetComponent<Image>().color = Color.white;
        GetComponent<SpriteRenderer>().enabled = true;
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }
}
