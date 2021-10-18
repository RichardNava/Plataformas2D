using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJoystick : MonoBehaviour
{
    // Variables para saber si estamos moviendo al personaje y hacia donde
    private float axisX = 0f; // Variable númerica que recoge si ha habido moviento en el Joystick (rango -1 / 1)
    private Joystick joystick; // Referencia al GameObject Joystick 

    // Atributos físicos para el movimiento (fuerza)
    public float runSpeedHorizontal = 1f;
    public float runSpeed = 2f;
    public float jumpSpeed = 4f;
    public float doubleJumpSpeed = 1.5f;

    // Variable booleana para comprobar que nuestro player pueda o no realizar un doble salto
    private bool canDoubleJump = false;

    // Referencia al RigidBody para manejar la física de nuestro personaje
    public Rigidbody2D rb2D;

    // Variables para manejar la apariencia del Player
    public SpriteRenderer spriteR;
    public Animator anim;

    void Start()
    {
        rb2D.GetComponent<Rigidbody2D>();
        // Buscamos el único GameObject en la escena que tiene el tag "Joystick" asignadoselo a su respectiva variable
        joystick = GameObject.FindWithTag("Joystick").GetComponent<FixedJoystick>();
    }

    void Update()
    {
        if (axisX > 0)
        {
            spriteR.flipX = false;
            anim.SetBool("Run", true);
        }
        else if (axisX < 0)
        {
            spriteR.flipX = true;
            anim.SetBool("Run", true);
        }
        else
        {
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
        // Asignamos valor a la variable en función del movimiento del Joystick
        axisX = joystick.Horizontal * runSpeedHorizontal;
       
        // Efectuamos el movimiento del personaje 
        transform.position += new Vector3(axisX, 0, 0) * Time.deltaTime * runSpeed;

        //! rb2D.AddForce(new Vector2(axisX, 0) * Time.deltaTime * runSpeed);

    }

    // Creamos un método para el salto para asignarselo al On Click() del botón 
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
