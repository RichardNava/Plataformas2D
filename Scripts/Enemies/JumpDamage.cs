using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    //public Collider2D colli2D;
    public Animator anim;
    public SpriteRenderer sr;
    public GameObject destroyCollected;
    public float bounceSpeed = 2f;
    public int lifes = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up* bounceSpeed);
            LifeAndHit();
            CheckLifes();
        }
    }
    public void LifeAndHit()
    {
        lifes--;
        anim.Play("Hit");
    }
    public void CheckLifes()
    {
        if (lifes == 0)
        {
            destroyCollected.SetActive(true);
            sr.enabled = false;
            Invoke("EnemyDie",0.3f);
        }
    }
    public void EnemyDie()
    {
      Destroy(gameObject);
    }

}
