using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemies : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sr;

    public float speed = 0.5f;
    
    // Varibables númericas (Manejador del tiempo e indice)
    private float waitTime;
    public float startWaitTime = 2f;
    private int i = 0;

    private Vector2 actualPos;


    public Transform[] spotsMove;


    void Start()
    {
        waitTime = startWaitTime;
    }

    void Update()
    {
        StartCoroutine(CheckMoving());

        transform.position = Vector2.MoveTowards(transform.position, spotsMove[i].transform.position, speed*Time.deltaTime);

        if (Vector2.Distance(transform.position, spotsMove[i].transform.position)<0.1f)
        {
            if (waitTime<=0)
            {
                if (spotsMove[i] != spotsMove[spotsMove.Length -1])
                {
                    i++;
                }
                else
                {
                    i=0;
                }

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }

    IEnumerator CheckMoving()
    {
        actualPos = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (transform.position.x>actualPos.x)
        {
            sr.flipX = true;
            anim.SetBool("Idle", false);
        }
        else if(transform.position.x < actualPos.x){
            sr.flipX = false;
        }
        else if (transform.position.x == actualPos.x)
        {
            anim.SetBool("Idle", true);
        }
    }

}
