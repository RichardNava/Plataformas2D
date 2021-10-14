using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObjects : MonoBehaviour
{
    public float bounceSpeed = 3f;

    public bool bouncy = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Accedemos al método del Componente C# Script gracias al GetComponent()
            collision.transform.GetComponent<PlayerState>().PlayerDamage();
            if (bouncy)
            {
               collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * bounceSpeed);
            }
        }
    }
}
