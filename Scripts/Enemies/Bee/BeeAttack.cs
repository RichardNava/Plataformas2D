using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack : MonoBehaviour
{
    public Animator anim;
    public float rangeRay = 0.8f;

    private float cooldown = 1.5f;
    private float currentCooldown;

    public GameObject bullet;

    void Start()
    {
        currentCooldown = 0;
    }


    void Update()
    {
        currentCooldown += Time.deltaTime;
        Debug.DrawRay(transform.position, Vector2.right, Color.red, rangeRay);
    }

    private void FixedUpdate()
    {   
        RaycastHit2D ray2D = Physics2D.Raycast(transform.position, Vector2.down, rangeRay);

        if (ray2D.collider != null)
        {

            if (ray2D.collider.transform.CompareTag("Player") && currentCooldown > cooldown)
            {
                Invoke("ShootBullet", 0.1f);
                anim.Play("Attack");
                currentCooldown = 0;
            }
        }
    }

    private void ShootBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bullet, transform.position, transform.rotation);
    }
}
