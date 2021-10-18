using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public float speed; 
    public float reverseSpeed; 
    public float playerDistance;
    public float visionRange, returnRange;

    public Transform player;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector2.Distance(player.position, rb.position);

        if (playerDistance < visionRange && playerDistance > returnRange)
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, new Vector2(player.position.x, player.position.y), speed * Time.deltaTime);
            rb.MovePosition(newPos);
        }
        else if(playerDistance < returnRange)
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, new Vector2(player.position.x, player.position.y), reverseSpeed * Time.deltaTime);
            rb.MovePosition(newPos);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);
        Gizmos.DrawWireSphere(transform.position, returnRange);
    }
}
