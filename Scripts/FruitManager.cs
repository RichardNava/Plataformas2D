using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FruitManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int totalFruits = 0;
    public int fruitsCollected = 0;


    void Start()
    {
        totalFruits = transform.childCount;
        scoreText.text = "Frutas " + fruitsCollected + " / " + totalFruits;
    }

    void Update()
    {
        fruitsCollected = totalFruits - transform.childCount;
        scoreText.text = "Frutas " + fruitsCollected + " / " + totalFruits;
    }

    public void AllFruitsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("¡ENHORABUENA! TE HAS PASADO EL NIVEL");
            // TODO: Incluir método para pasar de nivel  
        }
    }


}
