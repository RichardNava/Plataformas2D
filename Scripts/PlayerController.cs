using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Atributos físicos para el movimiento (fuerza)
    public float runSpeed = 2f;
    public float jumpSpeed = 4f;
    public float doubleJumpSpeed = 1.5f;


    private bool canDoubleJump = false;
   
    public Rigidbody2D rb2D;

    public SpriteRenderer spriteR;
    public Animator anim;

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
                anim.SetBool("Jump", true);
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                canDoubleJump = true;
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        anim.SetBool("DoubleJump", true);
                        rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }

        }
        if (CheckGround.isGrounded == false)
        {
            anim.SetBool("Jump", true);
            anim.SetBool("Run", false);
        }
        if (CheckGround.isGrounded == true)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("DoubleJump", false);
            anim.SetBool("Fall", false);

        }
        if (rb2D.velocity.y < 0)
        {
            anim.SetBool("Fall", true);

            //if (Input.GetKey(""))
            //{

            //}
        }
        if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
        {
            anim.SetBool("Fall", false);
        }
    }
    


    private void FixedUpdate()
    {
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            rb2D.velocity = new Vector2(runSpeed,rb2D.velocity.y);
            spriteR.flipX = false;
            anim.SetBool("Run", true);

        }
        else if (Input.GetKey("left") || Input.GetKey("a"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteR.flipX = true;
            anim.SetBool("Run", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            anim.SetBool("Run", false);
        }

    }
}
