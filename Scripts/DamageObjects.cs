using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObjects : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Accedemos al m�todo del Componente C# Script gracias al GetComponent()
            collision.transform.GetComponent<PlayerState>().PlayerDamage();
        }
    }
}
