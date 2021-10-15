using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJoystick : MonoBehaviour
{
    // Variables para saber si estamos moviendo al personaje y hacia donde
    private float axisX = 0f;
    public Joystick joystick;

    // Atributos físicos para el movimiento (fuerza)
    public float runSpeedHorizontal = 1f;
    public float runSpeed = 2f;
    public float jumpSpeed = 4f;
    public float doubleJumpSpeed = 1.5f;

    // Valores para conocer la potencia del salto en función de la presión ejercida
    public float pressForce = 0.2f;
    public float multiplier = 1f;

    private bool canDoubleJump = false;

    public Rigidbody2D rb2D;

    public SpriteRenderer spriteR;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2D.GetComponent<Rigidbody2D>();
        //GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();

    }

    void Update()
    {
        if (axisX > 0)
        {
            //rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteR.flipX = false;
            anim.SetBool("Run", true);

        }
        else if (axisX < 0)
        {
            //rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteR.flipX = true;
            anim.SetBool("Run", true);
        }
        else
        {
            //rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            anim.SetBool("Run", false);
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

        }
        if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
        {
            anim.SetBool("Fall", false);
        }
    }


    private void FixedUpdate()
    {
        axisX = joystick.Horizontal * runSpeedHorizontal;
       
        transform.position += new Vector3(axisX, 0, 0) * Time.deltaTime * runSpeed;

        //rb2D.AddForce(new Vector2(axisX, 0) * Time.deltaTime * runSpeed);

    }

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            anim.SetBool("Jump", true);
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            canDoubleJump = true;
        }
        else
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
