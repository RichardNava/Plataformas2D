using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 4;
    public Rigidbody2D rb2D;

    public SpriteRenderer spriteR;

    // Start is called before the first frame update
    void Start()
    {
        rb2D.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            if (CheckGround.isGrounded)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            }

        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            rb2D.velocity = new Vector2(runSpeed,rb2D.velocity.y);
            spriteR.flipX = false;
            Debug.Log("Sigo aqui");

        }
        else if (Input.GetKey("left") || Input.GetKey("a"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteR.flipX = true;
        }

    }
}
