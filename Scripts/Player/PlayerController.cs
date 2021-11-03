using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Atributos físicos para el movimiento (fuerza)
    public float runSpeed = 2f;
    public float jumpSpeed = 4f;
    public float doubleJumpSpeed = 1.5f;
    [SerializeField] LayerMask groundLayer;

    public ParticleSystem dust;

    // Salto sensible 
    public bool inputJump;
    // Valores para conocer la potencia del salto en función de la presión ejercida
    public float pressForce = 0.2f;
    public float multiplier = 1f;

    // Variable númerica para controlar el tiempo que nuestro player pasa en el aire (Coyote Time)
    public float timeInAir;

    private bool canDoubleJump = false;
   
    public Rigidbody2D rb2D;

    public SpriteRenderer spriteR;
    public Animator anim;

    void Start()
    {
        rb2D.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D[] rayGround = DrawRay();

        // Foreach en desuso porque el método DrawRay ahora también comprueba el layer Ground que tengamos en la parte superior
        //!foreach (var ray in rayGround) 
        //!{
            if (rayGround[0] || rayGround[1] || rayGround[2])
            {
                timeInAir = 0;
            }
            else
            {
                timeInAir += Time.deltaTime;
            }
        //!}

        JumpManager(rayGround);
        if (Input.GetKey("right") || Input.GetKey("d")) 
        {
            rb2D.velocity = new Vector2(runSpeed,rb2D.velocity.y);
            spriteR.flipX = false;
            if (dust.transform.rotation.y > -90)
            {
                dust.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            anim.SetBool("Run", true);

        }
        else if (Input.GetKey("left") || Input.GetKey("a"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteR.flipX = true;
            if (dust.transform.rotation.y < 90)
            {
                dust.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            anim.SetBool("Run", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            anim.SetBool("Run", false);
        }
        if (inputJump)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * multiplier * Time.deltaTime;

            }
            if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * pressForce * Time.deltaTime;
            }
        }
    }

    public RaycastHit2D [] DrawRay()
    {
        RaycastHit2D[] rayGround = new RaycastHit2D[5];
        rayGround[0] = Physics2D.Raycast(new Vector2(transform.position.x - 0.06f, transform.position.y), Vector2.down, 0.25f, groundLayer);
        rayGround[1] = Physics2D.Raycast(transform.position, Vector2.down, 0.25f, groundLayer);
        rayGround[2] = Physics2D.Raycast(new Vector2(transform.position.x + 0.06f, transform.position.y), Vector2.down, 0.25f, groundLayer);
        rayGround[3] = Physics2D.Raycast(new Vector2(transform.position.x - 0.09f, transform.position.y), Vector2.up, 2.25f, groundLayer);
        rayGround[4] = Physics2D.Raycast(new Vector2(transform.position.x + 0.10f, transform.position.y), Vector2.up, 2.25f, groundLayer);

        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        Debug.DrawRay(new Vector2(transform.position.x - 0.06f, transform.position.y), Vector2.down, Color.red);
        Debug.DrawRay(new Vector2(transform.position.x + 0.06f, transform.position.y), Vector2.down, Color.red);
        Debug.DrawRay(new Vector2(transform.position.x - 0.09f, transform.position.y), Vector2.up, Color.red);
        Debug.DrawRay(new Vector2(transform.position.x + 0.10f, transform.position.y), Vector2.up, Color.red);

        return rayGround;
    }

    public void JumpManager(RaycastHit2D[] rayGround)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(rayGround[0] || rayGround[1] || rayGround[2]) //!if (CheckGround.isGrounded)
            {
                Jump();
                DodgeCorner(rayGround);
            }
            else
            {
                if (timeInAir < 0.25) // Permitimos saltar si el contador de tiempo en el aire no ha escedido una 1/4 parte de un segundo
                {
                    Jump();
                    DodgeCorner(rayGround);
                }
                if (Input.GetKeyDown(KeyCode.Space))
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
        // Estructura para controlar las animaciones
        if (!rayGround[0] || !rayGround[1] || !rayGround[2]) // Similar a if (rayGround[0] == false || ...)
        {
            anim.SetBool("Jump", true);
            anim.SetBool("Run", false);
        }
        if (rayGround[0] || rayGround[1] || rayGround[2])
        {
            anim.SetBool("Jump", false);
            anim.SetBool("DoubleJump", false);
            anim.SetBool("Fall", false);
        }
        if (rb2D.velocity.y < 0)
        {
            anim.SetBool("Fall", true);

        }
        if (rb2D.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Fall", false);
        }
    }

    public void Jump()
    {
        anim.SetBool("Jump", true);
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        canDoubleJump = true;
    }

    public void DodgeCorner(RaycastHit2D[] rayGround)
    {
        if (rayGround[3] && !rayGround[4])
        {
            transform.position += new Vector3(0.05f, 0);
        }
        if (!rayGround[3] && rayGround[4])
        {
            transform.position -= new Vector3(0.05f, 0);
        }
    }

    public void DustPlay()
    {
        dust.Play();
    }
    public void DustStop()
    {
        dust.Stop();
    }
}

