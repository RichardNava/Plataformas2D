using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public Animator anim;
    public GameObject[] lifesArray;
    public float waitTime = 0f;
    private int lifes = 3;
    private int lifeLost = 0;


    void Start()
    {
        
    }

    void Update()
    {
        waitTime += Time.deltaTime;
        Debug.Log(waitTime);
    }

    public void PlayerDamage()
    {
        if (waitTime > 1)
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

                // Posibilidad 2 - Desactivar el componente
                // lifesArray[lifesArray.Length - lifeLost].SetActive(false);


            }
            else
            {
                lifesArray[0].GetComponent<Image>().color = Color.black;
                // Invoke llama a un método y recibe dos argumentos (string "Nombre del metodo",
                // float tiempo de espera para activar el método)
                anim.Play("Death");
                Invoke("Respawn", 1f);
            }
        }

    }
    public void Respawn()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
