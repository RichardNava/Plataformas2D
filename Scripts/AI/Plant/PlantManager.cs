using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    private float cooldown;
    public float cooldownAttack = 3f;
    public float rayDistance = 4f;

    public GameObject bullet;
    public GameObject plant;


    public static bool left = true;


    void Start()
    {
        cooldown = cooldownAttack;
    }

    void Update()
    {
        if (cooldown <= 0)
        {
            cooldown = cooldownAttack;
            plant.GetComponent<Animator>().Play("Attack");
            ShootBullet();
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

    public void ShootBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bullet, transform.position, transform.rotation);
    }

    private void FixedUpdate()
    {
        RaycastHit2D ray2DLeft = Physics2D.Raycast(transform.position, Vector2.left, rayDistance);
        RaycastHit2D ray2DRight = Physics2D.Raycast(transform.position, Vector2.right, rayDistance);

        if (ray2DLeft.collider.CompareTag("Player"))
        {
            left = true;
            plant.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (ray2DRight.collider.CompareTag("Player"))
        {
            left = false;
            plant.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
